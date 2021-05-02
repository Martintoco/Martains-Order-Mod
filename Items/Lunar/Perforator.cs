using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class Perforator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Perforator");
            Tooltip.SetDefault("'Flashing spears that tear through everything'");
        }

        public override void SetDefaults()
        {
            item.damage = 137;
            item.crit = 10;
            item.thrown = true;
            item.width = 50;
            item.height = 50;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 6.6f;
            item.noUseGraphic = true;
            item.value = 100000;
            item.rare = 10;
            item.UseSound = SoundID.Item19;
            item.shoot = mod.ProjectileType("Perforator");
            item.shootSpeed = 15.75f;
            item.autoReuse = true;
        }
    }
}
