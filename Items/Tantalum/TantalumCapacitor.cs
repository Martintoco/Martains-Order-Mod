using MartainsOrder.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumCapacitor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Capacitor");
            Tooltip.SetDefault("Channels a Electricity Beam");
        }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.noMelee = true;
            item.magic = true;
            item.crit = 7;
            item.channel = true; //Channel so that you can held the weapon [Important]
            item.mana = 6;
            item.rare = 5;
            item.width = 28;
            item.height = 30;
            item.useTime = 30;
            item.knockBack = 1f;
            item.scale = 1.2f;
            item.UseSound = SoundID.Item13;
            item.useStyle = 5;
            item.shootSpeed = 14f;
            item.useAnimation = 30;
            item.shoot = ModContent.ProjectileType<TantalumCapacitorBeam>();
            item.value = 24500;
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
