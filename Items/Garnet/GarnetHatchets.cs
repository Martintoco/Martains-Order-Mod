using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    public class GarnetHatchets : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Chopper");
			Tooltip.SetDefault("Inflicts Garnet Wither to enemies");
        }

        public override void SetDefaults()
        {
            item.damage = 34;
            item.crit = 6;
            item.width = 32;
            item.height = 30;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 6f;
            item.scale = 1f;
            item.value = 42500;
            item.rare = 4;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("GarnetHatchet");
            item.shootSpeed = 12f;
            item.noUseGraphic = true;
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
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
