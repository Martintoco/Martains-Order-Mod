using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    public class GarnetIgniter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Igniter");
            Tooltip.SetDefault("25% Chance to do not consume Ammo"
            + "\nInflicts Garnet Wither to enemies");
        }

        public override void SetDefaults()
        {
            item.damage = 39;
            item.crit = 5;
            item.ranged = true;
            item.width = 56;
            item.height = 16;
            item.useTime = 6;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0.4f;
            item.value = 42500;
            item.rare = 4;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GarnetFlame");
            item.shootSpeed = 7.5f;
            item.useAmmo = AmmoID.Gel;       //Restrict the type of ammo the weapon can use, so that the weapon cannot use other ammos
            item.flame = true;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return (Main.rand.NextFloat() >= .25f && player.itemAnimation >= player.itemAnimationMax - 4);
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

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 16);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
