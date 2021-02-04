using MartainsOrder.Tiles;
using System.Collections.Generic;
using System.IO;
using System;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace MartainsOrder
{
    public class MartainWorld : ModWorld
    {
        public static bool downedPrinceSlime;
        public static bool downedTriplets;
        public static bool downedCrimsonPillar;
        public static bool downedCorruptionPillar;
        public static bool downedJungleDefenders;

        public static bool downedGarnetFlowerCluster;

        public static int ModTiles;
        //public static int astralTiles;
        public static int voidTiles;
		
		public static bool martiniteBless = false;

        public override void Initialize()
        {
            downedPrinceSlime = false;
            downedTriplets = false;
            downedCrimsonPillar = false;
            downedCorruptionPillar = false;
            downedJungleDefenders = false;
			//martiniteBless = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedPrinceSlime)
            {
                downed.Add("PrinceSlime");
            }

            if (downedTriplets)
            {
                downed.Add("Retinator");
                downed.Add("Spazmator");
                downed.Add("Evoxator");
            }

            if (downedCrimsonPillar)
            {
                downed.Add("CrimsonPillar");
            }

            if (downedCorruptionPillar)
            {
                downed.Add("CorruptionPillar");
            }

            if (downedJungleDefenders)
            {
                downed.Add("MechBee");
                downed.Add("MechPlantera");
            }

            return new TagCompound
            {
                ["downed"] = downed,
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedPrinceSlime = downed.Contains("PrinceSlime");
            downedTriplets = downed.Contains("Triplets");
            downedCrimsonPillar = downed.Contains("CrimsonPillar");
            downedCorruptionPillar = downed.Contains("CorruptionPillar");
            downedJungleDefenders = downed.Contains("JungleDefenders");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedPrinceSlime = flags[0];
                downedTriplets = flags[1];
            }
            else
            {
                mod.Logger.WarnFormat("MartainsOrder: Unknown loadVersion: {0}", loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = downedPrinceSlime;
            flags[1] = downedTriplets;
            writer.Write(flags);

        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedPrinceSlime = flags[0];
            downedTriplets = flags[1];
            downedCrimsonPillar = flags[2];
            downedCorruptionPillar = flags[3];
            // As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
            // BitsByte flags2 = reader.ReadByte();
            // downed9thBoss = flags[0];
        }

        public override void ResetNearbyTileEffects()
        {
            MyPlayer modPlayer = Main.LocalPlayer.GetModPlayer<MyPlayer>();
            //modPlayer.voidMonolith = false;
            //astralTiles = 0;
            voidTiles = 0;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            //astralTiles = tileCounts[mod.TileType("AstralGrass")];
            //astralTiles = tileCounts[mod.TileType("AstralMeteorite")];
            voidTiles = tileCounts[mod.TileType("VoidGrass")] + tileCounts[mod.TileType("VoidSand")] + tileCounts[mod.TileType("VoidStone")];
        }

        // We use this hook to add 3 steps to world generation at various points. 
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            // Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

            // The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
            // First, we find out which step "Shinies" is.
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex != -1)
            {
                // Next, we insert our step directly after the original "Shinies" step. 
                // ExampleModOres is a method seen below.
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Adding More Shinies...", MartainsOres));
            }

            int RocksDirtIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Rocks In Dirt"));
            //int RocksDirtIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            if (RocksDirtIndex != -1)
            {
                tasks.Insert(RocksDirtIndex + 1, new PassLegacy("Adding Stone Variants...", MartainsStones));
            }

            //int MicroBiomeIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            int ShiniesIndex2 = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex2 != -1)
            {
                tasks.Insert(ShiniesIndex2 + 1, new PassLegacy("Adding More Stone Variants...", MartainsStones2));
            }
			
			int GemIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Gems"));
            if (GemIndex != -1)
            {
                tasks.Insert(GemIndex + 1, new PassLegacy("Adding Core Blocks...", MartainsGems));
            }

            /*int snowGenIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Ice"));
            tasks.Insert(snowGenIndex + 1, new PassLegacy("Gelid Stone Blobs", delegate (GenerationProgress progress)
            {
				for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
					public int xlol = WorldGen.genRand.Next(0, Main.maxTilesX)
					public int ylol = WorldGen.genRand.Next((int)WorldGen.rockLayer-100, Main.maxTilesY-100)
				Tile tile = Framing.GetTileSafely(xlol, ylol);
				if (tile.active() && tile.type == TileID.IceBlock)
				{
                WorldGen.TileRunner(xlol, ylol, WorldGen.genRand.Next(50, 100), WorldGen.genRand.Next(50, 100), mod.TileType("GelidStone"), true, 0f, 0f, false, true);
				}
			}
            }));*/
        }

        private void MartainsOres(GenerationProgress progress)
        {
            // progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
            progress.Message = "Adding Martain's Ores...";

            // Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
            // "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                // The inside of this for loop corresponds to one single splotch of our Ore.
                // First, we randomly choose any coordinate in the world by choosing a random x and y value.
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY + 100); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

                // Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(7, 12), WorldGen.genRand.Next(9, 16), TileType<ZincOre>());
                // Alternately, we could check the tile already present in the coordinate we are interested. Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Snow.
                // Tile tile = Framing.GetTileSafely(x, y);
                // if (tile.active() && tile.type == TileID.SnowBlock)
                // {
                // 	WorldGen.TileRunner(.....);
                // }
            }
            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY);
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(6, 12), WorldGen.genRand.Next(9, 16), TileType<TantalumOre>());
            }

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurface, Main.maxTilesY);
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(9, 13), TileType<Coal>());
            }

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(7, 14), mod.TileType("Geode"));
            }

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayerHigh, Main.maxTilesY - 200);
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(9, 13), TileType<Coal>());
            }



            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayerHigh, Main.maxTilesY - 200);
                //Tile tile = Framing.GetTileSafely(x, y);
                //if (tile.active() && tile.type == TileID.Dirt)
                //{
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(7, 10), 60);
                //}
            }

        }

        private void MartainsStones(GenerationProgress progress)
        {
            progress.Message = "Adding Martain's Stone Variants...";

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY);

                //Tile tile = Framing.GetTileSafely(
                //WorldGen.genRand.Next(0, Main.maxTilesX), 
                //WorldGen.genRand.Next((int)WorldGen.rockLayer + 200, Main.maxTilesY + 200)
                //);
                //if (tile.active() && tile.type == TileID.Stone)
                //{
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(70, 115), WorldGen.genRand.Next(41, 91), mod.TileType("HardStone"), false, 0f, 0f, false, true);
                //}

            }

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayerHigh, Main.maxTilesY - 300);
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(8, 30), WorldGen.genRand.Next(26, 66), mod.TileType("ClayStone"), false, 0f, 0f, false, true);
            }
        }
		
        private void MartainsStones2(GenerationProgress progress2)
        {
            progress2.Message = "Adding more Martain's Stone Variants...";

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int i = WorldGen.genRand.Next(0, Main.maxTilesX);
                int j = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, (int)Main.maxTilesY - 100);

                Tile tile = QuickFraming(i, j);
                if (tile.active() && tile.type == TileID.IceBlock)
                {
                    WorldGen.TileRunner(i, j, WorldGen.genRand.Next(26, 75), WorldGen.genRand.Next(21, 78), mod.TileType("GelidStone"), false, 0f, 0f, false, true);
                }

            }

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int i = WorldGen.genRand.Next(0, Main.maxTilesX);
                int j = WorldGen.genRand.Next((int)WorldGen.rockLayerHigh, (int)Main.maxTilesY - 100);

                Tile tile = QuickFraming(i, j);
                if (tile.active() && tile.type == TileID.HardenedSand)
                {
                    WorldGen.TileRunner(i, j, WorldGen.genRand.Next(31, 83), WorldGen.genRand.Next(38, 83), mod.TileType("AridStone"), false, 0f, 0f, false, true);
                }
                if (tile.active() && tile.type == TileID.Sand)
                {
                    WorldGen.TileRunner(i, j, WorldGen.genRand.Next(30, 81), WorldGen.genRand.Next(35, 79), mod.TileType("AridStone"), false, 0f, 0f, false, true);
                }

            }
        }
		
		private void MartainsGems(GenerationProgress progress3)
        {
			progress3.Message = "Adding Martain's Planet Core...";
			
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int i = WorldGen.genRand.Next(0, Main.maxTilesX);
                int j = WorldGen.genRand.Next((int)Main.maxTilesY - 4, Main.maxTilesY);
                WorldGen.TileRunner(i, j, 100, 100, mod.TileType("CoreBlock"), false, 0f, 0f, false, true);
            }
        }
		
        private Tile QuickFraming(int i, int j)
        {
            return Framing.GetTileSafely(i, j);
        }
    }
}