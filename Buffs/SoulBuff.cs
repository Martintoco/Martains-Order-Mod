using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MartainsOrder.Buffs
{
    public class SoulBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Soul Power");
            Description.SetDefault("Increased All Stats by 1%"
			+"\n'Canalize all your will into power'");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //player.hairColor = Color.White;
            player.blockRange += 1;
            player.lifeRegen += 1;
            player.statManaMax2 += 1;
            player.maxMinions += 1;
            player.allDamage += 0.01f;
            player.statLifeMax2 += 1;
            player.moveSpeed += 0.01f;
            player.manaRegen += 1;
			player.statDefense += 1;
			player.endurance += 0.01f;
            player.breathCD += 1;
			player.meleeSpeed += 0.01f;
			player.thrownVelocity += 0.01f;
			player.pickSpeed += 0.01f;
			player.meleeCrit += 1;
			player.magicCrit += 1;
			player.rangedCrit += 1;
			player.thrownCrit += 1;
			player.GetModPlayer<MyPlayer>().whipExtraRange += 0.01f;
			player.GetModPlayer<MyPlayer>().summonTagCrit += 1;
        }
    }
}
