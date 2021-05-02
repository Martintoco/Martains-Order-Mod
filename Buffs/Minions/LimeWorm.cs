using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Minions
{
    public class LimeWorm : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lime Worms");
            Description.SetDefault("wiggle wiggle");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("LimeWorm")] > 0)
            {
                modPlayer.LimeWorm = true;
            }
            if (!modPlayer.LimeWorm)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}