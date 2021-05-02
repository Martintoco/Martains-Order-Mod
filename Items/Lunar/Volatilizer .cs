using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class Volatilizer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Volatilizer");
            Tooltip.SetDefault("35% Chance to do not consume Ammo"
            + "\n'Canalizes electrified flames with style'");
        }

        public override void SetDefaults()
        {
            item.damage = 76;
            item.crit = 7;
            item.ranged = true;
            item.width = 56;
            item.height = 16;
            item.useTime = 5;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0.525f;
            item.value = 100000;
            item.rare = 10;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("VolatileFlame");
            item.shootSpeed = 10.15f;
            item.useAmmo = AmmoID.Gel;
            item.flame = true;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return (Main.rand.NextFloat() >= .35f && player.itemAnimation >= player.itemAnimationMax - 4);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(8, 4);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 35f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }
		
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) 	
		{
			Texture2D texture = mod.GetTexture("Items/Lunar/Volatilizer_Glow");
			spriteBatch.Draw
			(
			texture,
			new Vector2
			(
			item.position.X - Main.screenPosition.X + item.width * 0.5f,
			item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
			),
			new Rectangle(0, 0, texture.Width, texture.Height),
			Color.White,
			rotation,
			texture.Size() * 0.5f,
			scale, 
			SpriteEffects.None, 
			0f
			);
		}
    }
}
