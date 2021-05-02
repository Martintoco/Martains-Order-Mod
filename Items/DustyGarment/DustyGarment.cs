using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.DustyGarment
{
    public class DustyGarment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dusty Garment");
			Tooltip.SetDefault("'Passed through generations, of bones...'");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.width = 26;
            item.height = 28;
            item.rare = 3;
            item.value = 3;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DustyGarment"), 7);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(mod.ItemType("DustTyphoon"), 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("AssasinKnife"), 1);
            recipe.AddIngredient(mod.ItemType("DustyGarment"), 5);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(mod.ItemType("Dustter"), 1);
            recipe.AddRecipe();
        }
    }
}
