using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Cook
{
    public class Baguette : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Baguette");
            Tooltip.SetDefault("''Tasty short sword''"
            + "\nBoosts Speed, Life regen and Defense by 5% upon use");
        }

        public override void SetDefaults()
        {
            item.damage = 11;
            item.width = 36;
            item.height = 36;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 3;
            item.knockBack = 12f;
            item.value = 10000;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.buffType = mod.BuffType("BaguetteBuff");
            item.buffTime = 120;
            item.useTurn = true;
        }
    }
}