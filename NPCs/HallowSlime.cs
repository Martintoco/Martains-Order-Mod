using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.NPCs
{
    public class HallowSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallow Slime");
            Main.npcFrameCount[npc.type] = 2;
            aiType = NPCID.BlueSlime;
        }

        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 34;
            animationType = NPCID.BlueSlime;
            npc.aiStyle = NPCID.BlueSlime;
            npc.damage = 35;
            npc.defense = 15;
            npc.lifeMax = 64;
            npc.knockBackResist = 0.5f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 305;
            //npc.loot = (ItemID.Gel, 1);
            npc.buffImmune[BuffID.Poisoned] = false;
            npc.buffImmune[BuffID.Confused] = false;
            npc.buffImmune[BuffID.OnFire] = false;
            banner = npc.type;
            bannerItem = mod.ItemType("HallowSlimeBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneHoly)
            {
                return SpawnCondition.OverworldDaySlime.Chance * 0.915f;
            }
            else
            {
                return 0f;
            }
        }

        public override void AI()
        {
            npc.velocity = npc.velocity * (1f);
            npc.TargetClosest(true);
            Vector2 targetPosition = Main.player[npc.target].position;
			
			Lighting.AddLight(npc.Center, 0.15f, 0.15f, 0.05f);

            npc.velocity.X = npc.velocity.X * (1.005f);
            npc.velocity.Y = npc.velocity.Y * (1.000f);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 57, 2 * hitDirection, -2f);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].scale = 2.35f;
                    }
                    else
                    {
                        Main.dust[dust].scale = 2.25f;
                    }
                }
            }
        }

        public override Color? GetAlpha(Color drawColor)
        {
            drawColor.R = Utils.Clamp<byte>(drawColor.R, 110, 255);
            drawColor.G = Utils.Clamp<byte>(drawColor.G, 105, 255);
            drawColor.B = Utils.Clamp<byte>(drawColor.B, 100, 255);
            drawColor.A = 255;
            return drawColor;
        }
		
		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
			if(Main.rand.Next(2)==0)target.AddBuff(31, Main.rand.Next(150,181));
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if(Main.rand.Next(2)==0)target.AddBuff(31, Main.rand.Next(150,181));
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(1, 5));
            if (Main.rand.Next(35) == 0 && Main.expertMode)
            {
                Item.NewItem(npc.getRect(), ItemID.SlimeStaff, 1);
            }
            else if (Main.rand.Next(70) == 0 && !Main.expertMode)
            {
                Item.NewItem(npc.getRect(), ItemID.SlimeStaff, 1);
            }
			if (Main.rand.Next(60) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.Megaphone, 1);
            }
            if (Main.rand.Next(2) == 0 && NPC.downedBoss3 || Main.rand.Next(2) == 0 && Main.hardMode)
            {
                Item.NewItem(npc.getRect(), ItemID.PixieDust, Main.rand.Next(1, 2));
            }
        }
    }
}
