using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Extra
{
    public class RodofTime : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rod of Timeline");
            Tooltip.SetDefault("Changes the phase of Time");
        }

        public override void SetDefaults()
        {
            item.mana = 15;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 5f;
            item.scale = 1f;
            item.value = 4000000;
            item.rare = -12;
            item.noMelee = true;
            item.UseSound = SoundID.Item8;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(mod.ItemType("VoidSoul"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            if (Main.dayTime)
            {
                Main.dayTime = false;
                Main.time = 0f;
				Main.NewText("Time set to night", 255, 200, 175, false);
            }
            else
            {
                Main.dayTime = true;
                Main.time = 0f;
				Main.NewText("Time set to day", 255, 200, 175, false);
            }
            return true;
        }
    }
}
