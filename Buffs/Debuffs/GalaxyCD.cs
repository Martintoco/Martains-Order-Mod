using MartainsOrder.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Debuffs
{
    public class GalaxyCD : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Galaxy cooldown");
            Description.SetDefault("Cannot use the worm hole");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
			canBeCleared = false;
        }
    }
	
	public class TotemCD : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Totem cooldown");
            Description.SetDefault("Cannot revive");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
			canBeCleared = false;
        }
    }
}
