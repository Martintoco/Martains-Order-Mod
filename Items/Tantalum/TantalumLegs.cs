using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    [AutoloadEquip(EquipType.Legs)]
    public class TantalumLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Leggings");
            Tooltip.SetDefault("increases Speed and Jump hight by 25%");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 38000;
            item.rare = 5;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.25f;
            player.jumpBoost = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TantalumBar"), 15);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}