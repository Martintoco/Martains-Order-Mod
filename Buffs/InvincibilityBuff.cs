using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class InvincibilityBuff : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Invincibility");
            Description.SetDefault("Completely immune to Damage");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			//player.immuneTime = 1;
			player.immune = true;
            player.immuneNoBlink = true;
        }

    }

}