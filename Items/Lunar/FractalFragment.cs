using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class FractalFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fractal Fragment");
			Tooltip.SetDefault("'Unmesureable flowing power'");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 99;
			ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.width = 20;
            item.height = 20;
            item.rare = 9;
            item.value = 10000;
        }
		
		public override Color? GetAlpha(Color lightColor) { return new Color(250, 250, 250, 255);}

        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("SolarEclipse"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("NebulaBook"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("Volatilizer"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentStardust, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("StardustWhip"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("SolarSword"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("NebulaGun"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("VortexLauncher"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentStardust, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("StardustSentry"));
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 2);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 1);
			recipe.AddIngredient(ItemID.FragmentStardust, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentSolar);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 1);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 2);
			recipe.AddIngredient(ItemID.FragmentVortex, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentNebula);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 2);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 1);
			recipe.AddIngredient(ItemID.FragmentNebula, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentVortex);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 1);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 2);
			recipe.AddIngredient(ItemID.FragmentSolar, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentStardust);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 1);
			recipe.AddIngredient(ItemID.FragmentNebula, 1);
			recipe.AddIngredient(ItemID.FragmentSolar, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("FractalFragment"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 1);
			recipe.AddIngredient(ItemID.FragmentVortex, 1);
			recipe.AddIngredient(ItemID.FragmentStardust, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("GalaxyFragment"));
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 6);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("LFAH"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 27);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("LFAB"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 21);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("LFAL"));
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 6);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("GAH"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 27);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("GAB"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 21);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("GAL"));
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("Fragtal"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("Perforator"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("RecursiveNailers"), 500);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("Galaxee"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("OrbitalSaw"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("Chromentaminator"));
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 14);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("FractalHamaxe"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 12);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("FractalPickaxe"));
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 14);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("GalaxyHamaxe"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 12);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("GalaxyPickaxe"));
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WarriorEmblem, 1);
			recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("SolarEmblem"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SorcererEmblem, 1);
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("NebulaEmblem"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RangerEmblem, 1);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("VortexEmblem"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SummonerEmblem, 1);
			recipe.AddIngredient(ItemID.FragmentStardust, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("StardustEmblem"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TosserEmblem"), 1);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("FractalEmblem"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NeutralEmblem"), 1);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("GalaxyEmblem"));
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AvengerEmblem, 1);
			recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("SolarEmblem"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AvengerEmblem, 1);
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("NebulaEmblem"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AvengerEmblem, 1);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("VortexEmblem"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AvengerEmblem, 1);
			recipe.AddIngredient(ItemID.FragmentStardust, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("StardustEmblem"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AvengerEmblem, 1);
			recipe.AddIngredient(mod.ItemType("FractalFragment"), 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("FractalEmblem"));
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AvengerEmblem, 1);
			recipe.AddIngredient(mod.ItemType("GalaxyFragment"), 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("GalaxyEmblem"));
			recipe.AddRecipe();
			
		}
    }

    public class LunarFragmentDrop : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {

            if (npc.type == NPCID.LunarTowerVortex)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X+35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X-35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y+50, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y-50, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
            }
            if (npc.type == NPCID.LunarTowerStardust)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X+35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X-35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y+50, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y-50, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
            }
            if (npc.type == NPCID.LunarTowerNebula)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X+35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X-35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y+50, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y-50, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
            }
            if (npc.type == NPCID.LunarTowerSolar)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X+35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X-35, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y+50, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y-50, npc.width, npc.height, mod.ItemType("FractalFragment"), Main.rand.Next(1, 5));
            }
        }
    }
}
