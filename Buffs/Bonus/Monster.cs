using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MartainsOrder.Buffs.Bonus
{
    public class Monster : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bloodthirst Monster");
            Description.SetDefault("Hunt, kill your victims");
        	Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer p = player.GetModPlayer<MyPlayer>();

			// We use blockyAccessoryPrevious here instead of blockyAccessory because UpdateBuffs happens before UpdateEquips but after ResetEffects.
			if (player.statLife < (player.statLifeMax/4) && p.monsterAccPrev) {
				p.monsterPower = true;
				player.statDefense += 15;
				player.allDamage +=  0.15f;
				player.endurance += 0.10f;
				player.moveSpeed += 0.25f;
				player.lifeRegen += 1;
				player.manaRegen += 1;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
    }
	
	public class Nimbus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Nimbu-sapien");
            Description.SetDefault("Raining and agile, just like a cloud");
        	Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer p = player.GetModPlayer<MyPlayer>();
			
			if (player.ZoneRain && p.nimbusAccPrev) {
				p.nimbusPower = true;
				player.moveSpeed += 0.25f;
				player.runAcceleration += 0.10f;
				Player.jumpHeight += 5;
				Player.jumpSpeed += 0.75f;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
    }
	
	public class Florian : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Florian");
            Description.SetDefault("Rise for the sun with energy and joy!");
        	Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer p = player.GetModPlayer<MyPlayer>();
			
			if (Main.dayTime && p.florianAccPrev) {
				p.florianPower = true;
				player.lifeRegen += 1;
				player.manaRegen += 1;
				player.runAcceleration += 0.15f;
				player.meleeSpeed += 0.15f;
				p.summonSpeed += 0.10f;
				player.thrownVelocity += 0.15f;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
    }
}
