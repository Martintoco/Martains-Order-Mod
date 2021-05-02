using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    public class GarnetJavelin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Javelin");
            Tooltip.SetDefault("Inflicts Garnet Wither to enemies");
        }

        public override void SetDefaults()
        {
            item.damage = 44;
            item.thrown = true;
            item.crit = 5;
            item.width = 44;
            item.height = 44;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 1;
            item.noMelee = true;
            item.consumable = true;
            item.maxStack = 999;
            item.knockBack = 7f;
            item.noUseGraphic = true;
            item.value = 425;
            item.rare = 4;
            item.UseSound = SoundID.Item19;
            item.shoot = mod.ProjectileType("GarnetJavelin");
            item.shootSpeed = 13.8f;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 1);
            recipe.AddTile(134);
            recipe.SetResult(this, 15);
            recipe.AddRecipe();
        }
    }
}