using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace MartainsOrder.Items.Zinc
{
    public class ZincPen : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc PenSword");
            Tooltip.SetDefault("Splashes Ink Trials");
        }

        public override void SetDefaults()
        {
            item.damage = 31;
            item.crit = 3;
            item.melee = true;
            item.width = 42;
            item.height = 42;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 5f;
            item.scale = 1.2f;
            item.value = 27000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("ZincPen");
            item.shootSpeed = 30f;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ZincBar"), 18);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}