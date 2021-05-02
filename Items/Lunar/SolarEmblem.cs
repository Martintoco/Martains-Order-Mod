using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class SolarEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Emblem");
            Tooltip.SetDefault("15% increased melee Damage"
			+ "\n15% increased melee Speed"
			+ "\n15% increased melee Critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.accessory = true;
            item.value = 200000;
            item.rare = 10;
        }
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.meleeDamage += 0.15f;
			player.meleeSpeed += 0.15f;
			player.meleeCrit += 15;
        }
    }
	
	public class NebulaEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Emblem");
            Tooltip.SetDefault("15% increased magic Damage"
			+ "\n+15 maximun mana"
			+ "\n15% increased magic Critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.accessory = true;
            item.value = 200000;
            item.rare = 10;
        }
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.magicDamage += 0.15f;
			player.statManaMax2 += 15;
			player.magicCrit += 15;
        }
    }
	
	public class VortexEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Emblem");
            Tooltip.SetDefault("15% increased ranged Damage"
			+ "\n15% chance not to consume ammo"
			+ "\n15% increased ranged Critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.accessory = true;
            item.value = 200000;
            item.rare = 10;
        }
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.rangedDamage += 0.15f;
			player.GetModPlayer<MyPlayer>().ammoSave += 0.15f;
			player.rangedCrit += 15;
        }
    }
	
	public class StardustEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stardust Emblem");
            Tooltip.SetDefault("15% increased minion Damage"
			+ "\n15% increased summoning Speed"
			+ "\n15% increased Tag critical chance");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.accessory = true;
            item.value = 200000;
            item.rare = 10;
        }
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.minionDamage += 0.15f;
			player.GetModPlayer<MyPlayer>().summonSpeed += 0.15f;
			player.GetModPlayer<MyPlayer>().summonTagCrit += 15;
        }
    }
	
	public class FractalEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fractal Emblem");
            Tooltip.SetDefault("15% increased thrown Damage"
			+ "\n15% increased thrown Speed"
			+ "\n15% increased thrown Critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.accessory = true;
            item.value = 200000;
            item.rare = 10;
        }
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.thrownDamage += 0.15f;
			player.thrownVelocity += 0.15f;
			player.thrownCrit += 15;
        }
    }
	
	public class GalaxyEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Emblem");
            Tooltip.SetDefault("5% increased Damage"
			+ "\n5% increased movement Speed"
			+ "\n5% increased Critical strike chance"
			+ "\n5% increased Tag critical chance");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.accessory = true;
            item.value = 200000;
            item.rare = 10;
        }
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.allDamage += 0.05f;
			player.moveSpeed += 0.05f;
			player.meleeCrit += 5;
			player.magicCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
			player.GetModPlayer<MyPlayer>().summonTagCrit += 5;
        }
    }
}
