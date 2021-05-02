using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class SummonSpeedBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Quick Summoning");
            Description.SetDefault("Increased summoning speed");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.GetModPlayer<MyPlayer>().summonSpeed += 0.10f;
        }
    }
}
