using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    public class GarnetWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Dual Whip");
            Tooltip.SetDefault("8 Summon Tag Damage"
            + "\nDamage reduced by 25% each hit in a single swing"
            + "\nWhips up to 2 at a time"
            + "\nInflicts Garnet Wither to enemies");
        }

        public override void SetDefaults()
        {
            item.damage = 32;
            item.crit = 7;
            item.summon = true;
            item.width = 28;
            item.height = 26;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 1;
            item.knockBack = 2f;
            item.scale = 1f;
            item.value = 42500;
            item.rare = 4;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item18;
            item.shoot = mod.ProjectileType("Nule"); //GarnetWhipWhip
            item.autoReuse = true;
            item.shootSpeed = 4.57f;//(4.43f*1.75f);
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[mod.ProjectileType("GarnetWhipWhip")] < 2;
        }

        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, (0.625f * Main.rand.Next(-2, 3) + Main.rand.Next(-1, 2)), (0.625f * Main.rand.Next(-2, 3) + Main.rand.Next(-1, 2)), item.shoot, damage, knockBack, player.whoAmI);

            return true;
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2;
            float rotation = MathHelper.ToRadians(20);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .5f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("GarnetWhipWhip"), damage, knockBack, player.whoAmI);
            }
            return true;
        }*/
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			item.useTime = item.useAnimation = Main.rand.Next(33,38);
			
            int numberProjectiles = 2; // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(60));
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("GarnetWhipWhip"), damage, knockBack, player.whoAmI);
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 12);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}