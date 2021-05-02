using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    public class ZincPick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Pickaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 17;
            item.melee = true;
            item.crit = 5;
            item.width = 34;
            item.height = 34;
            item.scale = 1f;
            item.useTime = 13;
            item.useAnimation = 18;
            item.pick = 105;
            item.useStyle = 1;
            item.knockBack = 5f;
            item.value = 29000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ZincBar"), 20);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}