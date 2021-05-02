using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumHamAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum HamAxe");
        }

        public override void SetDefaults()
        {
            item.damage = 26;
            item.melee = true;
            item.crit = 5;
            item.width = 46;
            item.height = 46;
            item.scale = 1.30f;
            item.useTime = 13;
            item.useAnimation = 22;
            item.axe = 21;
            item.hammer = 75;
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
            recipe.AddIngredient(mod.ItemType("TantalumBar"), 12);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}