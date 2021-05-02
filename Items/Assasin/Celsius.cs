using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace MartainsOrder.Items.Assasin
{
    public class Celsius : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celsius");
            Tooltip.SetDefault("Explodes on death while in rush");
        }

        public override void SetDefaults()
        {
            item.damage = 17;
            item.thrown = true;
			item.crit = 4;
            item.width = 12;
            item.height = 28;
            item.useTime = 13;
            item.useAnimation = 13;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3.25f;
            item.noUseGraphic = true;
            item.value = 17000;
            item.rare = 3;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("Nule");
            item.shootSpeed = 31.5f;
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
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Celsius"), damage, knockBack, player.whoAmI);
                }
			return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 16);
			//recipe.AddIngredient(ItemID.Spike, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}