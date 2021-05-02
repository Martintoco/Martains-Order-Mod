using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    [AutoloadEquip(EquipType.Body)]
    public class GarnetAB : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Garnet ChestPlate");
            Tooltip.SetDefault("Increases all Damage by 10%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = 45500;
            item.rare = 4;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 22);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}