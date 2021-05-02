using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Extra
{
    public class ReschBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Archeologycal intelect");
            Description.SetDefault("Research runs faster");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.GetModPlayer<MyPlayer>().researchVelocityAcc -= 120;
        }
    }
}
