using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.ID;

namespace MartainsOrder.Items.Trans
{
	public class NimbusMedal : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nimbus medal");
            Tooltip.SetDefault("Turns the holder into a nimbu-sapien when it's raining");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.accessory = true;
            item.value = 88000;
            item.rare = 6;
        }

		public override void UpdateAccessory(Player player, bool hideVisual) {
			MyPlayer p = player.GetModPlayer<MyPlayer>();
			p.nimbusAcc = true;
			if (hideVisual) {
				p.nimbusHideVanity = true;
			}
		}
	}

	public class NimbusHead : EquipTexture
	{
		public override bool DrawHead() {
			return false;
		}

		public override void UpdateVanity(Player player, EquipType type) {
			int dust = Dust.NewDust(player.position, player.width, player.height, 16, player.velocity.X * 0.25f, player.velocity.Y * 0.25f, 100, Color.LightGray, 1.4f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 1.5f;
		}
	}

	public class NimbusBody : EquipTexture
	{
		public override bool DrawBody() {
			return false;
		}
		
		public override void UpdateVanity(Player player, EquipType type) {
			int dust = Dust.NewDust(player.position, player.width, player.height, 16, player.velocity.X * 0.25f, player.velocity.Y * 0.25f, 100, Color.LightGray, 1.4f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 1.7f;
		}
	}

	public class NimbusLegs : EquipTexture
	{
		public override bool DrawLegs() {
			return false;
		}
		
		public override void UpdateVanity(Player player, EquipType type) {
			int dust = Dust.NewDust(player.position, player.width, player.height, 16, player.velocity.X * 0.25f, player.velocity.Y * 0.25f, 100, Color.LightGray, 1.4f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 1.6f;
		}
	}
}