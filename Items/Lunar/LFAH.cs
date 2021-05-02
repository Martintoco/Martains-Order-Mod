using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MartainsOrder.Items.Lunar
{
    [AutoloadEquip(EquipType.Head)]
    public class LFAH : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fractal Mask");
            Tooltip.SetDefault("Increases Life Regeneration"
            + "\nIncreases Throwing velocity by 35%");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 26;
            item.value = 70000;
            item.rare = 10;
            item.defense = 21;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 2;
            player.thrownVelocity += 0.35f;
            player.armorEffectDrawShadowEOCShield = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("LFAB") && legs.type == mod.ItemType("LFAL");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = ("Armor penetration increased by 15"
            + "\nFractal spikes shoot out from the player while in rush"
			+ "\nThe spikes deal a half of the Player's throwing weapon Damage");
			player.armorPenetration += 15;
            player.GetModPlayer<MyPlayer>().fractalShardsBonus = true;
			/*if (player.statLife >= (player.statLifeMax) / 2)
            {
                player.AddBuff(mod.BuffType("LFMaxBuff"), 1);
            }
            if (player.statLife <= (player.statLifeMax) / 2)
            {
                player.AddBuff(mod.BuffType("LFHalfBuff"), 1);
            }*/
        }
		
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor) {
			color.R = Utils.Clamp<byte>(color.R, 185, 255); color.G = Utils.Clamp<byte>(color.G, 185, 255); color.B = Utils.Clamp<byte>(color.B, 185, 255);
			shadow = 0.5f;
			//glowMask = 28;
			//glowMaskColor = new Color(50,250,50,0);
		}

        /*public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 6);
			recipe.AddIngredient(mod.ItemType("LuminiteFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
    }
}