using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Extra
{
    public class FishyumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fishyum Ore");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = mod.TileType("FishyumOre");
            item.width = 12;
            item.height = 12;
            item.rare = -12;
            item.value = 6000;
        }
    }
}
