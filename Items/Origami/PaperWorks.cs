using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Origami
{
    public class PaperWorks : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Works");
            Tooltip.SetDefault("Makes rockets inflict burning and emit light");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 32;
            item.accessory = true;
            item.value = 8000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().paperWorks = true;
        }
		
    }
}
