using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace MartainsOrder.NPCs
{
    public class Freddy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bear Animatronic");
            Main.npcFrameCount[npc.type] = 3;
            aiType = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 34;
            npc.height = 48;
            animationType = 3;
            npc.aiStyle = 3;
            npc.damage = 50;
            npc.defense = 129;
            npc.lifeMax = 4000;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.knockBackResist = 0f;
			npc.npcSlots = 1.5f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.rarity = 1;
            npc.value = 1275;
            //banner = npc.type;
            //bannerItem = mod.ItemType("QueenAntBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if(!NPC.AnyNPCs(mod.NPCType("Freddy"))) {
            return SpawnCondition.SolarEclipse.Chance * 0.15f;
			}
			else return 0f;
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            Vector2 targetPosition = Main.player[npc.target].position;

            npc.velocity.X = npc.velocity.X * (0.988f);
            if(npc.velocity.Y > -5f && npc.velocity.Y < 10f)npc.velocity.Y = npc.velocity.Y * (1.014f);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 226, 2 * hitDirection, -4f);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].scale = 0.7f;
                    }
                    else
                    {
                        Main.dust[dust].scale = 0.65f;
                    }
                }
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1.05f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 1.05f);  //boss damage increase in expermode
        }

        public override void NPCLoot()
        {
            if (npc.life <= 0)
            {
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NightMoth1"), 1.1f);
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NightMoth2"), 1.1f);
            }
            if (Main.rand.Next(2) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("Freddymask"), 1);
            }
        }
    }
}
