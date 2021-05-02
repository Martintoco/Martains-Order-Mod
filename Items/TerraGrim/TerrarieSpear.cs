using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.TerraGrim
{
    public class TerrarieSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terrarie Spear");
            Tooltip.SetDefault("Unleashes multiple magic strikes");
        }

        public override void SetDefaults()
        {
            item.damage = 17;
            item.magic = true;
			item.mana = 2;
            item.crit = 4;
            item.width = 32;
            item.height = 32;
            item.useTime = 6;
            item.useAnimation = 6;
            item.useStyle = 5;
            item.knockBack = 2.75f;
            item.scale = 1.1f;
			item.noMelee = true;
            item.value = 100000;
            item.rare = 2;
            item.UseSound = SoundID.Item8;
            item.shoot = mod.ProjectileType("Nule");
            item.shootSpeed = 14.0f;
            item.autoReuse = true;
            item.useTurn = false;
            Item.staff[item.type] = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X + Main.rand.Next(-55, 56), position.Y + Main.rand.Next(-55, 56), speedX, speedY, mod.ProjectileType("TerrarieSpear"), damage, knockBack, player.whoAmI);
            return true;
        }
    }
	
	public class CurvedAbyssinian : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Curved Abyssinian");
            Tooltip.SetDefault("Throws a fast spinning shotel");
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.thrown = true;
            item.crit = 4;
            item.width = 32;
            item.height = 30;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 3.25f;
            item.scale = 1f;
			item.noMelee = true;
			item.noUseGraphic = true;
            item.value = 100000;
            item.rare = 2;
            item.UseSound = SoundID.Item19;////////////////////////////////////////////////77
            item.shoot = mod.ProjectileType("CurvedAbyssinian");
            item.shootSpeed = 9.0f;
            item.autoReuse = true;
            item.useTurn = false;
            Item.staff[item.type] = true;
        }
    }
	
	public class MelioArcus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Melio Arcus");
			Tooltip.SetDefault("Casts a magic bow that shoots a grim-flash arrow, instead");
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.crit = 4;
            item.ranged = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 11;
            item.useAnimation = 11;
            item.useStyle = 5;
            item.noMelee = true;
			item.noUseGraphic = true;
            item.knockBack = 3f;
            item.value = 100000;
            item.rare = 2;
            item.UseSound = SoundID.Item13;
            item.autoReuse = true;
            item.shoot = AmmoID.Arrow;
            item.shootSpeed = 11.5f;
            item.useAmmo = AmmoID.Arrow;
        }
		
		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        { 
            mult *= player.arrowDamage;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			type = mod.ProjectileType("Nule");
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
			
			int numberProjectiles = 1;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                    float scale = 1f - (Main.rand.NextFloat() * .1f);
                    perturbedSpeed = perturbedSpeed * scale;
					perturbedSpeed*=0.6f;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("MelioArcus"), damage, knockBack, player.whoAmI);
                }
			return true;
        }
    }
	
	public class StarFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star flail");
            Tooltip.SetDefault("2 Summon Tag Damage"
			+ "\n3% Tag critical chance"
            + "\nDamage reduced by 47% each hit in a single swing");
        }

        public override void SetDefaults()
        {
            item.damage = 6;
            item.crit = 3;
            item.summon = true;
            item.melee = false;
            item.width = 36;
            item.height = 32;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 1;
            item.knockBack = 0.5f;
            item.scale = 1f;
            item.value = 100000;
            item.rare = 2;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item18;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("StarFlailWhip");
            item.shootSpeed = 4.49f;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			item.useTime = item.useAnimation = Main.rand.Next(21,26);
            return true;
        }
    }
}