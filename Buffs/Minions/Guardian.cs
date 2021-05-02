using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Minions
{
    public class Guardian : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Guardian");
            Description.SetDefault("The power of their temple made them swim in air");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("Guardian")] > 0)
            {
                modPlayer.Guardian = true;
            }
            if (!modPlayer.Guardian)
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