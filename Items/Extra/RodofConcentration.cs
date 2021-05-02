using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Extra
{
    public class RodofConcentration : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rod of Concentration");
            Tooltip.SetDefault("Stops the flow of time");
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
            recipe.AddIngredient(ItemID.Gel, 10);
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(mod.ItemType("VoidSoul"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            if(MartainWorld.timeStop == true) {
				MartainWorld.timeStop = false;
				Main.NewText("Time resumed", 175, 200, 255, false);
			}
			else {
				MartainWorld.timeStop = true;
				MartainWorld.timeRush = false;
				Main.NewText("Time stopped", 175, 200, 255, false);
			}
            return true;
        }
    }
}
