using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Bonus
{
    public class AmmoBonus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ammo save");
            Description.SetDefault("Chance not to consume ammo");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.GetModPlayer<MyPlayer>().ammoSave += 0.15f;
        }
    }
}
