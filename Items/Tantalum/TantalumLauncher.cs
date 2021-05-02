using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Launcher");
            Tooltip.SetDefault("Pressure-based"
			+ "\nCan only shoot certain rocket types"
			+ "\n5% Chance to do not consume Ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 64;
            item.ranged = true;
            item.crit = 2;
            item.width = 48;
            item.height = 20;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
            item.knockBack = 5f;
            item.scale = 1f;
            item.value = 24500;
            item.rare = 5;
            item.noMelee = true;
			item.autoReuse = true;
            item.UseSound = SoundID.Item10;
            item.shoot = mod.ProjectileType("CoalRocket");
            item.shootSpeed = 8f;
            item.useAmmo = mod.ItemType("CoalRocket");
        }
		public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TantalumBar"), 12);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
