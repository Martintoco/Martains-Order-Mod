using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Minions
{
    public class ZincSummon : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Zinc Shield");
            Description.SetDefault("-The Zinc Shield Protects you-"
            + "\n+3 Defense"
            + "\n+3% damage reduction"
            + "\nAttackers take some damage");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("ZincSummon")] > 0)
            {
                modPlayer.ZincSummon = true;
            }
            if (!modPlayer.ZincSummon)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }

            player.statDefense += 3;
            player.endurance += 0.03f;
            player.thorns += 0.10f;
        }
    }
}