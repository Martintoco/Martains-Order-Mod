using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Gamer.Vanities
{
    [AutoloadEquip(EquipType.Head)]
    public class Crewmember : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crewmember Suit");
            Tooltip.SetDefault("'U sus'");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = 50000;
            item.rare = 6;
            item.vanity = true;
        }
    }
}