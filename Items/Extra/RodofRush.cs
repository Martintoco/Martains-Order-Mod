using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Extra
{
    public class RodofRush : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rod of Rushflow");
            Tooltip.SetDefault("Makes time flow faster");
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
            recipe.AddIngredient(ItemID.Leather, 10);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(mod.ItemType("VoidSoul"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            if(MartainWorld.timeRush == true) {
				MartainWorld.timeRush = false;
				Main.NewText("Time neutralized", 175, 255, 200, false);
			}
			else {
				MartainWorld.timeRush = true;
				MartainWorld.timeStop = false;
				Main.NewText("Time accelerated", 175, 255, 200, false);
			}
            return true;
        }
    }
}
