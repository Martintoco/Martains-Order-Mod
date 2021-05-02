using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MartainsOrder.Buffs.Bonus
{
    public class GarnetCoreBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Garnet Unleash");
            Description.SetDefault("Increased Critical strike chance by 4%"
			+ "\nIncreased Tag critical chance by 4%");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeCrit += 4;
			player.magicCrit += 4;
			player.rangedCrit += 4;
			player.thrownCrit += 4;
			player.GetModPlayer<MyPlayer>().summonTagCrit += 4;
        }
    }
	
	public class InnerPeaceBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Inner Peace Unleash");
            Description.SetDefault("Increased Critical strike chance by 4%"
			+ "\nIncreased Tag critical chance by 4%"
			+ "\nEnemies are less likely to target you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeCrit += 4;
			player.magicCrit += 4;
			player.rangedCrit += 4;
			player.thrownCrit += 4;
			player.GetModPlayer<MyPlayer>().summonTagCrit += 4;
			player.aggro -= 200;
        }
    }
	
	public class GalaxySparkBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Galaxy Spark Unleash");
            Description.SetDefault("Increased Critical strike chance by 5%"
			+ "\nIncreased Tag critical chance by 5%");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeCrit += 5;
			player.magicCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
			player.GetModPlayer<MyPlayer>().summonTagCrit += 5;
        }
    }
	
}
