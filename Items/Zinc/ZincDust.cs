using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    public class ZincDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc DustBag");
            Tooltip.SetDefault("Spreads Damaging Dust");
        }

        public override void SetDefaults()
        {
            item.damage = 19;
            item.thrown = true;
            item.width = 20;
            item.height = 26;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 4f;
            item.scale = 1.1f;
            item.value = 27000;
            item.rare = 2;
            item.UseSound = SoundID.Item39;
            item.shoot = ModContent.ProjectileType<Projectiles.ZincDust>();
            item.shootSpeed = 10.25f;
            item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 6 + Main.rand.Next(0); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(75)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ZincBar"), 16);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}