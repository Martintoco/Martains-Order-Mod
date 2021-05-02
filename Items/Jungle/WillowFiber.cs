using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Jungle
{
    public class WillowFiber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Willow Fiber");
			Tooltip.SetDefault("'Somehow dry between all the mud'");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 10;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 999;
            item.width = 28;
            item.height = 28;
            item.rare = 0;
            item.value = 4;
        }
    }
}
