using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumNaginata : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Naginata");
        }

        public override void SetDefaults()
        {
            item.damage = 36;
            item.crit = 6;
            item.width = 40;
            item.height = 88;
            item.useTime = 7;
            item.useAnimation = 7;
            item.channel = true;
            item.useStyle = 100;
            item.knockBack = 0f;
            item.value = 24500;
            item.rare = 5;
            item.shoot = mod.ProjectileType("TantalumNaginataProjectile");
            item.noUseGraphic = true;
            item.useTurn = true;
        }

        public override bool UseItemFrame(Player player)
        {
            player.bodyFrame.Y = 3 * player.bodyFrame.Height;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TantalumBar"), 9);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
