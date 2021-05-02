using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.NPCs
{
    public class NightMoth : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Night Moth");
            Main.npcFrameCount[npc.type] = 4;
            aiType = 356;
        }

        public override void SetDefaults()
        {
            npc.width = 20;
            npc.height = 20;
            animationType = 93;
            npc.aiStyle = 14;
            npc.damage = 10;
            npc.defense = 1;
            npc.lifeMax = 10;
            npc.noGravity = true;
            npc.noTileCollide = false;
            npc.knockBackResist = 0.7f;
			npc.npcSlots = 0.75f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 5;
            banner = npc.type;
            bannerItem = mod.ItemType("NightMothBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.29f; //spawnInfo.player.ZoneSkyHeight
        }

        public override void AI()
        {
            npc.velocity.X = npc.velocity.X * (0.930f);
            npc.velocity.Y = npc.velocity.Y * (0.932f);

            if (Main.dayTime)
            {
                npc.noTileCollide = true;
                npc.velocity.Y -= 0.1f;
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 27;
            npc.damage = 16;
        }

        public override void NPCLoot()
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NightMoth1"), 1.1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NightMoth2"), 1.1f);
            }
            if (Main.rand.Next(7) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.Silk, 1);
            }
            if (Main.rand.Next(26) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.Hook, 1);
            }
            if (Main.rand.Next(26) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.Aglet, 1);
            }
            /*if (Main.rand.Next(5) == 0 && Main.hardMode) {
				Item.NewItem(npc.getRect(), ItemID.SoulofFlight, Main.rand.Next(1, 2));
			}*/
        }
    }
}
