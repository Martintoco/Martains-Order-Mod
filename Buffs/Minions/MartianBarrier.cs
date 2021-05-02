using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Minions
{
    public class MartianBarrier : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Martian Barrier");
            Description.SetDefault("-Secured by the system-"
            + "\n+5 Defense"
            + "\n+5% damage reduction"
            + "\nAttackers take some damage");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.statDefense += 5;
			player.endurance += 0.5f;
			player.thorns += 0.15f;
        }
    }
}