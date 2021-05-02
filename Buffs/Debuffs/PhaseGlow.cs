using MartainsOrder.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Debuffs
{
    public class PhaseGlow : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "MartainsOrder/Buffs/Debuffs/DebuffTemplate";
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Phase Glow");
            Description.SetDefault("Targeted and Glowing");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MGlobalNPC>().phaseGlow = true;
        }
    }
}
