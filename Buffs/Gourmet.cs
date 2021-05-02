using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs
{
    public class Gourmet : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gourmet flavor");
            Description.SetDefault("Medium improvements to all stats"
			+"\nIncreased Life and Mana regeneration");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.statDefense += 3;
			player.meleeCrit += 3;player.magicCrit += 3;player.rangedCrit += 3;player.thrownCrit += 3;player.GetModPlayer<MyPlayer>().summonTagCrit += 3;
			player.meleeSpeed += 0.075f;
			player.thrownVelocity += 0.075f;
			player.allDamage += 0.075f;
			player.minionKB += 0.75f;
			player.moveSpeed += 0.30f;
			player.pickSpeed += 0.10f;
			player.lifeRegen += 1;
            player.manaRegen += 1;
			player.pickSpeed += 0.05f;
        }
    }
}
