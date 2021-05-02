using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.ID;

namespace MartainsOrder.Items.Trans
{
	public class EnragedBlood : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enraged Blood");
            Tooltip.SetDefault("Turns the holder into a bloodthrist monster"
			+ "\nwhen life is lower than a 25% health");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 28;
            item.accessory = true;
            item.value = 90000;
            item.rare = 6;
        }

		public override void UpdateAccessory(Player player, bool hideVisual) {
			MyPlayer p = player.GetModPlayer<MyPlayer>();
			p.monsterAcc = true;
			if (hideVisual) {
				p.monsterHideVanity = true;
			}
		}
	}

	public class MonsterHead : EquipTexture
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

	public class MonsterBody : EquipTexture
	{
		public override bool DrawBody() {
			return false;
		}
	}

	public class MonsterLegs : EquipTexture
	{
		public override bool DrawLegs() {
			return false;
		}
	}
}