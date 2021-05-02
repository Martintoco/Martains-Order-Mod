using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Trans
{
    public class ExtraterrestialCurse : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Extraterrestial Curse");
            Tooltip.SetDefault("Turns the holder into a werewolf at night, a merfolk when entering water,"
			+ "\na bloodthrist Monster at 25% life, a Nimbu-sapien at rain"
			+ "\nand a Florian at day. Boosts all stats.");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 38;
            item.accessory = true;
            item.value = 100000;
            item.rare = 11;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.accMerman = true;
			player.wolfAcc = true;
			if (hideVisual)
			{
				player.hideMerman = true;
				player.hideWolf = true;
			}
			player.lifeRegen += 2;
			player.statDefense += 4;
			player.meleeSpeed += 0.1f;
			player.allDamage += 0.1f;
			player.meleeCrit += 2;
			player.rangedCrit += 2;
			player.magicCrit += 2;
			player.pickSpeed -= 0.15f;
			player.minionKB += 0.5f;
			player.thrownCrit += 2;
			player.thrownVelocity += 0.1f;
            player.GetModPlayer<MyPlayer>().monsterAcc = true;
			if(!player.wet)player.GetModPlayer<MyPlayer>().nimbusAcc = true;
			if(!player.wet)player.GetModPlayer<MyPlayer>().florianAcc = true;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CelestialShell, 1);
            recipe.AddIngredient(mod.ItemType("EnragedBlood"), 1);
            recipe.AddIngredient(mod.ItemType("NimbusMedal"), 1);
			recipe.AddIngredient(mod.ItemType("FlowerCrystal"), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
