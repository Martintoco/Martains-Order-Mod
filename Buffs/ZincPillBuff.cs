using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class ZincPillBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Zinc Medication");
            Description.SetDefault("Increased Defense and Damage reduction"
			+"\nTemporal immunity to Fracture");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += (int)(player.statDefense / 50);
			player.endurance += (player.endurance / 50);
			player.buffImmune[mod.BuffType("Fracture")] = true;
        }
    }
}
