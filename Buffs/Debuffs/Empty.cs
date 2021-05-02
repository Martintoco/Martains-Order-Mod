using MartainsOrder.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Debuffs
{
    public class Empty : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Empty");
            Description.SetDefault("Deteriorating inside");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.lifeRegen -= 3;
			player.manaRegen -= 1;
			player.endurance -= 0.05f;
        }
		public override void Update(NPC npc, ref int buffIndex)
        {
			npc.lifeRegen -= 2;
        }
    }
}
