using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Pickaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.melee = true;
            item.crit = 5;
            item.width = 36;
            item.height = 36;
            item.scale = 1.05f;
            item.useTime = 13;
            item.useAnimation = 19;
            item.pick = 195;
            item.tileBoost += 2;
            item.useStyle = 1;
            item.knockBack = 5f;
            item.value = 25000;
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TantalumBar"), 13);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}