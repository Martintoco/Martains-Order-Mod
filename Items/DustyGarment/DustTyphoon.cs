using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.DustyGarment
{
    public class DustTyphoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dust Typhoon");
            Tooltip.SetDefault("Emits damaging dusts while in rush");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.accessory = true;
            item.value = 9000;
            item.rare = 3;
        }
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			if(player.GetModPlayer<MyPlayer>().dustTyphoon < 1)player.GetModPlayer<MyPlayer>().dustTyphoon = 1;
        }
		
    }
}
