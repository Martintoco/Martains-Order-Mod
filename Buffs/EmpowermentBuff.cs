using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class EmpowermentBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Empowerment");
            Description.SetDefault("20% increased max mana");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.statManaMax2 += (player.statManaMax/5);
        }
    }
}
