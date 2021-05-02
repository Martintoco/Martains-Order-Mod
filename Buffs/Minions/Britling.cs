using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Minions
{
    public class Britling : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Britling");
            Description.SetDefault("You have a cute dragonling");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("Britling")] > 0)
            {
                modPlayer.Britling = true;
            }
            if (!modPlayer.Britling)
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