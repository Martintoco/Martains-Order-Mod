using Terraria.ModLoader;

namespace MartainsOrder.Items.Gamer.Vanities
{
    [AutoloadEquip(EquipType.Head)]
    public class DreamerMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dream's Mask");
            Tooltip.SetDefault("'I see a dreamer'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 35000;
            item.rare = 7;
            item.vanity = true;
        }

    }
}