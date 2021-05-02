using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.NPCs
{
    public class PineBush : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pine Bush");
        }

        public override void SetDefaults()
        {
            npc.width = 22;
            npc.height = 24;
            npc.aiStyle = -1;
            npc.damage = 12;
            npc.defense = 5;
            npc.lifeMax = 50;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath18;
			npc.noGravity = false;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 45;
            //npc.loot = (ItemID.Gel, 1);
            npc.dontTakeDamage = false;
            banner = npc.type;
            bannerItem = mod.ItemType("PineBushBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneOverworldHeight && Main.dayTime && !spawnInfo.player.ZoneSnow && !spawnInfo.player.ZoneCorrupt && !spawnInfo.player.ZoneJungle && !spawnInfo.player.ZoneHoly && !spawnInfo.player.ZoneCrimson && !spawnInfo.player.ZoneDesert && !spawnInfo.player.ZoneGlowshroom && !spawnInfo.player.ZoneBeach && !Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ZoneVoid)
            {
                return 0.4f;
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
        }
		
		public override void HitEffect(int hitDirection, double damage)
        {
			for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 3, 2 * hitDirection, -2f);
                Main.dust[dust].noGravity = false;
                Main.dust[dust].scale = 1.05f;
            }
        }

        public override void NPCLoot()
        {
            if (npc.life <= 0)
            {
				Gore.NewGore(npc.position, npc.velocity, GoreID.TreeLeaf_Normal, 1f);
				Gore.NewGore(npc.position, npc.velocity, GoreID.TreeLeaf_Normal, 1.1f);
				Gore.NewGore(npc.position, npc.velocity, GoreID.TreeLeaf_Normal, 0.9f);
				Gore.NewGore(npc.position, npc.velocity, GoreID.TreeLeaf_Normal, 1f);
				Gore.NewGore(npc.position, npc.velocity, GoreID.TreeLeaf_Normal, 1.1f);
				Gore.NewGore(npc.position, npc.velocity, GoreID.TreeLeaf_Normal, 0.9f);
            }
            if (Main.rand.Next(1) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.PineTreeBlock, Main.rand.Next(4, 11));
            }
			if (Main.rand.Next(2) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.Wood, Main.rand.Next(2, 5));
            }
        }
    }
}
