using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Extra
{
    public class FishyumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fishyum Bar");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.maxStack = 99;
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.rare = -12;
            item.value = 10000;
            item.createTile = mod.TileType("FishyumBar");
            item.placeStyle = 0;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FishyumOre"), 3);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FishyumOre"), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(mod.ItemType("FishyumRocket"), 75);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FishyumBar"), 9);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("Katanimer"), 1);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FishyumBar"), 4);
			recipe.AddIngredient(ItemID.RainbowBrick, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(mod.ItemType("RGBDagger"), 1);
			recipe.AddRecipe();
		}
    }
}
