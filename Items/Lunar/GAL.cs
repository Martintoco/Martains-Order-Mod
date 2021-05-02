using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MartainsOrder.Items.Lunar
{
    [AutoloadEquip(EquipType.Legs)]
    public class GAL : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Trousers");
            Tooltip.SetDefault("Increases Movement speed by 30%"
			+ "\nIncreses Movement acceleration by 25%"
			+ "\nIncreased Jump speed"
            + "\n3% Increased damage reduction");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = 105000;
            item.rare = 10;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.35f;
            player.runAcceleration += 0.25f;
			Player.jumpSpeed += 0.75f;
			player.endurance += 0.03f;
        }
		
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor) {
			color.R = Utils.Clamp<byte>(color.R, 185, 255); color.G = Utils.Clamp<byte>(color.G, 185, 255); color.B = Utils.Clamp<byte>(color.B, 185, 255);
			shadow = 0.5f;
		}

        /*public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(mod.ItemType("LuminiteFragment"), 21);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
    }
}