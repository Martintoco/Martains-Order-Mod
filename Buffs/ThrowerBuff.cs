using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class ThrowerBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Thrower");
            Description.SetDefault("Increased Throwing velocity");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.thrownVelocity += 0.1f;
        }
    }
}
