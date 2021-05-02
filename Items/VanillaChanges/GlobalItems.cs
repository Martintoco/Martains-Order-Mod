using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.VanillaChanges
{
    public class GlobalItems : GlobalItem
    {

        public override bool InstancePerEntity => true;
        //public bool swingStabState = false;
        //public int swingStabState = Main.rand.Next(1,4);
        public override bool CloneNewInstances => true;

        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.CopperShortsword)
            {
                item.scale = 0.9f;
            }

            if (item.type == ItemID.RodofDiscord)
            {
                item.mana = 15;
                item.rare = -12;
            }
			if (item.type == ItemID.DirtRod)
            {
                item.mana = 1;
            }
			
			if (item.type == ItemID.Beenade && item.damage > 3)
            {
                item.damage -= 3;
            }
			if (item.type == ItemID.StardustDragonStaff && item.damage > 4)
            {
                item.damage -= 4;
            }
            if (item.type == 2273 || item.type == ItemID.Muramasa)
            {
                item.useTime -= 1;
                item.useAnimation -= 1;
                item.knockBack += 0.25f;
            }

            if (item.type == ItemID.PalladiumSword || item.type == ItemID.MythrilSword || item.type == ItemID.CobaltSword || item.type == ItemID.OrichalcumSword || item.type == ItemID.AdamantiteSword || item.type == ItemID.TitaniumSword)
            {
                item.useTime -= 1;
                item.useAnimation -= 1;
                item.scale = 1.05f;
                item.width += 1;
                item.height += 1;
                item.knockBack += 0.5f;
            }

            if (item.type == ItemID.BluePhaseblade || item.type == ItemID.RedPhaseblade || item.type == ItemID.GreenPhaseblade || item.type == ItemID.PurplePhaseblade || item.type == ItemID.WhitePhaseblade || item.type == ItemID.YellowPhaseblade)
            { //|| item.type == ItemID.OrangePhaseblade) {
                item.useTime -= 2;
                item.useAnimation -= 2;
            }
            if (item.type == ItemID.BluePhasesaber || item.type == ItemID.RedPhasesaber || item.type == ItemID.GreenPhasesaber || item.type == ItemID.PurplePhasesaber || item.type == ItemID.WhitePhasesaber || item.type == ItemID.YellowPhasesaber)
            { //|| item.type == ItemID.OrangePhasesaber) {
                item.useTime -= 2;
                item.useAnimation -= 2;
                item.knockBack += 0.5f;
            }
			
			if (item.type == 2273 || item.type == ItemID.EldMelter)
            {
                item.shootSpeed += 1f;
            }
			
            //if(item.type == 2273) item.type = mod.ItemType("KatanaMSwingStab");

            /*if (item.type == 2273 || item.type == ItemID.Muramasa || item.type == ItemID.PalladiumSword || item.type == ItemID.MythrilSword || item.type == ItemID.CobaltSword || item.type == ItemID.OrichalcumSword || item.type == ItemID.AdamantiteSword || item.type == ItemID.TitaniumSword) {
			if (swingStabState == false) {item.useStyle = 1; 
			//swingStabState = true;
			}
			if (swingStabState == true) {item.useStyle = 3; 
			//swingStabState = false;
			}
		    }*/
        }
		
		public override void OpenVanillaBag(string context, Player player, int arg) {
			if (context == "bossBag" && arg == ItemID.KingSlimeBossBag) {
				if(Main.rand.Next(2)==0)player.QuickSpawnItem(mod.ItemType("DankScroll"), 1);
			}
			if (context == "bossBag" && arg == ItemID.QueenBeeBossBag) {
				if(Main.rand.Next(2)==0)player.QuickSpawnItem(mod.ItemType("Beehaw"), 1);
			}
			if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag) {
				if(Main.rand.Next(6)==0)player.QuickSpawnItem(mod.ItemType("TosserEmblem"), 1);
				if(Main.rand.Next(6)==0)player.QuickSpawnItem(mod.ItemType("NeutralEmblem"), 1);
			}
			if(arg == ItemID.WoodenCrate) {
				if(Main.rand.Next(9)==0) player.QuickSpawnItem(mod.ItemType("NaturePotion"), Main.rand.Next(1,3));
				if(Main.rand.Next(9)==0) player.QuickSpawnItem(mod.ItemType("RockskinPotion"), Main.rand.Next(2,4));
			}
			if(arg == ItemID.IronCrate) {
				if(Main.rand.Next(8)==0) player.QuickSpawnItem(mod.ItemType("SweepPotion"), Main.rand.Next(2,4));
				if(Main.rand.Next(8)==0) player.QuickSpawnItem(mod.ItemType("CasterPotion"), Main.rand.Next(2,4));
				if(Main.rand.Next(8)==0) player.QuickSpawnItem(mod.ItemType("ShooterPotion"), Main.rand.Next(2,4));
				if(Main.rand.Next(8)==0) player.QuickSpawnItem(mod.ItemType("WhipperPotion"), Main.rand.Next(2,4));
				if(Main.rand.Next(8)==0) player.QuickSpawnItem(mod.ItemType("ThrowerPotion"), Main.rand.Next(2,4));
			}
			if(arg == ItemID.GoldenCrate) {
				if(Main.rand.Next(4)==0) player.QuickSpawnItem(mod.ItemType("DoomPotion"), Main.rand.Next(2,4));
			}
		}
		
		public override bool ConsumeAmmo(Item item, Player player)
        {
			if(item.ranged == true || item.useAmmo != -1) {
				return Main.rand.NextFloat() >= player.GetModPlayer<MyPlayer>().ammoSave;
			}
			return default;
        }
		public override bool ConsumeItem(Item item, Player player) {
			if(item.thrown == true && item.consumable == true && item.damage >= 1) {
				return Main.rand.NextFloat() >= player.GetModPlayer<MyPlayer>().throwSave;
			}
            return true;
        }
		
        /*public virtual void UpdateInventory(Item item, Player player) {
			if (item.type == 2273 || item.type == ItemID.Muramasa || item.type == ItemID.PalladiumSword || item.type == ItemID.MythrilSword || item.type == ItemID.CobaltSword || item.type == ItemID.OrichalcumSword || item.type == ItemID.AdamantiteSword || item.type == ItemID.TitaniumSword) {
			if(swingStabState == 1) swingStabState = Main.rand.Next(1,4);
			if(swingStabState == 3) swingStabState = Main.rand.Next(1,4);
			if(swingStabState == 2) swingStabState = Main.rand.Next(1,4);
			item.useStyle = swingStabState;
		    }
			
        }
		
		/*public virtual bool AltFunctionUse(Item item, Player player) {
			if (item.type == ItemID.Katana || item.type == ItemID.Muramasa || item.type == ItemID.PalladiumSword || item.type == ItemID.MythrilSword || item.type == ItemID.CobaltSword || item.type == ItemID.OrichalcumSword || item.type == ItemID.AdamantiteSword || item.type == ItemID.TitaniumSword) return true;
			else return false;
		}

		public virtual bool CanUseItem(Item item, Player player) {
			if (player.altFunctionUse == 2) {
				if (item.type == ItemID.Katana || item.type == ItemID.Muramasa || item.type == ItemID.PalladiumSword || item.type == ItemID.MythrilSword || item.type == ItemID.CobaltSword || item.type == ItemID.OrichalcumSword || item.type == ItemID.AdamantiteSword || item.type == ItemID.TitaniumSword){ 
				item.useStyle = 3;
				item.useTime -= 1;
				item.useAnimation -= 1;
				}
			}
			else {
			}
			return true;
		}
		
		public virtual bool UseItem(Player player) {
			return true;
		if (swingStabState == false) {
			swingStabState = true;
			}
		if (swingStabState == true) {
			swingStabState = false;
			}
			return true;
		}
		
		/*
		public virtual bool CanUseItem(Player player, Item item) {
			if (item.type == ItemID.RodofDiscord) {
            if (player.chaosState) {
			//	player.noItems = true;
				return false;
			}
			}
			return default;
        }

		public virtual bool UseItem (Player player, Item item) {
			if (item.type == ItemID.RodofDiscord) {
			   player.statMana *= 0;
		    }
			return default;
        }
  
		
		public virtual bool OnConsumeItem(Item item, Player player, int buffIndex) {
			if (item.type == ItemID.Mushroom) {
			    if (player.buffType[index] == 21)
                {
                    player.buffTime[index] = 1800;
                }
			}
			return base.UseItem(item, player);
		/
		
		public virtual void PostUpdate(Item item, Player player, int buffIndex)
        {
			if (item.type == ItemID.Mushroom) {
            for (int index = 0; index < 22; ++index)
            {
                if (player.buffType[index] == 21)
                {
                    player.buffTime[index] = 1800;
                }
            }
			}
        }*/

    }

    public class GlobalItemDrop : GlobalTile
    {

        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {

            if (!noItem && type == TileID.JungleGrass && Main.rand.Next(32) == 0)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.JungleGrassSeeds);
            }

            if (!noItem && type == TileID.Plants2 && Main.rand.Next(32) == 0)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.GrassSeeds);
            }

            if (!noItem && type == TileID.HallowedPlants2 && Main.rand.Next(32) == 0)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.HallowedSeeds);
            }

            if (!noItem && type == TileID.CorruptPlants && Main.rand.Next(32) == 0)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CorruptSeeds);
            }

            if (!noItem && type == TileID.FleshWeeds && Main.rand.Next(32) == 0)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CrimsonSeeds);
            }

            if (!noItem && type == TileID.MushroomPlants && Main.rand.Next(36) == 0)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MushroomGrassSeeds);
            }

            if (!noItem && type == TileID.MushroomPlants)
            {
                if (Main.rand.Next(36) == 0) // Give every tile a 1/25 chance to drop an item.
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MushroomGrassSeeds);
                }
            }

            if (!noItem && type == TileID.JunglePlants)
            {
                if (Main.rand.Next(21) == 0) // Give every tile a 1/30 chance to drop an item.
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.JungleSpores);
                }
				if (Main.rand.Next(17) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("Berries"));
                }
				
				if (Main.rand.Next(215) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("AloeCream"));
                }

                if (Main.rand.Next(36) == 0) // Give every tile a 1/9 chance to drop an item.
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.JungleGrassSeeds);
                    noItem = true; // Prevent any further items from dropping (if you like).
                }
            }

            if (!noItem && type == TileID.JungleVines)
            {
                if (Main.rand.Next(12) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("Herb"));
                }
                if (Main.rand.Next(35) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Vine);
                }
            }

            if (!noItem && type == TileID.JungleThorns)
            {
                if (Main.rand.Next(7) == 0) // Give every tile a 1/9 chance to drop an item.
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Pearlwood);
                    //noItem = true; // Prevent any further items from dropping (if you like).
                }
            }

            if (!noItem && type == TileID.JunglePlants2)
            {
                if (Main.rand.Next(18) == 0) // Give every tile a 1/30 chance to drop an item.
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.JungleSpores);
                }
				if (Main.rand.Next(17) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("Berries"));
                }
            }

            if (!noItem && type == TileID.PlantDetritus)
            {
                if (Main.rand.Next(10) == 0) // Give every tile a 1/30 chance to drop an item.
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.JungleSpores);
                }
				if (Main.rand.Next(8) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("Berries"));
                }
            }

            if (!noItem && type == TileID.LongMoss)
            {
                switch (Main.rand.Next(0, 7))
                {
                    case 0:
                        Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("HallowHerb"));
                        break;
                    case 1:
                        Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("CorruptedHerb"));
                        break;
                    case 2:
                        Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("CrimsonHerb"));
                        break;
                    case 3:
                        Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("Herb"));
                        break;
                    case 4:
                        Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("Herb"));
                        break;
                    default:
                        break;
                }
            }

            if (!noItem && type == TileID.SmallPiles)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CopperCoin, 5);
                }
            }

            if (!noItem && type == TileID.LargePiles)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CopperCoin, 10);
                }
            }

            if (!noItem && type == TileID.LargePiles2)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CopperCoin, 15);
                }
            }
			
			if(type == TileID.SmallPiles || type == TileID.LargePiles || type == TileID.LargePiles2) {
				MartainWorld.brokenPiles += 1;
				if(MartainWorld.brokenPiles > 25 && !noItem) {
					switch (Main.rand.Next(0,5))
					{
					case 0:
					Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Arkhalis, 1);
						break;
					case 1:
					Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("TerrarieSpear"), 1);
						break;
					case 2:
					Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("MelioArcus"), 1);
						break;
					case 3:
					Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("StarFlail"), 1);
						break;
					default:
					Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("CurvedAbyssinian"), 1);
						break;
					}
					MartainWorld.brokenPiles = 0;
				}
			}

            if (!noItem && type == TileID.Meteorite)
            {
                if (Main.rand.Next(42) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.LivingFireBlock, 1);
                    noItem = true;
                }
            }

        }
    }
}