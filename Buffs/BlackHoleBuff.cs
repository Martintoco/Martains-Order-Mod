using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class BlackHoleBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Black Hole");
            Description.SetDefault("Greatly increased item pickup range");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.GetModPlayer<MyPlayer>().blackHole = true;
        }
    }
}
