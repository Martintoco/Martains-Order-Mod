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
        public override void Load()
        {
            // Will show up in client.log under the ExampleMod name
            Logger.InfoFormat("{0} example logging", Name);

            // All code below runs only if we're not loading on a server
            if (!Main.dedServ)
            {
                // Add certain equip textures
                AddEquipTexture(null, EquipType.Legs, "CoalRobe_Legs", "MartainsOrder/Items/Coal/CoalRobe_Legs");
            }
        }

        public override void Unload()
        {
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
                "AddBoss",
                    15.5f,
                    ModContent.NPCType<NPCs.PrinceSlime.PrinceSlime>(),
                    this, // Mod
                    "Prince Slime",
                    (Func<bool>)(() => MartainWorld.downedPrinceSlime),
                    ModContent.ItemType<Items.PrinceSlime.LuminiteSlimeCrown>(),
                    new List<int> { ModContent.ItemType<Items.PrinceSlime.PrinceSlimeTrophy>()/*, ModContent.ItemType<Items.WolfMask>()*/},
                    new List<int> {ItemID.Gel,
                ItemID.PinkGel,
                ModContent.ItemType<Items.PrinceSlime.PrinceHook>(),
                ModContent.ItemType<Items.PrinceSlime.PrinceSlimeBag>(),
                ModContent.ItemType<Items.PrinceSlime.PrinceSlimeMount>(),
                ModContent.ItemType<Items.PrinceSlime.ExiliedGel>(),
                ModContent.ItemType<Items.HyperSlimeBall>(),
                ItemID.LunarOre},
                    "Can be Spawned manualy after defeating MoonLord",
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
                    ModContent.ItemType<Items.Triplets.LuminiteEye>(),
                    new List<int> {ModContent.ItemType<Items.Triplets.EvocornatorTrophy>(),
                ModContent.ItemType<Items.Triplets.RetinatorTrophy>(),
                ModContent.ItemType<Items.Triplets.SpazmatorTrophy>()},
                    new List<int> {ItemID.Lens,
                ItemID.BlackLens,
                ItemID.SoulofLight,
                ItemID.SoulofSight,
				//ModContent.ItemType<Items.Triplets.BagShard>(), 
				ModContent.ItemType<Items.Triplets.ThrowableRetina>(),
                ModContent.ItemType<Items.Triplets.TripletsShield>(),
                ModContent.ItemType<Items.Triplets.TripletsBag>(),
                ItemID.LunarOre},
                    "Can be Spawned manualy at Night after defeating MoonLord",
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
                    ModContent.ItemType<Items.CrimsonPillar.CrimsonSigil>(),
                    ModContent.ItemType<Items.CrimsonPillar.CrimsonTrophy>(),
                    new List<int> {ItemID.CrimtaneOre,
                ItemID.CrimsonSeeds,
                ItemID.TissueSample,
                ItemID.SoulofNight,
                ModContent.ItemType<Items.CrimsonPillar.CrimsonBag>(),
                ModContent.ItemType<Items.CrimsonPillar.BrainGun>(),
                ModContent.ItemType<Items.CrimsonPillar.IchorContainer>()},
                    "Can be Spawned manualy after defeating MoonLord",
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
                    ModContent.ItemType<Items.CorruptionPillar.CorruptedSigil>(),
                    ModContent.ItemType<Items.CorruptionPillar.CorruptedTrophy>(),
                    new List<int> {ItemID.DemoniteOre,
                ItemID.CorruptSeeds,
                ItemID.ShadowScale,
                ItemID.SoulofNight,
                ModContent.ItemType<Items.CorruptionPillar.CorruptedBag>(),
                ModContent.ItemType<Items.CorruptionPillar.EoWWhip>(),
                ModContent.ItemType<Items.CorruptionPillar.CursedFlamesFlesh>()},
                    "Can be Spawned manualy after defeating MoonLord",
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
                    ModContent.ItemType<Items.JungleDefenders.JunglesLastTreasure>(),
                    new List<int> { ModContent.ItemType<Items.JungleDefenders.MechPlanteraTrophy>(), ModContent.ItemType<Items.JungleDefenders.MechBeeTrophy>() },
                    new List<int> {ItemID.JungleSpores,
                ItemID.GreenSolution,
                ItemID.SoulofFlight,
                ModContent.ItemType<Items.JungleDefenders.WaspWarden>(),
                ModContent.ItemType<Items.JungleDefenders.HornetSniper>(),
                ModContent.ItemType<Items.JungleDefenders.UranusMagnumator>(),
                ModContent.ItemType<Items.JungleDefenders.SalvageHoneyWhip>(),
                ModContent.ItemType<Items.JungleDefenders.JungleDefendersBag>(),
                ModContent.ItemType<Items.JungleDefenders.JungleHeart>()},
                    "Can be Spawned manualy in the Jungle after defeating MoonLord",
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
                    new List<int> { ModContent.ItemType<Items.Garnet.GarnetBar>() },
                    "Spawns UnderGround",
                    "The Garnet Flower Cluster sumerged into the earth",
                    "MartainsOrder/NPCs/GarnetCluster",
                    "MartainsOrder/NPCs/BCI/GarnetClusterHead",
                    (Func<bool>)(() => true));
                // Additional bosses here
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
            UpdateMusic(ref music);

        }

        public override void ModifyLightingBrightness(ref float scale)
        {
            if (Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ZoneVoid == true)
            {
                if (MartainWorld.voidTiles > 0) scale = 0.95f;
                if (MartainWorld.voidTiles > 55) scale = 0.875f;
                if (MartainWorld.voidTiles > 155) scale = 0.80f;
                if (MartainWorld.voidTiles > 255) scale = 0.75f;
            }
        }

        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
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
                voidB -= (int)(150f * voidLight * (backgroundColor.G / 255f));
                voidR = Utils.Clamp(voidR, 15, 255);
                voidG = Utils.Clamp(voidG, 15, 255);
                voidB = Utils.Clamp(voidB, 15, 255);
                backgroundColor.R = (byte)voidR; backgroundColor.G = (byte)voidG; backgroundColor.B = (byte)voidB;
                tileColor.R = (byte)voidR; tileColor.G = (byte)voidG; tileColor.B = (byte)voidB;
            }
        }

    }


}