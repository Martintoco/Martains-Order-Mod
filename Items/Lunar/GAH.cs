using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MartainsOrder.Items.Lunar
{
    [AutoloadEquip(EquipType.Head)]
    public class GAH : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Helm");
            Tooltip.SetDefault("Increases Life and mana Regeneration"
			+ "\n+50 maximun mana, +2 max Minions"
            + "\n3% Increased damage reduction");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 26;
            item.value = 70000;
            item.rare = 10;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 1;
			player.manaRegen += 2;
			player.statManaMax2 += 50; player.maxMinions += 2;
			player.endurance += 0.03f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GAB") && legs.type == mod.ItemType("GAL");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = ("+45 maximun health"
			+ "\nAllows the player to teleport via worm hole by pressing"
            + "\nboth Left and Right Clicks, with a cooldown of 10 seconds");
			player.statLifeMax2 += 45;
			player.GetModPlayer<MyPlayer>().galaxyBonus = true;
        }
		
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor) {
			color.R = Utils.Clamp<byte>(color.R, 185, 255); color.G = Utils.Clamp<byte>(color.G, 185, 255); color.B = Utils.Clamp<byte>(color.B, 185, 255);
			shadow = 0.5f;
			
		}
    }
}