using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    public class GarnetCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Core");
            Tooltip.SetDefault("Increases Critical strike chance by 4%"
			+"\nwhile the player is Not on Max Health."
			+"\nProvides immunity to Garnet Wither"
			+"\nReduces Damage taken by 2%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.accessory = true;
            item.value = 27575;
            item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			if (player.statLife < player.statLifeMax)
            {
				player.AddBuff(mod.BuffType("GarnetCoreBuff"), 1);
			}
			player.buffImmune[mod.BuffType("GarnetCurse")] = true;
			player.endurance += 0.02f;
        }
    }
}
