using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class RecursiveNailers : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Recursive Nailers");
            Tooltip.SetDefault("'Recurse into a infinite loop'");
        }

        public override void SetDefaults()
        {
			item.damage = 79;
			item.thrown = true;
			item.width = 30;
            item.height = 24;
            item.useTime = 15;
            item.useAnimation = 15;
			item.noMelee = true;
            item.consumable = true;
            item.maxStack = 999;
			item.knockBack = 4f;
			item.useStyle = 1;
			item.UseSound = SoundID.Item39;
			item.noUseGraphic = true;
			item.autoReuse = true;
            item.value = 25;
            item.rare = 10;
            item.shoot = mod.ProjectileType("RecursiveNailers");
			item.shootSpeed = 8.5f;
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return true;
        }
    }
}