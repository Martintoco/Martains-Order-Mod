using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    public class ZincHamAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Hamaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.melee = true;
            item.crit = 7;
            item.width = 36;
            item.height = 36;
            item.scale = 1.25f;
            item.useTime = 14;
            item.useAnimation = 24;
            item.axe = 20;
            item.hammer = 65;
            item.useStyle = 1;
            item.knockBack = 7f;
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