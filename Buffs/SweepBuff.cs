using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class SweepBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sweeper");
            Description.SetDefault("Increased Melee speed");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.meleeSpeed += 0.1f;
            //player.itemTime -= player.itemTime / 10;
            //player.itemAnimation -= player.itemAnimation / 10;
        }
        /*
		{
			if(player.itemTime > 1) 
			{
				if(player.itemTime > 2) 
				{
					if(player.itemTime > 3) 
					{
						player.itemTime -= 3;
					}
					else player.itemTime -= 2;
				}
				else player.itemTime -= 1;
			}
			
			if(player.itemAnimation > 1) 
			{
				if(player.itemAnimation > 2) 
				{
					if(player.itemAnimation > 3) 
					{
						player.itemAnimation -= 3;
					}
					else player.itemAnimation -= 2;
				}
				else player.itemAnimation -= 1;
			}
        }
		*/
    }
}
