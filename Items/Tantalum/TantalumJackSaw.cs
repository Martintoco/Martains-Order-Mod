using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumJackSaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum JackSaw");
        }

        public override void SetDefaults()
        {
            item.damage = 25;
            item.melee = true;
            item.crit = 7;
            item.width = 50;
            item.height = 26;
            item.useTime = 5;
            item.useAnimation = 15;
            item.channel = true;
            item.noMelee = true;
            item.axe = 21;
            item.hammer = 75;
            //item.tileBoost++;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.knockBack = 6f;
            item.value = 25000;
            item.rare = 5;
            item.UseSound = SoundID.Item23;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TantalumJackSaw");
            item.shootSpeed = 25f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TantalumBar"), 12);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}