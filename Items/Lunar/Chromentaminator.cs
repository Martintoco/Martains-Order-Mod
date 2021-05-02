using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class Chromentaminator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chromentaminator");
            Tooltip.SetDefault("80% Chance to do not consume Ammo"
            + "\nCreates and destroys biomes when sprayed"
			+ "\nShoots additional homing projectiles"
            + "\nUses colored solution");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Clentaminator);
            item.width = 58;
            item.height = 22;
            item.value = 100000;
            item.rare = 10;
			item.damage = 57;
			item.crit = 3;
            item.shootSpeed = 13.75f;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .75f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            for (int i = 0; i < 2; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(35));
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("GalaxyChroma"), damage, knockBack, player.whoAmI);
            }
            return true;
        }
    }
}