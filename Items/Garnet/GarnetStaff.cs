using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    public class GarnetStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Staff");
            Tooltip.SetDefault("Casts Explosive bolts"
            + "\nInflicts Garnet Wither to enemies");
        }

        public override void SetDefaults()
        {
            item.damage = 43;
            item.crit = 8;
            item.magic = true;
            item.mana = 8;
            item.width = 42;
            item.height = 42;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 6.5f;
            item.value = 42500;
            item.rare = 4;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GarnetBolt");
            item.shootSpeed = 9.4f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, 4);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 15);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
