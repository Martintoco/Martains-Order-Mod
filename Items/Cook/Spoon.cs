using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Cook
{
    public class Spoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spoon");
        }

        public override void SetDefaults()
        {
            item.damage = 13;
            item.crit = 5;
            item.melee = true;
            item.width = 35;
            item.height = 35;
            item.useTime = 2;
            item.useAnimation = 20;
            item.pick = 20;
            item.useStyle = 2;
            item.knockBack = 6.25f;
            item.scale = 1.2f;
            item.tileBoost += 3;
            item.value = 3000;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
    }
}