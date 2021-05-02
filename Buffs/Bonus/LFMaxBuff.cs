using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Bonus
{
    public class LFMaxBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Luminite Wealth");
            Description.SetDefault("Provided increased sight and Damage");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			Lighting.brightness += 1.25f;
            player.allDamage += 0.15f;
        }
    }
}
