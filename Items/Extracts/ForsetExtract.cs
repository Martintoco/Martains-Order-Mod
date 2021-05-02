using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Extracts
{
	public class ForsetExtract : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Herb Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.DirtBlock, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.ClayBlock, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Wood, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(mod.ItemType("Herb"), 1);
            recipe.AddRecipe();
        }
	}
	public class ForsetExtract2 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Zombie Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract2"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Lens, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract2"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.BlackLens, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract2"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Shackle, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract2"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.ZombieArm, 1);
            recipe.AddRecipe();
        }
	}
	public class ForsetExtract3 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slime Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract3"), 1);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Gel, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.PinkGel, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ForsetExtract3"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.TatteredCloth, 1);
            recipe.AddRecipe();
        }
	}
	public class DesertExtract : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sand Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DesertExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.SandBlock, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DesertExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Sandstone, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DesertExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Cactus, 1);
            recipe.AddRecipe();
			/*recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DesertExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(mod.ItemType("Herb"), 1);
            recipe.AddRecipe();*/
        }
	}
	public class TundraExtract : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Snow Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TundraExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.SnowBlock, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TundraExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.IceBlock, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TundraExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.BorealWood, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TundraExtract"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.SlushBlock, 1);
            recipe.AddRecipe();
        }
	}
	public class JungleExtract : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mud Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("JungleExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.MudBlock, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("JungleExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.JungleSpores, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("JungleExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Vine, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("JungleExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(mod.ItemType("WillowFiber"), 1);
            recipe.AddRecipe();
        }
	}
	public class CaveExtract : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rock Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CaveExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.StoneBlock, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CaveExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Granite, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CaveExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Marble, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CaveExtract"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.SiltBlock, 1);
            recipe.AddRecipe();
        }
	}
	public class TreasureExtract : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 2;
		}
		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Spear, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Blowpipe, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Aglet, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.ClimbingClaws, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Umbrella, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(3068, 1); //GuidetoPlantFiberCordiage
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.WandofSparking, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Radar, 1);
            recipe.AddRecipe();
        }
	}
	public class TreasureExtract2 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("S. Treasure Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 2;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract2"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.BandofRegeneration, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract2"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.MagicMirror, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract2"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.HermesBoots, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract2"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.ShoeSpikes, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract2"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.FlareGun, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract2"), 1);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Flare, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract2"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Extractinator, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract2"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(mod.ItemType("ClothBandana"), 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract2"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(mod.ItemType("ComfyBoots"), 1);
            recipe.AddRecipe();
        }
	}
	public class TreasureExtract3 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("G. Treasure Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 2;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.BandofRegeneration, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract3"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.MagicMirror, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.CloudinaBottle, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.HermesBoots, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.ShoeSpikes, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract3"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.FlareGun, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract3"), 1);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Flare, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Extractinator, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TreasureExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.LavaCharm, 1);
            recipe.AddRecipe();
        }
	}
	public class SkyExtract : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cloud Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SkyExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Cloud, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SkyExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.SunplateBlock, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SkyExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Feather, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SkyExtract"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.FallenStar, 1);
            recipe.AddRecipe();
        }
	}
	public class HellExtract : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ash Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract"), 3);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.AshBlock, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Obsidian, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract"), 1);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.ObsidianPlatform, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.ObsidianRose, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.DemonScythe, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.MagmaStone, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract"), 5);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.GuideVoodooDoll, 1);
            recipe.AddRecipe();
        }
	}
	public class HellExtract2 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shadow Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract2"), 1);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.HellfireArrow, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract2"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.DarkLance, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract2"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Sunfury, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract2"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.Flamelash, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract2"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.FlowerofFire, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract2"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.HellwingBow, 1);
            recipe.AddRecipe();
        }
	}
	public class HellExtract3 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Molten Extract");
			Tooltip.SetDefault("'Needs a better look'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = 3;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract3"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.BreakerBlade, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract3"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.LaserRifle, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract3"), 7);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.ClockworkAssaultRifle, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.WarriorEmblem, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.SorcererEmblem, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.RangerEmblem, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(ItemID.SummonerEmblem, 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(mod.ItemType("TosserEmblem"), 1);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HellExtract3"), 10);
            recipe.AddTile(mod.TileType("ArcheologyTable"));
            recipe.SetResult(mod.ItemType("NeutralEmblem"), 1);
            recipe.AddRecipe();
        }
	}
	
	public class ExtractDropNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc) {
			for(int i = 0; i < Main.maxPlayers; i++)
            {
				if(MartainWorld.extractsActive) {
				Player player = Main.player[i];
				/*//if (player.GetModPlayer<MyPlayer>().ZoneWoods)
			if (player.active && npc.damage > 0 && !npc.friendly 
		&& player.ZoneOverworldHeight && !player.ZoneSnow && !player.ZoneCorrupt && !player.ZoneJungle && !player.ZoneHoly && !player.ZoneCrimson && !player.ZoneDesert && !player.ZoneGlowshroom && !player.ZoneBeach && !player.GetModPlayer<MyPlayer>().ZoneVoid)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("TestExtract"), 1);
			}
			}*/
				
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 1 && Main.rand.Next(2)==0 
				&& player.ZoneOverworldHeight && !player.ZoneSnow && !player.ZoneCorrupt && !player.ZoneJungle && !player.ZoneHoly && !player.ZoneCrimson && !player.ZoneDesert && !player.ZoneGlowshroom && !player.ZoneBeach && !player.GetModPlayer<MyPlayer>().ZoneVoid)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("ForsetExtract"), 1);
				}
				if (Main.dayTime == true && player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 1 && Main.rand.Next(2)==0 
				&& player.ZoneOverworldHeight && !player.ZoneSnow && !player.ZoneCorrupt && !player.ZoneJungle && !player.ZoneHoly && !player.ZoneCrimson && !player.ZoneDesert && !player.ZoneGlowshroom && !player.ZoneBeach && !player.GetModPlayer<MyPlayer>().ZoneVoid)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("ForsetExtract3"), 1);
				}
				if (Main.dayTime == false && player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 1 && Main.rand.Next(2)==0 
				&& player.ZoneOverworldHeight && !player.ZoneSnow && !player.ZoneCorrupt && !player.ZoneJungle && !player.ZoneHoly && !player.ZoneCrimson && !player.ZoneDesert && !player.ZoneGlowshroom && !player.ZoneBeach && !player.GetModPlayer<MyPlayer>().ZoneVoid)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("ForsetExtract2"), 1);
				}
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 1 && Main.rand.Next(4)==0 
				&& player.ZoneOverworldHeight && !player.ZoneSnow && !player.ZoneCorrupt && !player.ZoneJungle && !player.ZoneHoly && !player.ZoneCrimson && !player.ZoneDesert && !player.ZoneGlowshroom && !player.ZoneBeach && !player.GetModPlayer<MyPlayer>().ZoneVoid)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("TreasureExtract"), 1);
				}
				////////////////////////////////////////////////////////////////////////////////////////////////////
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 1 && Main.rand.Next(2)==0 
				&& player.ZoneOverworldHeight && player.ZoneDesert)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("DesertExtract"), 1);
				}
				////////////////////////////////////////////////////////////////////////////////////////////////////
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 1 && Main.rand.Next(2)==0 
				&& player.ZoneOverworldHeight && player.ZoneSnow)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("TundraExtract"), 1);
				}
				////////////////////////////////////////////////////////////////////////////////////////////////////
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 1 && Main.rand.Next(2)==0 
				&& player.ZoneOverworldHeight && player.ZoneJungle)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("JungleExtract"), 1);
				}
				////////////////////////////////////////////////////////////////////////////////////////////////////
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 0 && Main.rand.Next(2)==0 
				&& player.ZoneRockLayerHeight)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("CaveExtract"), 1);
				}
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 0 && Main.rand.Next(4)==0 
				&& player.ZoneDirtLayerHeight)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("TreasureExtract2"), 1);
				}
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 0 && Main.rand.Next(4)==0 
				&& player.ZoneRockLayerHeight)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("TreasureExtract3"), 1);
				}
				////////////////////////////////////////////////////////////////////////////////////////////////////
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 1 && Main.rand.Next(2)==0 
				&& player.ZoneSkyHeight)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("SkyExtract"), 1);
				}
				////////////////////////////////////////////////////////////////////////////////////////////////////
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 0 && Main.rand.Next(2)==0 
				&& player.ZoneUnderworldHeight)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("HellExtract"), 1);
				}
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 0 && Main.rand.Next(2)==0 
				&& player.ZoneUnderworldHeight && NPC.downedBoss3)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("HellExtract2"), 1);
				}
				if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 0 && Main.rand.Next(2)==0 
				&& player.ZoneUnderworldHeight && Main.hardMode)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("HellExtract3"), 1);
				}
				////////////////////////////////////////////////////////////////////////////////////////////////////
			}
				
			}
			
			if (Main.netMode == NetmodeID.Server) 
			{
				NetMessage.SendData(MessageID.WorldData);
			}
		}
	}
}