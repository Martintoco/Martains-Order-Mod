using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class CasterBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Caster");
            Description.SetDefault("Reduced mana usage");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.manaCost -= 0.10f;
        }
    }
}
