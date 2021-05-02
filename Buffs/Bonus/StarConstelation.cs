using MartainsOrder.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Bonus
{
    public class StarConstelation : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Star Constelation");
            Description.SetDefault("Stars phase and explode");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MGlobalNPC>().starDustEf = true;
        }
    }
}
