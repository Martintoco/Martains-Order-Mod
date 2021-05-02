using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class VortexLauncher : ModItem
    {
		private int vortexRockets = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electro-Shock");
            Tooltip.SetDefault("Pressure-based"
			+ "\nCan only shoot certain rocket types"
			+ "\n15% Chance to do not consume Ammo"
			+ "\n'Elctro rockets, go!'");
        }
		
        public override void SetDefaults()
        {
            item.damage = 177;
            item.ranged = true;
            item.crit = 4;
            item.width = 38;
            item.height = 24;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.knockBack = 7f;
            item.scale = 1f;
            item.value = 100000;
            item.rare = 10;
            item.noMelee = true;
			item.autoReuse = true;
            item.UseSound = SoundID.Item10;
            item.shoot = mod.ProjectileType("CoalRocket");
            item.shootSpeed = 9f;
            item.useAmmo = mod.ItemType("CoalRocket");
        }
		public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .15f;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			vortexRockets++;
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
			if(vortexRockets >= 3) {
			Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 61, 1f, 0f);
			float numberProjectiles = 2;
            float rotation = MathHelper.ToRadians(30);
            position += Vector2.Normalize(new Vector2(-speedX, -speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .5f;
				perturbedSpeed *= 1.75f;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("ElectroRocket"), damage, knockBack, player.whoAmI);
			}
			vortexRockets = 0;
			}

            return true;
        }
    }
}
