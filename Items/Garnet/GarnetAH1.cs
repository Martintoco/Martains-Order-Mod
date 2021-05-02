using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    [AutoloadEquip(EquipType.Head)]
    public class GarnetAH1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Hood");
            Tooltip.SetDefault("+2 max Minions"
            + "\nIncreases minion Damage by 5%");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 43000;
            item.rare = 4;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
			player.maxMinions += 2;
            player.minionDamage += 0.05f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GarnetAB") && legs.type == mod.ItemType("GarnetAL");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 Max Sentries"
            + "\nIncreases Whip range by 12%";
            player.maxTurrets += 1;
            //player.GetModPlayer<MyPlayer>().garnetWhipRange = true;
			player.GetModPlayer<MyPlayer>().whipExtraRange += 0.12f;
			Lighting.AddLight((int)(player.Center.X / 16 + 0.5f * player.direction), (int)(player.Center.Y / 16), 0.9f, 0.25f, 0.25f);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 14);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}