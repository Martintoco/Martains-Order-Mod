using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class Galaxee : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxee");
			Tooltip.SetDefault("'Feel the waves of it's astral movement'");
        }

        public override void SetDefaults()
        {
            item.damage = 87;
            item.crit = 8;
            item.width = 36;
            item.height = 34;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 7f;
            item.scale = 1f;
            item.value = 100000;
            item.rare = 10;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("Galaxee");
            item.shootSpeed = 17f;
            item.noUseGraphic = true;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}
