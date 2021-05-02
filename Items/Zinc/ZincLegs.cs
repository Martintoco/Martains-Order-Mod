using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    [AutoloadEquip(EquipType.Legs)]
    public class ZincLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Leggings");
            Tooltip.SetDefault("Increases Movement Speed by 30%");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 19500;
            item.rare = 2;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.30f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ZincBar"), 21);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}