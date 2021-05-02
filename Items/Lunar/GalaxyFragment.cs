using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class GalaxyFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Fragment");
			Tooltip.SetDefault("'Deep among most of the universe'");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 99;
			ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.width = 24;
            item.height = 22;
            item.rare = 9;
            item.value = 10000;
        }
		
		public override Color? GetAlpha(Color lightColor) { return new Color(250, 250, 250, 255);}
    }

    public class GalaxyFragmentDrop : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {

            if (npc.type == NPCID.LunarTowerVortex)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X+35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X-35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y+50, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y-50, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
            }
            if (npc.type == NPCID.LunarTowerStardust)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X+35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X-35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y+50, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y-50, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
            }
            if (npc.type == NPCID.LunarTowerNebula)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X+35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X-35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y+50, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y-50, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
            }
            if (npc.type == NPCID.LunarTowerSolar)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X+35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X-35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y+50, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y-50, npc.width, npc.height, mod.ItemType("GalaxyFragment"), Main.rand.Next(1, 5));
            }
        }
    }
}
