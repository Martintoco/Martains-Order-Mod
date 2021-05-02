using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class SolarEclipse : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Eclipse");
			Tooltip.SetDefault("It's velocity scales with melee speed"
			+ "\n'Flail into battle along the Sunset'");

            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 148;
            item.crit = 10;
            item.useStyle = 5;
            item.width = 32;
            item.height = 26;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 17f;
            item.knockBack = 3f;
            item.rare = 10;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item1;
            item.value = 100000;
            item.shoot = mod.ProjectileType("SolarEclipse");
        }
		
    }
}
