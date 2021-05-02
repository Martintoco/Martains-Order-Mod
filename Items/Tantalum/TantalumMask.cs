using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    [AutoloadEquip(EquipType.Head)]
    public class TantalumMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Mask");
            Tooltip.SetDefault("Increases Throwing damage by 15%");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 37000;
            item.rare = 5;
            item.defense = 17;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.15f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("TantalumBody") && legs.type == mod.ItemType("TantalumLegs");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "15% Increased Throwing Speed and Movement Speed";
            player.thrownVelocity += 0.15f;
            player.moveSpeed += 0.15f;
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