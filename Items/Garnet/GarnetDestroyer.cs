using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    public class GarnetDestroyer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Destroyer");
            Tooltip.SetDefault("Inflicts Garnet Wither to enemies");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.melee = true;
            item.crit = 11;
            item.width = 54;
            item.height = 28;
            item.useTime = 6;
            item.useAnimation = 15;
            item.channel = true;
            item.noMelee = true;
            item.pick = 200;
            item.axe = 22;
            item.hammer = 80;
            //item.tileBoost++;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.knockBack = 7f;
            item.value = 42500;
            item.rare = 4;
            item.UseSound = SoundID.Item23;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GarnetDestroyer");
            item.shootSpeed = 32.5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 18);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}