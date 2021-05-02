using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Cook
{
    public class FreshSalad : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fresh Salad");
            Tooltip.SetDefault("Gourmet improvements to all stats");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 2;
            item.healLife = 30;
            item.healMana = 15;
            item.potion = true;
            item.value = 500;
            item.buffType = mod.BuffType("Gourmet");
            item.buffTime = 3600*10;
        }

    }

    public class Smoothie : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Smoothie");
            Tooltip.SetDefault("Gourmet improvements to all stats");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 36;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 5;
            item.healMana = 75;
            item.potion = true;
            item.value = 975;
            item.buffType = mod.BuffType("Gourmet");
            item.buffTime = 3600*9;
        }

    }

    public class Bisque : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bisque");
            Tooltip.SetDefault("Gourmet improvements to all stats");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 22;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 4;
            item.healLife = 30;
            item.healMana = 30;
            item.potion = true;
            item.value = 725;
            item.buffType = mod.BuffType("Gourmet");
            item.buffTime = 3600*12;
        }

    }

    public class EnergyDrink : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vitamin Drink");
            Tooltip.SetDefault("Gourmet improvements to all stats"
            + "\n25% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 28;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 4;
            item.healMana = 35;
            item.potion = true;
            item.value = 975;
            item.buffType = mod.BuffType("Gourmet");
            item.buffTime = 3600*8;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(3, 3600*4);
            return true;
        }

    }

    public class FastFood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fast Food");
            Tooltip.SetDefault("Gourmet improvements to all stats");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 6;
            item.healLife = 15;
            item.healMana = 15;
            item.potion = true;
            item.value = 975;
            item.buffType = mod.BuffType("Gourmet");
            item.buffTime = 3600*11;
        }

    }

    public class GlowingSalad : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glowing Salad");
            Tooltip.SetDefault("Gourmet improvements to all stats"
            + "\nEmits an Aura of light");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 24;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 6;
            item.healLife = 35;
            item.healMana = 15;
            item.potion = true;
            item.value = 1575;
            item.buffType = mod.BuffType("Gourmet");
            item.buffTime = 3600*9;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(11, 3600*5);
            return true;
        }

    }

    public class MashedPotatoes : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mashed Potatoes");
            Tooltip.SetDefault("Gourmet improvements to all stats");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 24;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 3;
            item.healLife = 45;
            item.potion = true;
            item.value = 650;
            item.buffType = mod.BuffType("Gourmet");
            item.buffTime = 3600*14;
        }

    }

    public class Noodles : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Noodles");
            Tooltip.SetDefault("Gourmet improvements to all stats");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 18;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 5;
            item.healLife = 75;
            item.potion = true;
            item.value = 1000;
            item.buffType = mod.BuffType("Gourmet");
            item.buffTime = 3600*13;
        }

    }
}
