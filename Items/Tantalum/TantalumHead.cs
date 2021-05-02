using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    [AutoloadEquip(EquipType.Head)]
    public class TantalumHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Hat");
            Tooltip.SetDefault("+2 max Minions");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 37000;
            item.rare = 5;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("TantalumBody") && legs.type == mod.ItemType("TantalumLegs");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "15% increased Damage and Life Regeneration";
            player.allDamage += 0.15f;
            player.lifeRegen += 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TantalumBar"), 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}