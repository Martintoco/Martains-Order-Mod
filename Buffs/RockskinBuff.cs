using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class RockskinBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rockskin");
            Description.SetDefault("Temporal immunity to Knockback");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.noKnockback = true;
        }
    }
}
