using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Bar");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 84; // influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.
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
            item.rare = 5;
            item.value = 4500;
            item.createTile = mod.TileType("TantalumBar");
            item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TantalumOre"), 4);
            recipe.AddTile(133);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
