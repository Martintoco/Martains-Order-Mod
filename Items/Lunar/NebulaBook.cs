using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class NebulaBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebulosis");
			Tooltip.SetDefault("'Show the beauty of deep space to all'");
        }

        public override void SetDefaults()
        {
            item.damage = 87;
            item.magic = true;
            item.crit = 3;
            item.mana = 11;
            item.width = 28;
            item.height = 30;
            item.useTime = 11;
            item.useAnimation = 11;
            item.useStyle = 5;
            item.knockBack = 4.25f;
            item.scale = 1f;
            item.value = 100000;
            item.rare = 10;
			item.noMelee = true;
            item.UseSound = SoundID.Item8;
            item.shootSpeed = 3f;
            item.shoot = mod.ProjectileType("Nebulosis");
            item.autoReuse = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 4;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(60));
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
			Main.PlaySound(SoundID.Item9);

            return true;
        }
    }
}