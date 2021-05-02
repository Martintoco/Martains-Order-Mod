using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumScrews : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Screws Case");
            Tooltip.SetDefault("Made for construction, but used for throwing");
        }

        public override void SetDefaults()
        {
            item.damage = 33;
            item.thrown = true;
            item.width = 30;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 4f;
            item.scale = 1.1f;
            item.value = 24500;
            item.rare = 5;
            item.UseSound = SoundID.Item19;
            item.shoot = mod.ProjectileType("Nule");
            item.shootSpeed = 8.4f;
            item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3 + Main.rand.Next(0); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X + Main.rand.Next(-3, 3), perturbedSpeed.Y + Main.rand.Next(-3, 3), mod.ProjectileType("TantalumScrew"), damage, knockBack, player.whoAmI);
            }

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