using Terraria.ModLoader;

namespace MartainsOrder.Items.Gamer.Vanities
{
    [AutoloadEquip(EquipType.Head)]
    public class RobloxMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Roblox Player Mask");
            Tooltip.SetDefault("'O O F'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 37050;
            item.rare = 8;
            item.vanity = true;
        }

    }
}