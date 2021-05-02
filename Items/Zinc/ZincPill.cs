using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    public class ZincPill : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Pill");
            Tooltip.SetDefault("Increases Defense and Damage Reduction by 2%"
			+ "\nGives temporal immunity to Fracture");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 1;
            item.value = 3750;
            item.buffType = mod.BuffType("ZincPillBuff");
            item.buffTime = 3600*5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledHoney, 1);
            recipe.AddIngredient(mod.ItemType("ZincOre"), 2);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}