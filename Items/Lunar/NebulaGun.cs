using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class NebulaGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Ray");
			Tooltip.SetDefault("'Charge in some blinding sparks'"
			+ "\nCharges crystals when used by main hand on Hotbar");
        }
		
		private int nebulaCharge = 0;
		private int nebulaChargeCD = 0;
        public override void SetDefaults()
        {
            item.damage = 164;
            item.magic = true;
            item.crit = 4;
            item.mana = 12;
            item.width = 40;
            item.height = 28;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.knockBack = 4f;
            item.scale = 1f;
            item.value = 100000;
            item.rare = 10;
			item.noMelee = true;
            item.UseSound = SoundID.Item12;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("NebulaLaser");
            item.autoReuse = true;
		}
		public override void HoldItem(Player player)
        {
			nebulaChargeCD++;
            if(nebulaChargeCD >= 15 && nebulaCharge < 25) {
				nebulaCharge++;
				nebulaChargeCD = 0;
			}
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
			if(nebulaCharge > 0)Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 27);
            for (int i = 0; i < nebulaCharge; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(60));
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("NebulaCrystal"), damage/2, knockBack, player.whoAmI);
            }
			speedX *= 1.5f; speedY *= 1.5f;
			nebulaCharge = 0;
			nebulaChargeCD = -10;
            return true;
        }
    }
}