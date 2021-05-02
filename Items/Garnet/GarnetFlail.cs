using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    public class GarnetFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Flail");
            Tooltip.SetDefault("Faster than the usual flail"
            + "\nInflicts Garnet Wither to enemies");
        }

        public override void SetDefaults()
        {
            item.damage = 48;
            item.crit = 11;
            item.knockBack = 8f;
            item.melee = true;
            item.width = 38;
            item.height = 34;
            item.rare = 4;
            item.noMelee = true;
            item.useStyle = 5;
            item.useAnimation = 20;
            item.useTime = 20;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("GarnetFlail");
            item.value = 42500;
            item.shootSpeed = 15.2f;
            item.UseSound = SoundID.Item1;
            item.channel = true;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 17);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}