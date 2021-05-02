using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace MartainsOrder.Items.Extra
{
    public class RGBDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RGB Dagger");
            Tooltip.SetDefault("Generates epilepsy while in rush");
        }

        public override void SetDefaults()
        {
            item.damage = 98;
            item.thrown = true;
			item.crit = 7;
            item.width = 14;
            item.height = 32;
            item.useTime = 13;
            item.useAnimation = 13;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 6.5f;
            item.noUseGraphic = true;
            item.value = 90000;
            item.rare = -12;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("Nule");
            item.shootSpeed = 32.5f;
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
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("RGBDagger"), damage, knockBack, player.whoAmI);
                }
			return true;
        }
    }
}