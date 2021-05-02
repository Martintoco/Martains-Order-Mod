using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class TurretBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Defender");
            Description.SetDefault("Increased max number of sentries");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.maxTurrets += 1;
        }
    }
}
