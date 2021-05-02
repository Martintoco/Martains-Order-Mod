using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Extra
{
    public class FishyumRocket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rocket F");
            Tooltip.SetDefault("cohetiou"
			+ "\nMedium blast radius. Will not destroy tiles"
			+ "\nUsed by pressure-based rocket launchers");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(771);//RocketI
			item.damage = 26;
            item.crit += 4;
			//item.width += 0;
			//item.height += 0;
            item.ranged = true;
            item.consumable = true;
            item.maxStack = 999;
            item.knockBack = 4.5f;
            item.value = 7;
            item.rare = 11;
            item.shoot = mod.ProjectileType("FishyumRocket");
            item.shootSpeed += 0.5f;
			item.ammo = mod.ItemType("CoalRocket");
        }
    }
}