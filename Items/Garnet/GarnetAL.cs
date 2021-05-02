using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    [AutoloadEquip(EquipType.Legs)]
    public class GarnetAL : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Leggings");
            Tooltip.SetDefault("+2 Max minions"
            + "\nIncreases Movement Speed by 20%");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = 43500;
            item.rare = 4;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
            player.moveSpeed += 0.20f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 18);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}