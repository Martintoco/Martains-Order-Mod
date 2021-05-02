using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Bonus
{
    public class SpiritBonus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Whippin' revenge");
            Description.SetDefault("Increased Summoning speed");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.GetModPlayer<MyPlayer>().summonSpeed += 0.20f;
			Lighting.AddLight((int)(player.Center.X / 16 + 0.5f * player.direction), (int)(player.Center.Y / 16), 0.55f+Main.rand.NextFloat(0.05f,0.15f), 0.55f+Main.rand.NextFloat(0.05f,0.15f), 1.25f+Main.rand.NextFloat(0.05f,0.15f));
        }
    }
	
}
