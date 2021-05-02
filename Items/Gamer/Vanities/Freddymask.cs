using Terraria.ModLoader;

namespace MartainsOrder.Items.Gamer.Vanities
{
    [AutoloadEquip(EquipType.Head)]
    public class Freddymask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freddy Mask");
            Tooltip.SetDefault("'Is this what you wanna be?'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 26;
            item.value = 37500;
            item.rare = 10;
            item.vanity = true;
        }

    }
}