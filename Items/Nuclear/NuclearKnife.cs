using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Nuclear
{
    public class NuclearKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nuclear Knife");
            Tooltip.SetDefault("Nuclear razor Sharps");
        }

        public override void SetDefaults()
        {
            item.damage = 92;
            item.thrown = true;
            item.width = 26;
            item.height = 34;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noMelee = true;
            item.consumable = true;
            item.maxStack = 999;
            item.knockBack = 8f;
            item.noUseGraphic = true;
            item.value = 175;
            item.rare = 7;
            item.UseSound = SoundID.Item19;
            item.shoot = mod.ProjectileType("NuclearKnife");
            item.shootSpeed = 14f;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("NuclearWaste"), 1);
            recipe.AddTile(mod.TileType("Processor"));
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
        }
    }
}