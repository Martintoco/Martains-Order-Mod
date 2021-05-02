using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    [AutoloadEquip(EquipType.Head)]
    public class GarnetAH2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Shell");
            Tooltip.SetDefault("Increases Throwing speed by 15%"
            + "\nIncreases Throwing Damage by 7%");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 43000;
            item.rare = 4;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += 0.15f;
            player.thrownDamage += 0.07f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GarnetAB") && legs.type == mod.ItemType("GarnetAL");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases armor penetration by 15";
            player.armorPenetration += 15;
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