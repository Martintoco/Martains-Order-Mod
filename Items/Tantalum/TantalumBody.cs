using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    [AutoloadEquip(EquipType.Body)]
    public class TantalumBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Tantalum Chestplate");
            Tooltip.SetDefault("Increases Mana Regeneration"
                + "\n+2 max Minions");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 38500;
            item.rare = 5;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            //player.buffImmune[BuffID.OnFire] = true;
            player.manaRegen = 2;
            player.maxMinions += 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TantalumBar"), 20);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}