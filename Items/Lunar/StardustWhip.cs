using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class StardustWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shooting Star");
            Tooltip.SetDefault("Tags enemies with Star Constelation for 10 seconds"
            + "\nEnemies with the effect spawn explosive Stars"
            + "\n7% Tag critical chance"
            + "\nDamage reduced by 11% each hit in a single swing"
			+ "\n'Space never looked so beautiful'");
        }

        public override void SetDefaults()
        {
            item.damage = 64;
            item.crit = 11;
            item.summon = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;
            item.knockBack = 3.8f;
            item.scale = 1f;
            item.value = 100000;
            item.rare = 10;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item18;
            item.shoot = mod.ProjectileType("StardustWhip");
            item.shootSpeed = 7.17f;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			item.useTime = item.useAnimation = Main.rand.Next(34,39);
            return true;
        }
    }
}