using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    public class ZincArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Arrow");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.crit = 6;
            item.ranged = true;
            item.width = 52;
            item.height = 32;
            item.consumable = true;
            item.maxStack = 999;
            item.knockBack = 4f;
            item.value = 90;
            item.rare = 2;
            item.shoot = mod.ProjectileType("ZincArrow");
            item.shootSpeed = 5f;
            item.ammo = 40;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ZincBar"), 1);
            recipe.AddIngredient(ItemID.WoodenArrow, 100);
            recipe.AddTile(16);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
	
	public class ZincBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Bullet");
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.crit = 5;
            item.ranged = true;
            item.width = 52;
            item.height = 32;
            item.consumable = true;
            item.maxStack = 999;
            item.knockBack = 3f;
            item.value = 90;
            item.rare = 2;
            item.shoot = mod.ProjectileType("ZincBullet");
            item.shootSpeed = 5f;
            item.ammo = 97;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ZincBar"), 1);
            recipe.AddIngredient(ItemID.MusketBall, 100);
            recipe.AddTile(16);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}