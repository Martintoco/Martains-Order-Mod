using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    [AutoloadEquip(EquipType.Body)]
    public class ZincBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Zinc Chestplate");
            Tooltip.SetDefault("Increases Damage by 15%"
                + "\n+1 max Minions");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 20000;
            item.rare = 2;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            //player.buffImmune[BuffID.OnFire] = true;
            player.allDamage += 0.15f;
            player.maxMinions += 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ZincBar"), 23);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}