using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.NPCs
{
	[AutoloadBossHead]
    public class GarnetCluster : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Flower Cluster");
                                                             //Main.npcFrameCount[npc.type] = 16; // make sure to set this for your modnpcs.
                                                             //aiType = 287;
        }
		public override void BossHeadSlot(ref int index) {
			ModContent.GetModBossHeadSlot("MartainsOrder/NPCs/GarnetCluster_Head_Boss");
		}

        public override void SetDefaults()
        {
            npc.width = 68;
            npc.height = 90;
            animationType = NPCID.LunarTowerSolar;
            npc.aiStyle = 0;
            //npc.alpha = 50;
            npc.damage = 80;
            npc.defense = 64;
            npc.lifeMax = 1000;
            npc.knockBackResist = 0f;
			npc.npcSlots = 1.5f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.buffImmune[20] = true;
            npc.buffImmune[31] = true;
            npc.buffImmune[70] = true;
            npc.rarity = 1;
            npc.lavaImmune = true;
            //npc.boss = true;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 5075;
            //npc.loot = (ItemID.Bone, 1);
            //banner = npc.type;
            //bannerItem = mod.ItemType("NuclearSkeletonBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (spawnInfo.player.ZoneRockLayerHeight && Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !spawnInfo.player.ZoneSnow && !spawnInfo.player.ZoneJungle && !spawnInfo.player.ZoneUndergroundDesert && !NPC.AnyNPCs(mod.NPCType("GarnetCluster")))
            {
                return (SpawnCondition.UndergroundMimic.Chance * 3.445f);
            }
            else
            {
                return 0f;
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1.05f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 1.05f);  //boss damage increase in expermode
        }

        public override void AI()
        {
            //npc.velocity = npc.velocity*(1.019f);
            npc.velocity = npc.velocity * (1f);
            npc.TargetClosest(true);
            Vector2 targetPosition = Main.player[npc.target].position;
            var targetDirection = Main.player[npc.target].direction;
            npc.ai[0]++; //or "npc.ai[0] += 1;", works the same way
            npc.ai[1]++;
			
			Lighting.AddLight(npc.Center, 0.3f, 0.1f, 0.1f);

            if (npc.ai[0] >= 60)
            {

                if (npc.life < npc.lifeMax)
                {
                    float Speed = 6f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 10;
                    int type = mod.ProjectileType("GarnetLaser");
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                    float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }
                else
                {
                    Main.PlaySound(27, (int)npc.position.X, (int)npc.position.Y, 0);
                }
                npc.ai[0] = 0;
            }

        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60, 2 * hitDirection, -3f);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].scale = 2f;
                    }
                    else
                    {
                        Main.dust[dust].scale = 2f;
                        Main.dust[dust].noGravity = true;
                    }
                }
            }
        }

        public override Color? GetAlpha(Color drawColor)
        {
            drawColor.R = Utils.Clamp<byte>(drawColor.R, 75, 255);
            drawColor.G = Utils.Clamp<byte>(drawColor.G, 60, 255);
            drawColor.B = Utils.Clamp<byte>(drawColor.B, 60, 255);
            drawColor.A = 255;
            return drawColor;
        }

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(mod.BuffType("GarnetCurse"), 180);
            target.AddBuff(31, 150);
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            target.AddBuff(mod.BuffType("GarnetCurse"), 180);
            target.AddBuff(31, 150);
        }

        public override void NPCLoot()
        {
            if (npc.life <= 0)
            {
                MartainWorld.downedGarnetFlowerCluster = true;
				if (Main.netMode == NetmodeID.Server) {
					NetMessage.SendData(MessageID.WorldData);
				}
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BloodSlime1"), 1.1f);
            }
			if (Main.rand.Next(2) == 0)
            {
                Item.NewItem(npc.getRect(), (mod.ItemType("GarnetCore")), 1);
            }
            if (Main.rand.Next(1) == 0)
            {
                //Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(4, 8));
                Item.NewItem(npc.getRect(), (mod.ItemType("GarnetBar")), Main.rand.Next(16, 21));
            }
            if (Main.rand.Next(1) == 0 && Main.expertMode)
            {
                Item.NewItem(npc.getRect(), (mod.ItemType("GarnetBar")), Main.rand.Next(3, 5));
            }
        }
    }
}
