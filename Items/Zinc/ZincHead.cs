using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    [AutoloadEquip(EquipType.Head)]
    public class ZincHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Helmet");
            Tooltip.SetDefault("+1 max Minions");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 19000;
            item.rare = 2;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ZincBody") && legs.type == mod.ItemType("ZincLegs");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "7% Increased damage reduction";
            player.endurance += 0.07f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ZincBar"), 19);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}