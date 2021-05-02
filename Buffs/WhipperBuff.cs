using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class WhipperBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Whipper");
            Description.SetDefault("Increased Whip range");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.GetModPlayer<MyPlayer>().whipExtraRange += 0.10f;
        }
    }
}
