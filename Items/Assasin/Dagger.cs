using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace MartainsOrder.Items.Assasin
{
    public class Dagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dagger");
            Tooltip.SetDefault("Goes through tiles while in rush");
        }

        public override void SetDefaults()
        {
            item.damage = 9;
            item.thrown = true;
			item.crit = 2;
            item.width = 12;
            item.height = 28;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2f;
            item.noUseGraphic = true;
            item.value = 1000;
            item.rare = 1;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("Nule");
            item.shootSpeed = 25.5f;
            item.autoReuse = true;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			int numberProjectiles = 1;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                    float scale = 1f - (Main.rand.NextFloat() * .1f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Dagger"), damage, knockBack, player.whoAmI);
                }
			return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 7);
            recipe.AddRecipeGroup("Wood", 6);
            recipe.AddTile(mod.TileType("Processor"));
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}