using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class ShooterBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shooter");
            Description.SetDefault("Increased ranged Critical strike chance");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.rangedCrit += 10;
        }
    }
}
