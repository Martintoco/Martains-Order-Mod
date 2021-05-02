using MartainsOrder.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Debuffs
{
    public class Fracture : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fracture");
            Description.SetDefault("Movement speed and Life regeneration Decreased");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed -= 0.01f;
			player.lifeRegen -= 1;
        }
		public override void Update(NPC npc, ref int buffIndex)
        {
			npc.lifeRegen -= 1;
        }
    }
}
