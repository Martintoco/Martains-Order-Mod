using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class Fragtal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cracktal");
			Tooltip.SetDefault("'Glittering cluster madness'");
        }

        public override void SetDefaults()
        {
            item.damage = 129;
            item.crit = 9;
            item.thrown = true;
            item.width = 30;
            item.height = 30;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 7.3f;
            item.noUseGraphic = true;
            item.value = 100000;
            item.rare = 10;
            item.UseSound = SoundID.Item19;
            item.shoot = mod.ProjectileType("Fragtal");
            item.shootSpeed = 8.0f;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}