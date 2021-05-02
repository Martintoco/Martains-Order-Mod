using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MartainsOrder
{
    public class MartainsOrder : Mod
    {
		public static ModHotKey ThrowingRush;
		
        public override void Load()
        {
            Logger.InfoFormat("{0} example logging", Name);
			ThrowingRush = RegisterHotKey("Throwing Rush", "Q");

            if (!Main.dedServ)
            {
                // Add certain equip textures
                AddEquipTexture(null, EquipType.Legs, "CoalRobe_Legs", "MartainsOrder/Items/Gems/Soot/CoalRobe_Legs");
				//AddEquipTexture(null, EquipType.Back, "Crewmember_Back", "MartainsOrder/Items/Gamer/Vanities/Crewmember_Back");
				AddEquipTexture(new Items.Trans.MonsterHead(), null, EquipType.Head, "MonsterHead", "MartainsOrder/Items/Trans/EnragedBlood_Head");
				AddEquipTexture(new Items.Trans.MonsterBody(), null, EquipType.Body, "MonsterBody", "MartainsOrder/Items/Trans/EnragedBlood_Body", "MartainsOrder/Items/Trans/EnragedBlood_Arms");
				AddEquipTexture(new Items.Trans.MonsterLegs(), null, EquipType.Legs, "MonsterLegs", "MartainsOrder/Items/Trans/EnragedBlood_Legs");
				
				AddEquipTexture(new Items.Trans.NimbusHead(), null, EquipType.Head, "NimbusHead", "MartainsOrder/Items/Trans/NimbusMedal_Head");
				AddEquipTexture(new Items.Trans.NimbusBody(), null, EquipType.Body, "NimbusBody", "MartainsOrder/Items/Trans/NimbusMedal_Body", "MartainsOrder/Items/Trans/NimbusMedal_Arms");
				AddEquipTexture(new Items.Trans.NimbusLegs(), null, EquipType.Legs, "NimbusLegs", "MartainsOrder/Items/Trans/NimbusMedal_Legs");
				
				AddEquipTexture(new Items.Trans.FlorianHead(), null, EquipType.Head, "FlorianHead", "MartainsOrder/Items/Trans/FlowerCrystal_Head");
				AddEquipTexture(new Items.Trans.FlorianBody(), null, EquipType.Body, "FlorianBody", "MartainsOrder/Items/Trans/FlowerCrystal_Body", "MartainsOrder/Items/Trans/FlowerCrystal_Arms");
				AddEquipTexture(new Items.Trans.FlorianLegs(), null, EquipType.Legs, "FlorianLegs", "MartainsOrder/Items/Trans/FlowerCrystal_Legs");
            }
        }

        public override void Unload()
        {
			ThrowingRush = null;
            // All code below runs only if we're not loading on a server
            if (!Main.dedServ)
            {
            }
        }

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
				bossChecklist.Call(
				"AddEvent", 
				2.5f, 
				new List<int> { ModContent.NPCType<NPCs.ForestSpirits.TreeSpirit>(), ModContent.NPCType<NPCs.ForestSpirits.WolfSpirit>() },
				this,  
				"The Forest's Spirits", 
				(Func<bool>)(() => NPC.downedBoss1), 
				ModContent.ItemType<Items.Spirit.SpiritCaller>(), 
				null,
				new List<int> {
				ModContent.ItemType<Items.Spirit.ForestEssence>(),},
				$"Can be turned on and off with a [i:{ModContent.ItemType<Items.Spirit.SpiritCaller>()}], active only on a Deep woods area",
				null,
				"MartainsOrder/NPCs/BCI/ForestSpirits",
				"MartainsOrder/NPCs/BCI/ForestSpiritsHead",
				(Func<bool>)(() => true));
				
				bossChecklist.Call(
                "AddBoss",
                    3.5f,
                    ModContent.NPCType<NPCs.Britzz.Britzz>(),
                    this, // Mod
                    "Britzz, the ice dragon",
                    (Func<bool>)(() => MartainWorld.downedBritzz),
                    ModContent.ItemType<Items.Boss.Britzz.FrigidEgg>(),
                    null,
                    new List<int> {
				ModContent.ItemType<Items.Boss.Britzz.GlidingWing>(),
				ModContent.ItemType<Items.Boss.Britzz.Britzzard>(),
				ModContent.ItemType<Items.Boss.Britzz.ArticArc>(),
				ModContent.ItemType<Items.Boss.Britzz.DragonlingStaff>(),
				ModContent.ItemType<Items.Boss.Britzz.IceBash>(),
				ModContent.ItemType<Items.Boss.Britzz.BritzzBag>(),
				ModContent.ItemType<Items.Boss.Britzz.EverfrostStone>(),
				ModContent.ItemType<Items.Boss.Britzz.BritzzWings>(),},
                    $"Can be Spawned manualy with a [i:{ModContent.ItemType<Items.Boss.Britzz.FrigidEgg>()}]",
                    "It's Britzz's nap time once again...",
                    "MartainsOrder/NPCs/BCI/Britzz",
                    "MartainsOrder/NPCs/BCI/BritzzHead",
					//null,
                    (Func<bool>)(() => true));
					
				bossChecklist.Call(
                "AddBoss",
                    5.5f,
                    ModContent.NPCType<NPCs.Alchemist.Alchemist>(),
                    this, // Mod
                    "The Alchemist",
                    (Func<bool>)(() => MartainWorld.downedAlchemist),
                    ModContent.ItemType<Items.Boss.Alchemist.MartianLocalizer>(),
					null,
                    //new List<int> { ModContent.ItemType<Items.Boss.PrinceSlime.PrinceSlimeTrophy>()/*, ModContent.ItemType<Items.WolfMask>()*/},
                    new List<int> {ModContent.ItemType<Items.Alchemy.MachinedTechCap>(),
                ModContent.ItemType<Items.Boss.Alchemist.AlchemistBag>(),
				ModContent.ItemType<Items.Boss.Alchemist.MagnetSword>(),
				ModContent.ItemType<Items.Boss.Alchemist.BrewGun>(),
				ModContent.ItemType<Items.Boss.Alchemist.CCS>(),
				ModContent.ItemType<Items.Boss.Alchemist.CompressedAirCapsule>(),},
                    $"Can be Spawned manualy by using a [i:{ModContent.ItemType<Items.Boss.Alchemist.MartianLocalizer>()}] at very tall heights.",
                    "The Alchemist reports back to base",
                    "MartainsOrder/NPCs/BCI/Alchemist",
                    "MartainsOrder/NPCs/BCI/AlchemistHead",
                    (Func<bool>)(() => true));
					
				bossChecklist.Call(
                "AddBoss",
                    15f,
                    new List<int> { ModContent.NPCType<NPCs.VoidDigger.VoidDiggerHead>(), ModContent.NPCType<NPCs.VoidDigger.VoidDiggerBody>(), ModContent.NPCType<NPCs.VoidDigger.VoidDiggerTail>() },
                    this, // Mod
                    "Void Digger",
                    (Func<bool>)(() => MartainWorld.downedVoidDigger),
                    ModContent.ItemType<Items.Boss.VoidDigger.VoidWorm>(),
                    new List<int> { ModContent.ItemType<Items.Boss.PrinceSlime.PrinceSlimeTrophy>()/*, ModContent.ItemType<Items.WolfMask>()*/},
                    new List<int> {
				ModContent.ItemType<Items.Boss.VoidDigger.VoidDiggerBag>(),
                ModContent.ItemType<Items.Void.VoidScale>(),
                ModContent.ItemType<Items.Void.VoidCrystal>(),
                ModContent.ItemType<Items.Void.VoidGill>(),
                ModContent.ItemType<Items.Void.VoidWood>(),
				ModContent.ItemType<Items.Void.VoidHerb>(),
				ModContent.ItemType<Items.Void.VoidStone>(),
				ModContent.ItemType<Items.Boss.VoidDigger.VoidAltar>(),
				ModContent.ItemType<Items.Boss.VoidDigger.EmptyLatch>(),
				ModContent.ItemType<Items.Boss.VoidDigger.ShadeCords>(),},
                    $"Can be Spawned manualy at Night, in a Void Barren, while it's raining with a [i:{ModContent.ItemType<Items.Boss.VoidDigger.VoidWorm>()}] after defeating MoonLord",
                    "The Worm digs back as light reaches it from above...",
                    "MartainsOrder/NPCs/BCI/VoidDigger",
                    "MartainsOrder/NPCs/BCI/VoidDiggerHead",
                    (Func<bool>)(() => true));
					
                bossChecklist.Call(
                "AddBoss",
                    15.5f,
                    ModContent.NPCType<NPCs.PrinceSlime.PrinceSlime>(),
                    this, // Mod
                    "Prince Slime",
                    (Func<bool>)(() => MartainWorld.downedPrinceSlime),
                    ModContent.ItemType<Items.Boss.PrinceSlime.LuminiteSlimeCrown>(),
                    new List<int> { ModContent.ItemType<Items.Boss.PrinceSlime.PrinceSlimeTrophy>()/*, ModContent.ItemType<Items.WolfMask>()*/},
                    new List<int> {ItemID.Gel,
                ItemID.PinkGel,
				ModContent.ItemType<Items.Boss.PrinceSlime.PrinceSlimeBag>(),
                ModContent.ItemType<Items.Boss.PrinceSlime.PrinceHook>(),
                ModContent.ItemType<Items.Boss.PrinceSlime.PrinceSlimeMount>(),
                ModContent.ItemType<Items.Boss.PrinceSlime.ExiliedGel>(),
                ModContent.ItemType<Items.HyperSlimeBall>(),
                ItemID.LunarOre},
                    $"Can be Spawned manualy with a [i:{ModContent.ItemType<Items.Boss.PrinceSlime.LuminiteSlimeCrown>()}] after defeating MoonLord",
                    "The Prince Slime flees back to it's Exile",
                    "MartainsOrder/NPCs/BCI/PrinceSlime",
                    "MartainsOrder/NPCs/BCI/PrinceSlimeHead",
                    (Func<bool>)(() => true));
					
                bossChecklist.Call(
                "AddBoss",
                    15.55f,
                    new List<int> { ModContent.NPCType<NPCs.Triplets.Retinator>(), ModContent.NPCType<NPCs.Triplets.Spazmator>(), ModContent.NPCType<NPCs.Triplets.Evocornator>() },
                    this, // Mod
                    "The Triplets",
                    (Func<bool>)(() => MartainWorld.downedTriplets),
                    ModContent.ItemType<Items.Boss.Triplets.LuminiteEye>(),
                    new List<int> {ModContent.ItemType<Items.Boss.Triplets.EvocornatorTrophy>(),
                ModContent.ItemType<Items.Boss.Triplets.RetinatorTrophy>(),
                ModContent.ItemType<Items.Boss.Triplets.SpazmatorTrophy>()},
                    new List<int> {ItemID.Lens,
                ItemID.BlackLens,
                ItemID.SoulofLight,
                ItemID.SoulofSight,
				//ModContent.ItemType<Items.Boss.Triplets.BagShard>(), 
				ModContent.ItemType<Items.Boss.Triplets.ThrowableRetina>(),
				ModContent.ItemType<Items.Boss.Triplets.Trieyed>(),
                ModContent.ItemType<Items.Boss.Triplets.TripletsShield>(),
                ModContent.ItemType<Items.Boss.Triplets.TripletsBag>(),
                ItemID.LunarOre},
                    $"Can be Spawned manualy with a [i:{ModContent.ItemType<Items.Boss.Triplets.LuminiteEye>()}] after defeating MoonLord.",
                    "The Triplets leave after their Revenge",
                    "MartainsOrder/NPCs/BCI/Triplets",
                    //"MartainsOrder/NPCs/BCI/TripletsHead",
                    null,
                    (Func<bool>)(() => true));
					
                bossChecklist.Call(
                "AddBoss",
                    15.6f,
                    ModContent.NPCType<NPCs.CrimsonPillar.CrimsonPillar>(),
                    this, // Mod
                    "Crimson Pillar",
                    (Func<bool>)(() => MartainWorld.downedCrimsonPillar),
                    ModContent.ItemType<Items.Boss.CrimsonPillar.CrimsonSigil>(),
                    ModContent.ItemType<Items.Boss.CrimsonPillar.CrimsonTrophy>(),
                    new List<int> {ItemID.CrimtaneOre,
                ItemID.CrimsonSeeds,
                ItemID.TissueSample,
                ItemID.SoulofNight,
                ModContent.ItemType<Items.Boss.CrimsonPillar.CrimsonBag>(),
                ModContent.ItemType<Items.Boss.CrimsonPillar.BrainGun>(),
                ModContent.ItemType<Items.Boss.CrimsonPillar.IchorContainer>()},
                    $"Can be Spawned manualy with a [i:{ModContent.ItemType<Items.Boss.CrimsonPillar.CrimsonSigil>()}] after defeating MoonLord.",
                    "The Crimson Pillar completed it's mision succesfully",
                    "MartainsOrder/NPCs/BCI/CrimsonPillar",
                    "MartainsOrder/NPCs/BCI/CrimsonPillarHead",
                    (Func<bool>)(() => !WorldGen.crimson));
					
                bossChecklist.Call(
                "AddBoss",
                    15.65f,
                    ModContent.NPCType<NPCs.CorruptionPillar.CorruptionPillar>(),
                    this, // Mod
                    "Corruption Pillar",
                    (Func<bool>)(() => MartainWorld.downedCorruptionPillar),
                    ModContent.ItemType<Items.Boss.CorruptionPillar.CorruptedSigil>(),
                    ModContent.ItemType<Items.Boss.CorruptionPillar.CorruptedTrophy>(),
                    new List<int> {ItemID.DemoniteOre,
                ItemID.CorruptSeeds,
                ItemID.ShadowScale,
                ItemID.SoulofNight,
                ModContent.ItemType<Items.Boss.CorruptionPillar.CorruptedBag>(),
                ModContent.ItemType<Items.Boss.CorruptionPillar.EoWWhip>(),
                ModContent.ItemType<Items.Boss.CorruptionPillar.CursedFlamesFlesh>()},
                    $"Can be Spawned manualy with a [i:{ModContent.ItemType<Items.Boss.CorruptionPillar.CorruptedSigil>()}] after defeating MoonLord.",
                    "The Crimson Pillar completed it's mision succesfully",
                    "MartainsOrder/NPCs/BCI/CorruptionPillar",
                    "MartainsOrder/NPCs/BCI/CorruptionPillarHead",
                    (Func<bool>)(() => WorldGen.crimson));
					
                bossChecklist.Call(
                "AddBoss",
                    15.7f,
                    new List<int> { ModContent.NPCType<NPCs.JungleDefenders.MechBee>(), ModContent.NPCType<NPCs.JungleDefenders.MechPlantera>() },
                    this, // Mod
                    "Jungle Defenders",
                    (Func<bool>)(() => MartainWorld.downedJungleDefenders),
                    ModContent.ItemType<Items.Boss.JungleDefenders.JunglesLastTreasure>(),
                    new List<int> { ModContent.ItemType<Items.Boss.JungleDefenders.MechPlanteraTrophy>(), ModContent.ItemType<Items.Boss.JungleDefenders.MechBeeTrophy>() },
                    new List<int> {ItemID.JungleSpores,
                ItemID.GreenSolution,
                ItemID.SoulofFlight,
                ModContent.ItemType<Items.Boss.JungleDefenders.WaspWarden>(),
                ModContent.ItemType<Items.Boss.JungleDefenders.HornetSniper>(),
                ModContent.ItemType<Items.Boss.JungleDefenders.UranusMagnumator>(),
                ModContent.ItemType<Items.Boss.JungleDefenders.SalvageHoneyWhip>(),
                ModContent.ItemType<Items.Boss.JungleDefenders.JungleDefendersBag>(),
                ModContent.ItemType<Items.Boss.JungleDefenders.JungleHeart>()},
                    $"Can be Spawned manualy in the Jungle with a [i:{ModContent.ItemType<Items.Boss.JungleDefenders.JunglesLastTreasure>()}] after defeating MoonLord.",
                    "The Jungle's Defense protocol succeded",
                    "MartainsOrder/NPCs/BCI/JungleDefenders",
                    //"MartainsOrder/NPCs/BCI/JungleDefendersHead",
                    null,
                    (Func<bool>)(() => true));
					
                bossChecklist.Call(
                "AddMiniBoss",
                    9.1f,
                    ModContent.NPCType<NPCs.GarnetCluster>(),
                    this, // Mod
                    "Garnet Flower Cluster",
                    (Func<bool>)(() => MartainWorld.downedGarnetFlowerCluster),
                    null,
                    null,
                    new List<int> { ModContent.ItemType<Items.Garnet.GarnetBar>(),
					ModContent.ItemType<Items.Garnet.GarnetCore>()
					},
                    "Naturally spawns underground, except for the Jungle, Desert or Dungeon.",
                    "The Garnet Flower Cluster sumerged into the earth",
                    "MartainsOrder/NPCs/GarnetCluster",
                    "MartainsOrder/NPCs/BCI/GarnetClusterHead",
                    (Func<bool>)(() => true));
					
				bossChecklist.Call(
                "AddMiniBoss",
                    14.5f,
                    ModContent.NPCType<NPCs.Void.VoidElemental>(),
                    this, // Mod
                    "Void Elemental",
                    (Func<bool>)(() => MartainWorld.downedVoidElemental),
                    null,
                    null,
                    new List<int> { ModContent.ItemType<Items.Void.VoidBiomeFlask>()
					},
                    "Naturally spawns at tall heights after Defeating the Moonlord.",
                    "It left...",
                    "MartainsOrder/NPCs/BCI/VoidElemental",
                    "MartainsOrder/NPCs/BCI/VoidElementalHead",
                    (Func<bool>)(() => true));
					
                bossChecklist.Call(
				"AddToBossLoot", 
				this, 
				//"$" + GetNPC("PuritySpirit").DisplayName.Key, 
				"QueenBee",
				new List<int> { ModContent.ItemType<Items.Beehaw>(),
					});				
				bossChecklist.Call(
				"AddToBossLoot", 
				this, 
				"WallofFlesh", 
				new List<int> { ModContent.ItemType<Items.Accesories.TosserEmblem>(),
				ModContent.ItemType<Items.Accesories.NeutralEmblem>(),
					});
            }
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Copper Bar", new int[]
            {
                ItemID.CopperBar,
                ItemID.TinBar,
            });
            RecipeGroup.RegisterGroup("MartainsOrder:CopperBar", group);
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {

            if (NPC.AnyNPCs(NPCType("PrinceSlime")))
            {
                music = MusicID.Boss1;
                priority = MusicPriority.BossHigh;
            }
            if (NPC.AnyNPCs(NPCType("Retinator")))
            {
                music = MusicID.Boss2;
                priority = MusicPriority.BossHigh;
            }
            if (NPC.AnyNPCs(NPCType("Spazmator")))
            {
                music = MusicID.Boss2;
                priority = MusicPriority.BossHigh;
            }
            if (NPC.AnyNPCs(NPCType("Evoxator")))
            {
                music = MusicID.Boss2;
                priority = MusicPriority.BossHigh;
            }
            if (NPC.AnyNPCs(NPCType("CrimsonPillar")))
            {
                music = MusicID.Boss4;
                priority = MusicPriority.BossHigh;
            }
            if (NPC.AnyNPCs(NPCType("CorruptionPillar")))
            {
                music = MusicID.Boss4;
                priority = MusicPriority.BossHigh;
            }

            if (Main.myPlayer != -1 && !Main.gameMenu)
            {
                if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ZoneVoid == true) //this makes the music play only in Custom Biome
                {
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/MartainsOrderVoidBiome");  //add where is the custom music is located
					priority = MusicPriority.BiomeHigh;
                }
            }
			if (Main.myPlayer != -1 && !Main.gameMenu)
            {
                if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ZoneVoid == true && Main.player[Main.myPlayer].ZoneRockLayerHeight)
                {
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/MartainsOrderVoidUg");
					priority = MusicPriority.BiomeHigh;
                }
            }
			if (Main.myPlayer != -1 && !Main.gameMenu)
            {
                if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ZoneWoods == true)
                {
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/MartainsOrderDeepWoods");
					priority = MusicPriority.BiomeHigh;
                }
            }
            UpdateMusic(ref music);

        }

        public override void ModifyLightingBrightness(ref float scale)
        {
			if(Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().voidBonus == false) {
            //if (Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ZoneVoid == true)
            //{
                //if (MartainWorld.voidTiles > 0) scale = 0.95f;
                //if (MartainWorld.voidTiles > 55) scale = 0.875f;
                //if (MartainWorld.voidTiles > 155) scale = 0.80f;
                //if (MartainWorld.voidTiles > 255) scale = 0.75f;
				scale = ((scale-(MartainWorld.voidTiles/1275f))+1f)/2f;
			if(scale < 0f)scale += 0.01f;
            //}
			if(scale <= 0.15f) scale = 0.15f;
			}
        }

        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
			if(Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().voidBonus == false) {
            if (Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ZoneVoid == true)
            {
                if (MartainWorld.voidTiles <= 0)
                {
                    return;
                }

                float voidLight = MartainWorld.voidTiles / 200f;
                voidLight = Math.Min(voidLight, 1f);

                int voidR = backgroundColor.R; int voidG = backgroundColor.G; int voidB = backgroundColor.B;
                voidR -= (int)(150f * voidLight * (backgroundColor.R / 255f));
                voidG -= (int)(150f * voidLight * (backgroundColor.G / 255f));
                voidB -= (int)(150f * voidLight * (backgroundColor.B / 255f));
                voidR = Utils.Clamp(voidR, 15, 255);
                voidG = Utils.Clamp(voidG, 15, 255);
                voidB = Utils.Clamp(voidB, 15, 255);
                backgroundColor.R = (byte)voidR; backgroundColor.G = (byte)voidG; backgroundColor.B = (byte)voidB;
                tileColor.R = (byte)voidR; tileColor.G = (byte)voidG; tileColor.B = (byte)voidB;
            }
			}
			if (Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ZoneWoods == true)
            {
				if (MartainWorld.woodsTiles <= 0)
                {
                    return;
                }

                float dwLight = MartainWorld.woodsTiles / 175f;
                dwLight = Math.Min(dwLight, 1.05f);

                int dwR = backgroundColor.R; int dwG = backgroundColor.G; int dwB = backgroundColor.B;
				
				if(!MartainWorld.forestSpirits) {
				dwR += (int)(-10f * dwLight * (backgroundColor.R / 255f));
                dwG += (int)(25f * dwLight * (backgroundColor.G / 255f)); dwG += 1;
                dwB += (int)(85f * dwLight * (backgroundColor.B / 255f)); dwB += 2;
                dwR = Utils.Clamp(dwR, 20, 255);
                dwG = Utils.Clamp(dwG, 20, 255);
                dwB = Utils.Clamp(dwB, 30, 255);
                backgroundColor.R = (byte)dwR; backgroundColor.G = (byte)dwG; backgroundColor.B = (byte)dwB;
                tileColor.R = (byte)dwR; tileColor.G = (byte)dwG; tileColor.B = (byte)dwB;
				}
				else {
                dwR += (int)(-5f * dwLight * (backgroundColor.R / 255f));
                dwG += (int)(-3f * dwLight * (backgroundColor.G / 255f));
                dwB += (int)(200f * dwLight * (backgroundColor.B / 255f)); dwB += 3;
                dwR = Utils.Clamp(dwR, 25, 255);
                dwG = Utils.Clamp(dwG, 25, 255);
                dwB = Utils.Clamp(dwB, 65, 255);
                backgroundColor.R = (byte)dwR; backgroundColor.G = (byte)dwG; backgroundColor.B = (byte)dwB;
                tileColor.R = (byte)dwR; tileColor.G = (byte)dwG; tileColor.B = (byte)dwB;
				}
			}
			
        }

    }


}