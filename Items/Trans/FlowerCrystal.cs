using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.ID;

namespace MartainsOrder.Items.Trans
{
	public class FlowerCrystal : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flower Crystal");
            Tooltip.SetDefault("Turns the holder into a florian at day");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.accessory = true;
            item.value = 60000;
            item.rare = 4;
        }

		public override void UpdateAccessory(Player player, bool hideVisual) {
			MyPlayer p = player.GetModPlayer<MyPlayer>();
			p.florianAcc = true;
			if (hideVisual) {
				p.florianHideVanity = true;
			}
		}
	}

	public class FlorianHead : EquipTexture
	{
		public override bool DrawHead() {
			return false;
		}

		public override void UpdateVanity(Player player, EquipType type) {
			//if (Main.rand.NextBool(20)) {
			//	Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Sparkle>());
			//}
		}
	}

	public class FlorianBody : EquipTexture
	{
		public override bool DrawBody() {
			return false;
		}
	}

	public class FlorianLegs : EquipTexture
	{
		public override bool DrawLegs() {
			return false;
		}
	}
}