using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Cleric
{
    public class MushroomStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Cane");
			Tooltip.SetDefault("Can heal players or hit enemies"
			+ "\nHeals a third of the projectile's damage");
        }

        public override void SetDefaults()
        {
            item.damage = 9;
            item.magic = true;
            item.mana = 5;
            item.width = 36;
            item.height = 36;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 1.75f;
            item.value = 1250;
            item.rare = 1;
            item.UseSound = SoundID.Item43;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("MushroomBolt");
            item.shootSpeed = 5f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, 4);
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Mushroom, 3);
			recipe.AddIngredient(mod.ItemType("Herb"), 4);
			recipe.AddIngredient(ItemID.VineRope, 10);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
