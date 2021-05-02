using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace MartainsOrder.Items.DustyGarment
{
    public class Dustter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dustter");
            Tooltip.SetDefault("Leaves damaging dust while in rush");
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.thrown = true;
			item.crit = 4;
            item.width = 12;
            item.height = 30;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2.5f;
            item.noUseGraphic = true;
            item.value = 9000;
            item.rare = 3;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("Nule");
            item.shootSpeed = 29.5f;
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
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Dustter"), damage, knockBack, player.whoAmI);
                }
			return true;
        }
    }
}