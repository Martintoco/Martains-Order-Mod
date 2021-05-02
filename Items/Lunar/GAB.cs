using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MartainsOrder.Items.Lunar
{
    [AutoloadEquip(EquipType.Body)]
    public class GAB : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Galaxy BreastPlate");
            Tooltip.SetDefault("Increases Damage by 15%"
			+ "\n+35 maximun health"
			+ "\nEnemies are more likely to target you"
			+ "\n3% Increased damage reduction");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.value = 140000;
            item.rare = 10;
            item.defense = 24;
        }

        public override void UpdateEquip(Player player)
        {
			player.allDamage += 0.15f;
			player.statLifeMax2 += 35;
			player.aggro += 200;
			player.endurance += 0.03f;
        }
		
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor) {
			color.R = Utils.Clamp<byte>(color.R, 185, 255); color.G = Utils.Clamp<byte>(color.G, 185, 255); color.B = Utils.Clamp<byte>(color.B, 185, 255);
			shadow = 0.5f;
		}
		
    }
}