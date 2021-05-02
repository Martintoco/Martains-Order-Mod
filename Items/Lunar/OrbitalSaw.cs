using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class OrbitalSaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orbital Saw");
			Tooltip.SetDefault("'Unleash the orbital power'");
        }
        public override void SetDefaults()
        {
            item.damage = 92;
            item.crit = 7;
            item.width = 50;
            item.height = 50;
            item.useTime = 7;
            item.useAnimation = 7;
            item.channel = true;
            item.useStyle = 1;
            item.knockBack = 0f;
            item.value = 100000;
            item.rare = 10;
			item.noMelee = true;
            item.shoot = mod.ProjectileType("OrbitalSaw");
            item.noUseGraphic = true;
            item.useTurn = true;
        }

        public override bool UseItemFrame(Player player)
        {
            player.bodyFrame.Y = 3 * player.bodyFrame.Height;
            return true;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(player.ownedProjectileCounts[mod.ProjectileType("OrbitalSaw2")] < 1)Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("OrbitalSaw2"), damage, knockBack, player.whoAmI);
			if(player.ownedProjectileCounts[mod.ProjectileType("OrbitalSaw3")] < 1)Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("OrbitalSaw3"), damage, knockBack, player.whoAmI);
            return true;
        }
    }
}