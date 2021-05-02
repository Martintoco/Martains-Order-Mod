using MartainsOrder.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Debuffs
{
    public class GarnetCurse : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Garnet Wither");
            Description.SetDefault("Defense and Critical strike chance decreased");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= (player.statDefense / 100);
            player.endurance -= (player.endurance / 10f);
            player.meleeCrit -= 5;
            player.rangedCrit -= 5;
            player.magicCrit -= 5;
            player.thrownCrit -= 5;
            player.GetModPlayer<MyPlayer>().summonTagCrit -= 5;
            player.GetModPlayer<MyPlayer>().garnetCurse = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense -= (npc.defense / 255);
            //npc.takenDamageMultiplier += 0.0047f;
            npc.GetGlobalNPC<MGlobalNPC>().garnetCurse = true;
        }
    }
}
