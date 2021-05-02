using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.NPCs
{
    public class BloodSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Slime");
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
            npc.defense = 5;
            npc.lifeMax = 195;
            npc.knockBackResist = 0.55f;
			npc.npcSlots = 1f;
            npc.HitSound = SoundID.NPCHit18;
            npc.DeathSound = SoundID.NPCDeath21;
            npc.value = 490;
            banner = npc.type;
            bannerItem = mod.ItemType("BloodSlimeBanner");
        }

        int DaylightScape = 0;

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //return SpawnCondition.OverworldNightMonster.Chance * 0.1f; //spawnInfo.player.ZoneSkyHeight
            if (Main.bloodMoon == true)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.223f;
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

            npc.velocity.X = npc.velocity.X * (1.007f);
            npc.velocity.Y = npc.velocity.Y * (1.013f);

            if (Main.dayTime) DaylightScape++;

            if (DaylightScape >= 60)
            {
                if (targetPosition.X >= npc.position.X) npc.velocity.X -= 10;
                if (targetPosition.X <= npc.position.X) npc.velocity.X += 10;
                if (npc.velocity.Y == 0) npc.velocity.Y -= 7;
                DaylightScape = 0;
            }
        }

        public override void NPCLoot()
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BloodSlime1"), 1.1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BloodSlime2"), 1.1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BloodSlime3"), 1.1f);
            }
            if (Main.rand.Next(14) == 0 && !Main.hardMode || Main.rand.Next(24) == 0 && Main.hardMode)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("BloodKnifePack"), 1);
            }
            if (Main.rand.Next(17) == 0 && Main.expertMode)
            {
                Item.NewItem(npc.getRect(), ItemID.MoneyTrough, 1);
            }
        }
    }
}
