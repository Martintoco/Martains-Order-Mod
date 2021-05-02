using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Extra
{
    public class ForestBiomeFlask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forest Biome Flask");
            Tooltip.SetDefault("Spreads Purity");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.useTime = 120;
            item.useAnimation = 120;
            item.useStyle = 1;
            item.knockBack = 3.7f;
            item.scale = 1f;
            item.value = 50000;
			item.maxStack = 30;
            item.rare = -12;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item18;
			item.consumable = true;
            item.shoot = mod.ProjectileType("ForestBiomeFlask");
            item.shootSpeed = 9f;
            item.noMelee = true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenSolution, 100);
			recipe.AddIngredient(mod.ItemType("MachinedTechCap"), 2);
			recipe.AddIngredient(ItemID.LunarOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
	
	public class FillerBiomeFlask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Filler Biome Flask");
            Tooltip.SetDefault("Spreads Purity across the Void");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.useTime = 120;
            item.useAnimation = 120;
            item.useStyle = 1;
            item.knockBack = 3.7f;
            item.scale = 1f;
            item.value = 50000;
			item.maxStack = 30;
            item.rare = -12;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item18;
			item.consumable = true;
            item.shoot = mod.ProjectileType("FillerBiomeFlask");
            item.shootSpeed = 9f;
            item.noMelee = true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FillerSolution"), 100);
			recipe.AddIngredient(mod.ItemType("MachinedTechCap"), 2);
			recipe.AddIngredient(ItemID.LunarOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
