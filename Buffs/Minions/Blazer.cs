using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Minions
{
    public class Blazer : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blazer");
            Description.SetDefault("Right from the neth- the underworld");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("Blazer")] > 0)
            {
                modPlayer.Blazer = true;
            }
            if (!modPlayer.Blazer)
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