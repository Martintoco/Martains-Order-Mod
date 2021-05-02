using Terraria.ModLoader;

namespace MartainsOrder.Items.Gamer.Vanities
{
    [AutoloadEquip(EquipType.Head)]
    public class RetroMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RetroSpecter Mask");
            Tooltip.SetDefault("'The Snok himself'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 35000;
            item.rare = 9;
            item.vanity = true;
        }

    }
}