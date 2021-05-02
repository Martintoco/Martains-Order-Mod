using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class RavageBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ravage");
            Description.SetDefault("Reduced Vision and Defense by 15%,"
            + "\nIncreased Damage and Movement by 25%");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Lighting.brightness -= 0.15f;
            player.statDefense -= 15;
            player.allDamage += 0.25f;
            player.moveSpeed += 0.25f;
        }

    }

}