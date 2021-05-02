using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Gamer
{
    public class MP5 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("MP5");
            Tooltip.SetDefault("25% Chance to do not consume Ammo"
            + "\n'360° no scope!'");
        }

        public override void SetDefaults()
        {
            item.damage = 49;
            item.crit = 15;
            item.ranged = true;
            item.width = 48;
            item.height = 22;
            item.useTime = 9;
            item.useAnimation = 9;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4f;
            item.value = 27500;
            item.rare = 4;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = AmmoID.Bullet;
            item.shootSpeed = 13f;
            item.useAmmo = AmmoID.Bullet;       //Restrict the type of ammo the weapon can use, so that the weapon cannot use other ammos
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .25f;
        }

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            // Here we use the multiplicative damage modifier because Terraria does this approach for Ammo damage bonuses. 
            mult *= player.bulletDamage;
        }
		
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, 6);
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }
    }
}
