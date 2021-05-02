using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.NPCs
{
    public class WhiteSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Slime");
            Main.npcFrameCount[npc.type] = 2;
            aiType = NPCID.BlueSlime;
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 14;
            npc.scale = 0.5f;
            animationType = NPCID.BlueSlime;
            npc.aiStyle = NPCID.BlueSlime;
            npc.damage = 75;
            npc.defense = 5;
            npc.lifeMax = 2750;
            npc.knockBackResist = 0f;
			npc.npcSlots = 1.5f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.rarity = 2;
            npc.value = 27505;
            banner = npc.type;
            bannerItem = mod.ItemType("WhiteSlimeBanner");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1.03f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 1.03f);  //boss damage increase in expermode
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //return SpawnCondition.OverworldNightMonster.Chance * 0.1f; //spawnInfo.player.ZoneSkyHeight
            if (spawnInfo.player.ZoneOverworldHeight && !NPC.AnyNPCs(mod.NPCType("WhiteSlime")) && NPC.downedMoonlord == true)
            {
                return SpawnCondition.OverworldDaySlime.Chance * 0.108f;
            }
            else
            {
                return 0f;
            }
        }

        int WhiteSlimeAi = 0;

        public override void AI()
        {
            npc.velocity.X = npc.velocity.X * (1.0f);
            npc.velocity.Y = npc.velocity.Y * (1.0f);

            WhiteSlimeAi++;
            if (WhiteSlimeAi >= 60)
            {

                float Speed = 5f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 75;
                int type = mod.ProjectileType("HyperSlimeBallHostile");
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 87);
                float rotation = (1.80f + Main.rand.Next(-1, 1)); //(float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);

                WhiteSlimeAi = 0;

            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 4, 2 * hitDirection, -3f);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].scale = 0.8f;
                    }
                    else
                    {
                        Main.dust[dust].scale = 0.8f;
                    }
                }
            }
        }

        public override void NPCLoot()
        {
            if (npc.life <= 0)
            {
                /*Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BloodSlime1"), 1.1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BloodSlime2"), 1.1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BloodSlime3"), 1.1f); */
            }
                Item.NewItem(npc.getRect(), mod.ItemType("WhiteGel"), 5);
            if (Main.rand.Next(2) == 0 && Main.expertMode)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("WhiteGel"), 1);
            }
        }
    }
}
