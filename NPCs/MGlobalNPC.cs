using MartainsOrder.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;
using MartainsOrder;

namespace MartainsOrder.NPCs
{
    public class MGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool kunai; public bool GarnetJavelin;
        public bool garnetCurse; private bool garnetActive;
		public bool spiritFlame;
		public bool phaseGlow;
		public bool starDustEf; private int starDustCd;
		
		private int MLife; private int oldMLife;
		private int MDef; private int oldMDef;
		private float MDR; private float oldMDR;
		
		//public bool martiniteBless;

        public override void ResetEffects(NPC npc)
        {
            kunai = false;
            GarnetJavelin = false;
            garnetCurse = false;
			spiritFlame = false;
			phaseGlow = false;
			starDustEf = false;
			//martiniteBless = false;
        }

        public override void SetDefaults(NPC npc)
        {
            npc.buffImmune[mod.BuffType("Kunai")] = npc.buffImmune[BuffID.BoneJavelin];
            npc.buffImmune[mod.BuffType("GarnetJavelin")] = npc.buffImmune[BuffID.BoneJavelin];
			
			if(npc.townNPC && npc.friendly) {
			MLife=npc.lifeMax+100;
			MDef=npc.defense+30;
			MDR=npc.takenDamageMultiplier-0.10f;
			oldMLife=npc.lifeMax;
			oldMDef=npc.defense;
			oldMDR=npc.takenDamageMultiplier;}
			
			if(npc.townNPC && npc.friendly){npc.lifeRegen += 1;}
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (kunai)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int KunaiCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ModContent.ProjectileType<Projectiles.Kunai>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        KunaiCount++;
                    }
                }
                npc.lifeRegen -= KunaiCount * 2 * 3;
                if (damage < KunaiCount * 3)
                {
                    damage = KunaiCount * 3;
                }
            }

            if (GarnetJavelin)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int GarnetJavelinCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ModContent.ProjectileType<Projectiles.GarnetJavelin>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        GarnetJavelinCount++;
                    }
                }
                npc.lifeRegen -= GarnetJavelinCount * 2 * 3;
                if (damage < GarnetJavelinCount * 3)
                {
                    damage = GarnetJavelinCount * 3;
                }
            }

            if (garnetCurse)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                //npc.lifeRegen -= 16;
                if (damage < 2)
                {
                    damage = 2;
                }
            }
			if (spiritFlame)
			{
				if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 2;
			}
			
			///////////////////////////////////////////////////////////////////////////
			
			if (MartainWorld.martiniteBless && npc.townNPC && npc.friendly)
            {
                npc.defense = MDef;
                npc.takenDamageMultiplier = MDR;
                npc.lifeMax = MLife;
            }
			if (!MartainWorld.martiniteBless && npc.townNPC && npc.friendly) {
				npc.defense = oldMDef;
                npc.takenDamageMultiplier = oldMDR;
                npc.lifeMax = oldMLife;
			}
			
			if(garnetCurse && !garnetActive) {
				npc.takenDamageMultiplier = (npc.takenDamageMultiplier+0.05f);
				garnetActive = true;
			}
			if(!garnetCurse && garnetActive) {
				garnetActive = false;
			}
			
			if(starDustEf)starDustCd++;
			for(int i = 0; i < 200; i++)
            {
            Player player = Main.player[i];
			if(starDustEf && starDustCd >= 15 && player.active) {
			Projectile.NewProjectile(npc.position.X+Main.rand.Next(-20,(npc.width+20)), npc.position.Y+Main.rand.Next(-20,(npc.height+20)), Main.rand.NextFloat(-2,3), Main.rand.NextFloat(-2,3), mod.ProjectileType("StarConstStar"), 50, 4f, i, 0f, 0f);
			starDustCd=0;}
			}
			
			if(npc.life > npc.lifeMax)npc.life = npc.lifeMax;
        }


        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
			for(int i = 0; i > 200; i++) { NPC npc = Main.npc[i];
            if (Main.hardMode)
            {
                spawnRate += (spawnRate / 5);
                maxSpawns += (maxSpawns / 5);
            }
            if (Main.expertMode)
            {
                spawnRate += (spawnRate / 20);
                maxSpawns += (maxSpawns / 20);
            }
			if(Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ZoneWoods && npc.type != NPCID.Firefly && !MartainWorld.forestSpirits)
			{
				spawnRate -= (spawnRate / 2);
                maxSpawns -= (maxSpawns / 2);
			}
			}
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (garnetCurse)
            {
                if (Main.rand.Next(5) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 60, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.dust[dust].scale *= 1f;
                    dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 109, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, Color.Black, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.dust[dust].scale *= 1f;
                }
                Lighting.AddLight(npc.Center, 0.5f, 0.2f, 0.2f);
                drawColor.R += (byte)(drawColor.R / 2);
                drawColor.G += (byte)(-drawColor.G / 2);
                drawColor.B += (byte)(-drawColor.B / 2);
            }
			if (spiritFlame)
			{
				if (Main.rand.Next(5) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 59, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.9f;
                    Main.dust[dust].velocity.Y -= 0.4f;
                    Main.dust[dust].scale = 1.8f;
                }
                Lighting.AddLight(npc.Center, 0.3f, 0.3f, 0.6f);
                drawColor.R += (byte)(-drawColor.R / 2);
                drawColor.G += (byte)(-drawColor.G / 2);
                drawColor.B += (byte)(drawColor.B / 2);
			}
			if(phaseGlow)
			{/*Color ledLight = Main.DiscoColor;
				Lighting.AddLight(npc.Center, ledLight.R/255+0.5f, ledLight.G/255+0.5f, ledLight.B/255+0.5f);
                drawColor.R = (byte)(150+Main.DiscoColor.R);
                drawColor.G = (byte)(150+Main.DiscoColor.G);
                drawColor.B = (byte)(150+Main.DiscoColor.B);*/
				Lighting.AddLight(npc.Center, 0.65f, 0.65f, 0.65f);
                drawColor.R = (byte)(255);
                drawColor.G = (byte)(255);
                drawColor.B = (byte)(255);
			}
        }
		
        public override void SetupShop(int type, Chest shop, ref int nextSlot) {
			/*if (type == NPCID.Dryad) {
				
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.CarKey>());
				nextSlot++;
				
				//shop.item[nextSlot].SetDefaults(mod.ItemType<Items.CarKey>());
				//shop.item[nextSlot].shopCustomPrice = 2;
				//shop.item[nextSlot].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				//nextSlot++;
			}
			else if (type == NPCID.Wizard && Main.expertMode) {
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Infinity>());
				nextSlot++;
			}
			else if (type == NPCID.Stylist) {
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.ExampleHairDye>());
				nextSlot++;
			}*/
			if(type == NPCID.Steampunker) {
				shop.item[nextSlot].SetDefaults(ItemID.Wire);
				shop.item[nextSlot].shopCustomPrice = 300;
				nextSlot++;
				if(Main.LocalPlayer.ZoneJungle) {
					shop.item[nextSlot].SetDefaults(mod.ItemType("MoisturizerSolution"));
					nextSlot++;
				}
				if(MartainWorld.downedVoidElemental) {
					shop.item[nextSlot].SetDefaults(mod.ItemType("FillerSolution"));
					nextSlot++;
				}
				if(Main.LocalPlayer.GetModPlayer<MyPlayer>().ZoneVoid) {
					shop.item[nextSlot].SetDefaults(mod.ItemType("VoidSolution"));
					nextSlot++;
				}
				shop.item[nextSlot].SetDefaults(mod.ItemType("ScrewsnGearsBag"));
				nextSlot++;
			}
			if(type == NPCID.ArmsDealer) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("Microshark"));
				nextSlot++;
			}
			if(type == NPCID.Demolitionist) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("Firecrakers"));
				nextSlot++;
			}
			if(type == NPCID.WitchDoctor && Main.hardMode) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("LifeTotem"));
				nextSlot++;
			}
		}
		
		public override void GetChat(NPC npc, ref string chat) {
			if (npc.type == NPCID.Stylist && Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(2)) {
					case 0:
						chat = "Thats stinkier than usual...";
						break;
					default:
						chat = "Get some perfume next time!";
						break;
				}
			}
			else if (npc.type == NPCID.DyeTrader && Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(2)) {
					case 0:
						chat = "You look and smell terrible now";
						break;
					default:
						chat = "Color me disgusted";
						break;
				}
			}
			else if (npc.type == NPCID.Cyborg && Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(2)) {
					case 0:
						chat = "My systems detect high levels of argon";
						break;
					default:
						chat = "01000101 01110111";
						break;
				}
			}
			else if (npc.type == NPCID.Guide && Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(2)) {
					case 0:
						chat = "You did not take the path i sent you on...";
						break;
					default:
						chat = "Get some perfume, but maybe not from Terraria Vanilla";
						break;
				}
			}
			else if (npc.type == NPCID.Painter && Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(2)) {
					case 0:
						chat = "...I reather smell paint than that";
						break;
					default:
						chat = "Thank Xeroc im used to these smells...";
						break;
				}
			}
			else if (npc.type == NPCID.Pirate && Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(2)) {
					case 0:
						chat = "Arg-Argh! That stinks!";
						break;
					default:
						chat = "Get off my ship!";
						break;
				}
			}
			else if (npc.type == NPCID.Nurse && Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(2)) {
					case 0:
						chat = "Another living corpse";
						break;
					default:
						chat = "Smells like the morge";
						break;
				}
			}
			else if (npc.type == NPCID.Dryad && Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(2)) {
					case 0:
						chat = "Nature may- ough... you should put some aloe on";
						break;
					default:
						chat = "Farms smell better that this, and they also help the enviroment";
						break;
				}
			}
			else if (npc.type == NPCID.Angler && Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(2)) {
					case 0:
						chat = "Fish? Where?";
						break;
					default:
						chat = "Come to me like that again and I might confuse you with actual fish";
						break;
				}
			}
			else if (Main.LocalPlayer.HasBuff(BuffID.Stinky) && npc.type != mod.NPCType("Martin") && npc.type != mod.NPCType("Cook") && npc.type != mod.NPCType("Gamer") && npc.type != mod.NPCType("Explorer") && npc.type != mod.NPCType("Slime Merchant")){
				switch (Main.rand.Next(7)) {
					case 0:
						chat = "That smells!";
						break;
					case 1:
						chat = "Just... keep you distance";
						break;
					case 2:
						chat = "Who farted?";
						break;
					case 3:
						chat = "Egh- That's... new";
						break;
					case 4:
						chat = "What a horrid smell!";
						break;
					case 5:
						chat = "That is a no-no";
						break;
					default:
						chat = "Eugh! That's too much";
						break;
				}
			}
		}
		
		/*public override bool PreChatButtonClicked(NPC npc, bool firstButton) {
			return !Main.LocalPlayer.HasBuff(BuffID.Stinky);
		}*/
		
		
		public override bool PreNPCLoot(NPC npc) {
			if(npc.type == NPCID.EyeofCthulhu && !NPC.downedBoss1) {
					Main.NewText("You feel a warm pressence on the forest", 50, 200, 0, false);
			}
            return true;
        }
		public override void NPCLoot(NPC npc)
        {
            if (npc.life <= 0)
            {
				/*for(int i = 0; i < Main.maxPlayers; i++)
				{
					Player player = Main.player[i];
					if (player.active && npc.damage > 0 && !npc.friendly && npc.lifeMax > 1 && Main.rand.Next(2)==0 
					&& player.ZoneOverworldHeight && player.ZoneDesert)
					{
						Item.NewItem(npc.getRect(), mod.ItemType("DesertExtract"), 1);
					}
				}*/
				
                if(npc.type == NPCID.MoonLordCore) {
					Item.NewItem(npc.getRect(), (mod.ItemType("FillerBiomeFlask")), 3);
					Item.NewItem(npc.getRect(), (mod.ItemType("ForestBiomeFlask")), 3);
				}
				
				//if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>().ZoneVoid && Main.rand.Next(4)== 0 && npc.damage > 0 && !npc.dontTakeDamage && !npc.dontCountMe) {
				//	Item.NewItem(npc.getRect(), (mod.ItemType("EmptySoul")), 1);
				//}
				if ((npc.type == NPCID.AngryBones || npc.type == NPCID.DarkCaster) && NPC.downedBoss3 && Main.rand.Next(2)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("DustyGarment"), 1);
				}
				
				
				
				if (npc.type == NPCID.AngryNimbus && Main.rand.Next(5)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("NimbusMedal"), 1);
				}
				if (npc.type == NPCID.Clown && Main.rand.Next(5)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("EnragedBlood"), 1);
				}
				if ((npc.type == NPCID.AngryTrapper || npc.type == NPCID.ManEater && Main.hardMode) && Main.rand.Next(5)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("FlowerCrystal"), 1);
				}
				
				if ((npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.SnowFlinx) && NPC.downedBoss2 && Main.rand.Next(10)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("FrigidEgg"), 1);
				}
				
				if (npc.type == NPCID.KingSlime && !Main.expertMode && Main.rand.Next(2)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("DankScroll"), 1);
				}
				if ((npc.type == NPCID.Snatcher || npc.type == NPCID.ManEater) && Main.rand.Next(10)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("MahoganyScroll"), 1);
				}
				if(Main.bloodMoon && Main.rand.Next(50)==0 && !npc.friendly) {
					Item.NewItem(npc.getRect(), mod.ItemType("SanguineScroll"), 1);
				}
				
				if (npc.type == NPCID.GoblinSummoner && Main.rand.Next(3)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("VoodooJets"), 1);
				}
				if (npc.type == NPCID.GoblinArcher && Main.hardMode && Main.rand.Next(15)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("HomingSight"), 1);
				}
				
				if (npc.type == NPCID.Demon && Main.rand.Next(10)==0 || npc.type == NPCID.RedDevil && Main.rand.Next(11)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("DemonHorns"), 1);
				}
				if (npc.type == NPCID.QueenBee && !Main.expertMode && Main.rand.Next(2)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("Beehaw"), 1);
				}
				if (npc.type == NPCID.WallofFlesh && !Main.expertMode && Main.rand.Next(6)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("TosserEmblem"), 1);
				}
				if (npc.type == NPCID.WallofFlesh && !Main.expertMode && Main.rand.Next(6)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("NeutralEmblem"), 1);
				}
				if (npc.type == NPCID.BigMimicHallow && !Main.expertMode && Main.rand.Next(4)==0) {
				Item.NewItem(npc.getRect(), mod.ItemType("IlluminantOrb"), 1);
				}
				
				if(!MartainWorld.extractsActive && npc.lifeMax > 20) {
					Item.NewItem(npc.getRect(), ItemID.CopperCoin, Main.rand.Next(1,11));
				}
				if(Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ammoBelt == true && Main.rand.Next(3)==0) {
					Item.NewItem(npc.getRect(), mod.ItemType("AmmoCartridge"), 1);
				}	
				
				
				if (npc.type == NPCID.KingSlime && !MartainWorld.zincGen && !NPC.downedSlimeKing) {
					Main.NewText("Chunks of Zinc have leaked into the world", 100, 100, 100);
                    for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
					{
						int x = WorldGen.genRand.Next(0, Main.maxTilesX);
						int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY + 100);
						Tile tile = Framing.GetTileSafely(x,y);
						int type = (int)Main.tile[x, y].type;
						if (tile.active() && TileID.Sets.Conversion.Stone[type])
						{
						WorldGen.TileRunner(x, y, WorldGen.genRand.Next(10, 21), WorldGen.genRand.Next(6, 12), TileType<ZincOre>());
						}
					}
					MartainWorld.zincGen = true;
				}
				if (npc.type == NPCID.WallofFlesh && !MartainWorld.tantalumGen && !Main.hardMode) {
					Main.NewText("Chunks of Tantalum have fused into the world", 235, 190, 170);
                    for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
					{
						int x = WorldGen.genRand.Next(0, Main.maxTilesX);
						int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY);
						Tile tile = Framing.GetTileSafely(x,y);
						int type = (int)Main.tile[x, y].type;
						if (tile.active() && TileID.Sets.Conversion.Stone[type])
						{
						WorldGen.TileRunner(x, y, WorldGen.genRand.Next(6, 12), WorldGen.genRand.Next(8, 15), TileType<TantalumOre>());
						}
					}
					MartainWorld.tantalumGen = true;
				}
				
            }
        }
    }
}
