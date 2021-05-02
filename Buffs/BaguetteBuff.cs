using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class BaguetteBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Baguette");
            Description.SetDefault("Baguette");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeSpeed += player.meleeSpeed / 20;
            player.moveSpeed += player.moveSpeed / 20;
            player.lifeRegen += 3;
            player.statDefense += 5;
        }
    }
}
