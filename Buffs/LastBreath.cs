using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MartainsOrder.Buffs
{
    public class LastBreath : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Last Breath");
            Description.SetDefault("Stay Alive! Give it all!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.15f;
			player.lifeRegen += 2;
			player.meleeCrit += 10;
			player.magicCrit += 10;
			player.rangedCrit += 10;
			player.thrownCrit += 10;
			player.GetModPlayer<MyPlayer>().summonTagCrit += 10;
			player.endurance += 0.05f;
        }
    }
}
