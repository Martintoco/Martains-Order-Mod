using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MartainsOrder.Items.Lunar
{
    [AutoloadEquip(EquipType.Body)]
    public class LFAB : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Fractal CoatPlate");
            Tooltip.SetDefault("Increases Thowing Damage by 20%"
            + "\nAttackers take half the damage");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.value = 140000;
            item.rare = 10;
            item.defense = 25;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.20f;
            player.thorns += 0.5f;
            player.armorEffectDrawShadowEOCShield = true;
        }
		
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor) {
			color.R = Utils.Clamp<byte>(color.R, 185, 255); color.G = Utils.Clamp<byte>(color.G, 185, 255); color.B = Utils.Clamp<byte>(color.B, 185, 255);
			shadow = 0.5f;
		}

        /*public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(mod.ItemType("LuminiteFragment"), 27);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
    }
}