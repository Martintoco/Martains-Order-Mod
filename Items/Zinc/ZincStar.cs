using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    public class ZincStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Star");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.thrown = true;
            item.width = 18;
            item.height = 18;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 1;
            item.noMelee = true;
            item.consumable = true;
            item.maxStack = 999;
            item.knockBack = 5f;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.value = 90;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("ZincStar");
            item.shootSpeed = 11f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1 + Main.rand.Next(0); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // 15 degree spread.
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
            recipe.AddIngredient(mod.ItemType("ZincBar"), 1);
            recipe.AddIngredient(ItemID.Shuriken, 100);
            recipe.AddTile(16);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}