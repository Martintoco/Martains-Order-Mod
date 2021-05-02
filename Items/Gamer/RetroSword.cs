using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Gamer
{
    public class RetroSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("8-bit Sword");
            //Tooltip.SetDefault("Usable in different types of 'swoosh'");
        }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.melee = true;
			item.crit = 4;
            item.width = 44;
            item.height = 44;
            item.scale = 1f;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 1;
            item.knockBack = 5f;
            item.value = 50000;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }
    }
	
	public class RetroStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("8-bit Staff");
            //Tooltip.SetDefault("Usable in different types of 'swoosh'");
        }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.magic = true;
			item.mana = 7;
			item.crit = 4;
            item.width = 44;
            item.height = 44;
            item.scale = 1f;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
			Item.staff[item.type] = true;
            item.knockBack = 4.5f;
            item.value = 50000;
            item.rare = 1;
            item.UseSound = SoundID.Item43;
            item.autoReuse = false;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("RetroBolt");
			item.shootSpeed = 7f;
        }
    }
	
	public class RetroBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("8-bit Bow");
            Tooltip.SetDefault("Shoots 8-bit Arrows instead");
        }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.ranged = true;
			item.crit = 4;
            item.width = 28;
            item.height = 48;
            item.scale = 1f;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 5;
            item.knockBack = 5f;
            item.value = 50000;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("RetroArrow");
            item.shootSpeed = 7.5f;
			item.ammo = AmmoID.Arrow;
        }
    }
	
	public class RetroScepter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("8-bit Scepter");
            //Tooltip.SetDefault("Usable in different types of 'swoosh'");
        }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.summon = true;
			item.mana = 5;
			item.crit = 4;
            item.width = 32;
            item.height = 44;
            item.scale = 1f;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 4;
            item.knockBack = 4.5f;
            item.value = 50000;
            item.rare = 1;
            item.UseSound = SoundID.Item44;
            item.autoReuse = false;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("RetroBlock");
            item.shootSpeed = 0f;
        }
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            return true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
    }
	
	public class RetroCluster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("8-bit Cluster");
            //Tooltip.SetDefault("Usable in different types of 'swoosh'");
        }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.thrown = true;
			item.crit = 4;
            item.width = 36;
            item.height = 36;
            item.scale = 1f;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 1;
            item.knockBack = 4f;
            item.value = 50000;
            item.rare = 1;
            item.UseSound = SoundID.Item19;
            item.autoReuse = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("RetroCluster");
            item.shootSpeed = 8f;
        }
    }
	
	public class RetroChopper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("8-bit Chopper");
            //Tooltip.SetDefault("Usable in different types of 'swoosh'");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
			item.crit = 4;
            item.width = 40;
            item.height = 40;
            item.scale = 1f;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 1;
            item.knockBack = 4.5f;
            item.value = 50000;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("RetroChopper");
            item.shootSpeed = 9f;
        }
		public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}