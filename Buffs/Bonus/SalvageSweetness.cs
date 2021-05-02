using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Bonus
{
    public class SalvageSweetness : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Salvage Sweetness");
            Description.SetDefault("Increased Summoning speed");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.GetModPlayer<MyPlayer>().summonSpeed += 0.25f;
        }
    }
	
	public class Pinnacle : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Pinnacle's Might");
            Description.SetDefault("Increased Summoning speed"
			+"\nIncreased Whip range");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.GetModPlayer<MyPlayer>().summonSpeed += 0.20f;
			player.GetModPlayer<MyPlayer>().whipExtraRange += 0.10f;
        }
    }
}
