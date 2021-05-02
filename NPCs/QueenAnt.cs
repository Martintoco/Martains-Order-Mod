using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.NPCs
{
    public class QueenAnt : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Queen Ant");
            Main.npcFrameCount[npc.type] = 3;
            aiType = 42;
        }

        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 30;
            animationType = 42;
            npc.aiStyle = 5;
            npc.damage = 32;
            npc.defense = 5;
            npc.lifeMax = 240;
            npc.noGravity = true;
            npc.noTileCollide = false;
            npc.knockBackResist = 0.1f;
			npc.npcSlots = 1.5f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.rarity = 1;
            npc.value = 350;
            banner = npc.type;
            bannerItem = mod.ItemType("QueenAntBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!NPC.AnyNPCs(mod.NPCType("QueenAnt")))
            {
                for (int k = 0; k < 255; k++)
                {
                    Player player = Main.player[k];
                    if (!player.active)
                    {
                        continue;
                    }

                    foreach (Item item in player.inventory)
                    {
                        if (item.type == mod.ItemType("AntItem"))
                        {
                            if (Main.hardMode) return SpawnCondition.OverworldDaySlime.Chance * 0.25f;
                            else return SpawnCondition.OverworldDaySlime.Chance * 0.255f;
                        }
                    }
                }
                return 0f;
            }
            return 0f;
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            Vector2 targetPosition = Main.player[npc.target].position;

            npc.velocity.X = npc.velocity.X * (0.989f);
            npc.velocity.Y = npc.velocity.Y * (0.9954f);

            if (targetPosition.X - 600 < npc.position.X // IF the target is to my left
            && npc.velocity.X > -5) // AND I'm not at max "left" velocity
            {
                npc.velocity.X -= 0.2f; // accelerate to the left
            }
            if (targetPosition.X + 600 > npc.position.X // IF the target is to my right
            && npc.velocity.X < 5) // AND I'm not at max "right" velocity
            {
                npc.velocity.X += 0.2f; // accelerate to the right
            }

            if (targetPosition.Y - 600 < npc.position.Y // IF the target is to my up
            && npc.velocity.Y > -5) // AND I'm not at max "up" velocity
            {
                npc.velocity.Y -= 0.2f; // accelerate up
            }
            if (targetPosition.Y + 600 > npc.position.Y // IF the target is to my down
            && npc.velocity.Y < 5) // AND I'm not at max "down" velocity
            {
                npc.velocity.Y += 0.2f; // accelerate down
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 0, 2 * hitDirection, -3f);
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
            if (Main.rand.Next(3) == 0 && NPC.downedBoss2)
            {
                Item.NewItem(npc.getRect(), ItemID.FossilOre, Main.rand.Next(6, 10));
            }
            if (Main.rand.Next(2) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.Pearlwood, Main.rand.Next(8, 16));
            }
            if (Main.rand.Next(3) == 0 && NPC.downedGolemBoss)
            {
                Item.NewItem(npc.getRect(), ItemID.BeetleHusk, Main.rand.Next(5, 8));
            }
        }
    }
}
