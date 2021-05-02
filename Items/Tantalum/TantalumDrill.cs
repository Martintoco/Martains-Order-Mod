using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumDrill : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Drill");
        }

        public override void SetDefaults()
        {
            item.damage = 23;
            item.melee = true;
            item.crit = 7;
            item.width = 50;
            item.height = 26;
            item.useTime = 5;
            item.useAnimation = 11;
            item.channel = true;
            item.noMelee = true;
            item.pick = 195;
            //item.tileBoost++;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.knockBack = 6f;
            item.value = 25000;
            item.rare = 5;
            item.UseSound = SoundID.Item23;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TantalumDrill");
            item.shootSpeed = 25f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TantalumBar"), 13);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}