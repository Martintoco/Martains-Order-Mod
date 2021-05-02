using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Bonus
{
    public class LFHalfBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Luminite Rush");
            Description.SetDefault("Defense and Movement speed increased");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //player.hairColor[Type].White;
            player.statDefense += 5;
            player.moveSpeed *= 2f;
        }
    }
}
