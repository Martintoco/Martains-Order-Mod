using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.NPCs
{
    public class Clam : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Clam");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 40;
            npc.aiStyle = -1;
            npc.damage = 35;
            npc.defense = 50;
            npc.lifeMax = 50;
            npc.knockBackResist = 0.3f;
            npc.HitSound = SoundID.NPCHit38;
            npc.DeathSound = SoundID.NPCDeath41;
			npc.noGravity = false;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 150;
            //npc.loot = (ItemID.Gel, 1);
            npc.dontTakeDamage = false;
            npc.buffImmune[BuffID.OnFire] = false;
			npc.buffImmune[BuffID.Confused] = false;
            banner = npc.type;
            bannerItem = mod.ItemType("ClamBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneBeach)
            {
                return SpawnCondition.OceanMonster.Chance * 0.755f;
            }
            else
            {
                return 0f;
            }
        }

        public override void AI()
        {
            npc.velocity = npc.velocity * (0.25f);
            npc.TargetClosest(true);
            Vector2 targetPosition = Main.player[npc.target].position;

            npc.ai[0]++;
            if (npc.ai[0] >= 500)
            {
                npc.dontTakeDamage = true;
            }
            if (npc.ai[0] >= 1000)
            {
                npc.dontTakeDamage = false;
                npc.ai[0] = 0;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.ai[0] >= 0)
            {
                npc.frame.Y = 1 * frameHeight;
            }
            if (npc.ai[0] >= 10)
            {
                npc.frame.Y = 0 * frameHeight;
            }
            if (npc.ai[0] >= 500)
            {
                npc.frame.Y = 1 * frameHeight;
            }
            if (npc.ai[0] >= 510)
            {
                npc.frame.Y = 2 * frameHeight;
            }

        }

        public override void NPCLoot()
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Clam1"), 1.1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Clam2"), 1.1f);
            }
            if (Main.rand.Next(3) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(1, 4));
            }
            if (Main.rand.Next(15) == 0 && Main.expertMode)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("MagicPearl"), 1);
            }
			if (Main.rand.Next(16) == 0 && Main.expertMode)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("ClamChest"), 1);
            }
            if (Main.rand.Next(2) == 0 && Main.hardMode && NPC.downedGolemBoss)
            {
                Item.NewItem(npc.getRect(), ItemID.BeetleHusk, Main.rand.Next(1, 3));
            }
        }
    }
}
