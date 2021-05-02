using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    public class ZincOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Ore");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 59;
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
            item.createTile = mod.TileType("ZincOre");
            item.width = 12;
            item.height = 12;
            item.rare = 2;
            item.value = 500;
        }
    }
}
