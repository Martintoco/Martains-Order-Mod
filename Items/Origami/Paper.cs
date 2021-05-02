using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Origami
{
    public class Paper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
			item.rare = 0;
			item.value = 2;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = mod.TileType("Paper");
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("Wood", 1);
            recipe.AddIngredient(mod.ItemType("Herb"), 1);
			recipe.AddIngredient(mod.ItemType("WillowFiber"), 1);
            recipe.AddTile(mod.TileType("Processor"));
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Paper"), 20);
			recipe.AddIngredient(ItemID.Torch, 9);
            recipe.AddTile(mod.TileType("Processor"));
            recipe.SetResult(mod.ItemType("PaperWorks"), 1);
            recipe.AddRecipe();
        }
    }
}