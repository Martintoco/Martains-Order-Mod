using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Rocketeer
{
    public class PressureLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pressure Launcher");
            Tooltip.SetDefault("Pressure-based"
			+ "\nCan only shoot certain rocket types");
        }

        public override void SetDefaults()
        {
            item.damage = 23;
            item.ranged = true;
            item.crit = 1;
            item.width = 36;
            item.height = 18;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.knockBack = 3f;
            item.scale = 1f;
            item.value = 1000;
            item.rare = 1;
            item.noMelee = true;
			item.autoReuse = false;
            item.UseSound = SoundID.Item10;
            item.shoot = mod.ProjectileType("CoalRocket");
            item.shootSpeed = 7f;
            item.useAmmo = mod.ItemType("CoalRocket");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 9);
			recipe.AddIngredient(mod.ItemType("Electronics"), 4);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddTile(mod.TileType("Processor"));
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
