using Terraria.ModLoader;

namespace MartainsOrder.Items.Gamer.Vanities
{
    [AutoloadEquip(EquipType.Head)]
    public class WitherSkeletonMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("WitherSkeleton Head");
            Tooltip.SetDefault("'ey Ey EY'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 37500;
            item.rare = 11;
            item.vanity = true;
        }

    }
}