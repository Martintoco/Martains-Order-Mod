using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Gamer
{
    [AutoloadEquip(EquipType.Head)]
    public class Hatty : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hatty");
            Tooltip.SetDefault("Holding down the button will make it stay on place"
			+ "\nAlso allows the player to bounce on the hat"
			+ "\n'Let's do the Odyssey!'");
        }

        public override void SetDefaults()
        {
            item.damage = 25;
            item.crit = 10;
            item.melee = true;
            item.width = 32;
            item.height = 26;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 6f;
            item.scale = 1f;
            item.value = 20000;
            item.rare = 4;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("Hatty");
            item.shootSpeed = 7.75f;
            item.noUseGraphic = true;
            item.autoReuse = false;
            item.vanity = true;
			item.channel = true;
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}
