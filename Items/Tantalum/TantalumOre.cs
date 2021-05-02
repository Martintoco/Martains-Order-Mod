using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Ore");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 83;
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
            item.createTile = mod.TileType("TantalumOre");
            item.width = 12;
            item.height = 12;
            item.rare = 5;
            item.value = 1500;
        }
    }
}
