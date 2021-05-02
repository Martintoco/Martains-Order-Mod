using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Minions
{
    public class MElemental : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("M. Elemental");
            Description.SetDefault("Martinite is by your side");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("MElemental")] > 0)
            {
                modPlayer.MElemental = true;
            }
            if (!modPlayer.MElemental)
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