using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MartainsOrder
{
    public class MyPlayer : ModPlayer
    {
        private const int saveVersion = 0;
		
		public bool LimeWorm;
		public bool ZincSummon;
		public bool Britling;
        public bool MElemental;
		public bool Blazer;
		public bool Guardian;
        
        public bool minionName = false;
		
		public bool fishOfSpirit;
		public bool fishOfWrath;
		public bool fishOfPurity;

        //public bool accWhipRange;
        //public bool garnetWhipRange;
		public float kbex = 0.0f;
		public float ammoSave = 0.0f;
		public float whipExtraRange = 1.0f;
		//public bool whipGlove = false;
		public float throwSave = 0.0f;
		public float summonSpeed = 1f;
		
		public bool livingSkull;
		public int livingSkullCD = 0;
		public bool tundraRose;
		
		public bool autoUse;
		public bool hookUp;
		public bool hookVoid;
		
		public bool enchantedBook;
		public bool beeWasp;
		public bool yoyoSpeed;
		public bool yoyoLight;
		public bool yoyoSpirit;
		public bool nacionalDefense;
		
		public bool aloeCream;
		public bool lifeTotem;
		public bool manaTank;
		public int manaTankCD = 0;
		public bool lessManaSick;
		public bool fireflySpirit;
		public int fireflySpiritCD = 0;

		public bool ammoBelt;
		public bool homingSight;
		public bool paperWorks;
		public bool frozenQuiver;
		
		public bool engineerBelt;
		public bool voodooJets;
		public bool spiderNesting;
		
		public bool dankScroll;
		public bool sanguineScroll;
		public bool mahoganyScroll;
		public bool firecrackers;
		public bool everfrostStone;
		public int dustTyphoon;
		
		public bool magmaBonus;
		public bool aquaBonus;
		public bool charBonus;
		public bool spirit1Bonus;
		public bool spirit2Bonus;
        public bool crystalShardsBonus;
		public bool fractalShardsBonus;
		public bool galaxyBonus;
		public bool voidBonus;

        //public bool e = false;
        //public bool o = false;
        //public static bool hasProjectile;
        //public bool examplePet = false;
        //public bool exampleLightPet = false;
        //public bool OFF;
        //public bool ZoneAstral;
        public bool ZoneVoid;
		public bool ZoneWoods;
		
		public bool blackHole;
		
        public bool garnetCurse;
		public bool spiritFlame;

        //-------RESEARCH-------//

        public int researchVelocityAcc = 0;
        public bool researchInMoveAcc;
        public int researchInMoveAccCD = 0;

        public int researchBiomeForest = 0; //spawnInfo.player.ZoneOverworldHeight
        public int researchBiomeDesert = 0; //spawnInfo.player.ZoneDesert
        public int researchBiomeSnow = 0; //spawnInfo.player.ZoneSnow
        public int researchBiomeCorrupt = 0; //spawnInfo.player.ZoneCorrupt
        public int researchBiomeCrimson = 0; //spawnInfo.player.ZoneCrimson
        public int researchBiomeHallow = 0; //spawnInfo.player.ZoneHoly
        public int researchBiomeJungle = 0; //spawnInfo.player.ZoneJungle
        public int researchBiomeHell = 0; //spawnInfo.player.ZoneUnderworldHeight
        public int researchBiomeSky = 0; //spawnInfo.player.ZoneSkyHeight
        public int researchBiomeBeach = 0; //spawnInfo.player.ZoneBeach

        public bool researchBiomeForestRecipie = false;
        public bool researchBiomeDesertRecipie = false;
        public bool researchBiomeSnowRecipie = false;
        public bool researchBiomeCorruptRecipie = false;
        public bool researchBiomeCrimsonRecipie = false;
        public bool researchBiomeHallowRecipie = false;
        public bool researchBiomeJungleRecipie = false;
        public bool researchBiomeHellRecipie = false;
        public bool researchBiomeSkyRecipie = false;
        public bool researchBiomeBeachRecipie = false;

        public bool anyResearch;
		
		//-------MECHANICS-------//
		
		public int manaCD = 0;
		
		public int voidStarStore = 0;
		
		public int summonTagDamage;
        public int summonTagCrit;
		
		public bool throwerRushOn;
		public int throwerRushValue = 0;
		public int throwerRushCD;
		public int throwerVisual = 0;
		
		//-------TRANSFORMATIONS-------//
		
		public bool monsterAccPrev;
		public bool monsterAcc;
		public bool monsterHideVanity;
		public bool monsterForceVanity;
		public bool monsterPower;
		
		public bool nimbusAccPrev;
		public bool nimbusAcc;
		public bool nimbusHideVanity;
		public bool nimbusForceVanity;
		public bool nimbusPower;
		
		public bool florianAccPrev;
		public bool florianAcc;
		public bool florianHideVanity;
		public bool florianForceVanity;
		public bool florianPower;
		
        //----------------------//

        public override void ResetEffects()
        {
			LimeWorm = false;
			ZincSummon = false;
			Britling = false;
            MElemental = false;
			Blazer = false;
			Guardian = false;
            //accWhipRange = false;
            //garnetWhipRange = false;
			whipExtraRange = 1.0f;
			ammoSave = 0.0f;
			throwSave = 0.0f;
			summonSpeed = 1f;
			
			autoUse = false;
			hookUp = false;
			hookVoid = false;
			
			enchantedBook = false;beeWasp = false;yoyoSpeed = false;yoyoLight = false;yoyoSpirit = false;nacionalDefense = false;
			livingSkull = false;tundraRose = false;
			aloeCream = false;lifeTotem = false;manaTank = false;lessManaSick = false;fireflySpirit = false;
			ammoBelt = false;homingSight = false;paperWorks = false;frozenQuiver = false;
			engineerBelt = false;voodooJets = false;spiderNesting = false;
			dankScroll = false;sanguineScroll = false;mahoganyScroll = false;firecrackers = false;everfrostStone = false;dustTyphoon = 0;
			
			magmaBonus = false;
			aquaBonus = false;
			charBonus = false;
			spirit1Bonus = false;
			spirit2Bonus = false;
            crystalShardsBonus = false;
			fractalShardsBonus = false;
			galaxyBonus = false;
			voidBonus = false;
			throwerRushCD = 1200;
            //e = false;
            //o = false;
            //examplePet = false;
            //exampleLightPet = false;
            //OFF = false;
            researchVelocityAcc = 0;
            researchInMoveAcc = false;
			
			blackHole = false;
			
			monsterAccPrev = monsterAcc;
			monsterAcc = monsterHideVanity = monsterForceVanity = monsterPower = false;
			
			nimbusAccPrev = nimbusAcc;
			nimbusAcc = nimbusHideVanity = nimbusForceVanity = nimbusPower = false;
			
			florianAccPrev = florianAcc;
			florianAcc = florianHideVanity = florianForceVanity = florianPower = false;
		}
		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
			ModPacket packet = mod.GetPacket();
			packet.Write(fishOfSpirit);
			packet.Write(fishOfWrath);
			packet.Write(fishOfPurity);
			packet.Send(toWho, fromWho);
		}
		public override TagCompound Save() {
			return new TagCompound {
				{"fishOfSpirit", fishOfSpirit},
				{"fishOfWrath", fishOfWrath},
				{"fishOfPurity", fishOfPurity},
			};
		} 
		public override void Load(TagCompound tag) {
			fishOfSpirit = tag.GetBool("fishOfSpirit");
			fishOfWrath = tag.GetBool("fishOfWrath");
			fishOfPurity = tag.GetBool("fishOfPurity");
		}
		
        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("StartBag"));
            item.stack = 1;
            items.Add(item);
			
			item = new Item();
            item.SetDefaults(mod.ItemType("BetaPlayerTrophy"));
            item.stack = 1;
            items.Add(item);
        }
		
		public float GetWeaponKnockback(Item aItem)
		{
			return (aItem.knockBack + kbex);
		}

        public override void PreUpdateBuffs()
        {
            if (researchInMoveAcc) researchInMoveAccCD++;

            if (player.ZoneOverworldHeight && !player.ZoneSnow && !player.ZoneCorrupt && !player.ZoneJungle && !player.ZoneHoly && !player.ZoneCrimson && !player.ZoneDesert && !player.ZoneGlowshroom && !player.ZoneBeach && !ZoneVoid && researchBiomeForest < 3600)
            {
                if (player.velocity.X == 0 && player.velocity.Y == 0 || researchInMoveAccCD >= 2 && researchInMoveAcc)
                {
                    researchBiomeForest += 1;
                    researchInMoveAccCD = 0;
                }
            }
            if (player.ZoneOverworldHeight && player.ZoneDesert && researchBiomeDesert < 3600)
            {
                if (player.velocity.X == 0 && player.velocity.Y == 0 || researchInMoveAccCD >= 2 && researchInMoveAcc)
                {
                    researchBiomeDesert += 1;
                    researchInMoveAccCD = 0;
                }
            }
            if (player.ZoneOverworldHeight && player.ZoneSnow && researchBiomeSnow < 3600)
            {
                if (player.velocity.X == 0 && player.velocity.Y == 0 || researchInMoveAccCD >= 2 && researchInMoveAcc)
                {
                    researchBiomeSnow += 1;
                    researchInMoveAccCD = 0;
                }
            }
            if (player.ZoneOverworldHeight && player.ZoneCorrupt && researchBiomeCorrupt < 3600)
            {
                if (player.velocity.X == 0 && player.velocity.Y == 0 || researchInMoveAccCD >= 2 && researchInMoveAcc)
                {
                    researchBiomeCorrupt += 1;
                    researchInMoveAccCD = 0;
                }
            }
            if (player.ZoneOverworldHeight && player.ZoneCrimson && researchBiomeCrimson < 3600)
            {
                if (player.velocity.X == 0 && player.velocity.Y == 0 || researchInMoveAccCD >= 2 && researchInMoveAcc)
                {
                    researchBiomeCrimson += 1;
                    researchInMoveAccCD = 0;
                }
            }
            if (player.ZoneOverworldHeight && player.ZoneHoly && researchBiomeHallow < 3600)
            {
                if (player.velocity.X == 0 && player.velocity.Y == 0 || researchInMoveAccCD >= 2 && researchInMoveAcc)
                {
                    researchBiomeHallow += 1;
                    researchInMoveAccCD = 0;
                }
            }
            if (player.ZoneOverworldHeight && player.ZoneJungle && researchBiomeJungle < 3600)
            {
                if (player.velocity.X == 0 && player.velocity.Y == 0 || researchInMoveAccCD >= 2 && researchInMoveAcc)
                {
                    researchBiomeJungle += 1;
                    researchInMoveAccCD = 0;
                }
            }
            if (player.ZoneUnderworldHeight && researchBiomeHell < 3600)
            {
                if (player.velocity.X == 0 && player.velocity.Y == 0 || researchInMoveAccCD >= 2 && researchInMoveAcc)
                {
                    researchBiomeHell += 1;
                    researchInMoveAccCD = 0;
                }
            }
            if (player.ZoneSkyHeight && researchBiomeSky < 3600)
            {
                if (player.velocity.X == 0 && player.velocity.Y == 0 || researchInMoveAccCD >= 2 && researchInMoveAcc)
                {
                    researchBiomeSky += 1;
                    researchInMoveAccCD = 0;
                }
            }
            if (player.ZoneOverworldHeight && player.ZoneBeach && researchBiomeBeach < 3600)
            {
                if (player.velocity.X == 0 && player.velocity.Y == 0 || researchInMoveAccCD >= 2 && researchInMoveAcc)
                {
                    researchBiomeBeach += 1;
                    researchInMoveAccCD = 0;
                }
            }

            //---------------------------------------------------------------------------------------------------------//

            if (researchBiomeForest >= (int)(3600 - researchVelocityAcc) && !researchBiomeForestRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeForestRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeDesert >= (int)(3600 - researchVelocityAcc) && !researchBiomeDesertRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeDesertRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeSnow >= (int)(3600 - researchVelocityAcc) && !researchBiomeSnowRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeSnowRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeCorrupt >= (int)(3600 - researchVelocityAcc) && !researchBiomeCorruptRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeCorruptRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeCrimson >= (int)(3600 - researchVelocityAcc) && !researchBiomeCrimsonRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeCrimsonRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeHallow >= (int)(3600 - researchVelocityAcc) && !researchBiomeHallowRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeHallowRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeJungle >= (int)(3600 - researchVelocityAcc) && !researchBiomeJungleRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeJungleRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeHell >= (int)(3600 - researchVelocityAcc) && !researchBiomeHellRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeHellRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeSky >= (int)(3600 - researchVelocityAcc) && !researchBiomeSkyRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeSkyRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeBeach >= (int)(3600 - researchVelocityAcc) && !researchBiomeBeachRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeBeachRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }

            //---------------------------------------------------------------------------------------------------------//

            if (researchBiomeForest > 3600) researchBiomeForest = 0;
            if (researchBiomeDesert > 3600) researchBiomeDesert = 0;
            if (researchBiomeSnow > 3600) researchBiomeSnow = 0;
            if (researchBiomeCorrupt > 3600) researchBiomeCorrupt = 0;
            if (researchBiomeCrimson > 3600) researchBiomeCrimson = 0;
            if (researchBiomeHallow > 3600) researchBiomeHallow = 0;
            if (researchBiomeJungle > 3600) researchBiomeJungle = 0;
            if (researchBiomeHell > 3600) researchBiomeHell = 0;
            if (researchBiomeSky > 3600) researchBiomeSky = 0;
            if (researchBiomeBeach > 3600) researchBiomeBeach = 0;
			
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
			if(player.endurance >= 99.99999f) player.endurance = 99.99999f;
			if(ammoSave >= 100.0f) ammoSave = 100.0f;
			if(throwSave >= 100.0f) throwSave = 100.0f;
			Player.jumpSpeed += (player.moveSpeed*0.1f);
			player.runAcceleration += (player.moveSpeed*0.01f);
			
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
			Item itemt = player.inventory[player.selectedItem];
			if(throwerRushValue > throwerRushCD && throwerRushOn == false) throwerRushValue = 1200;
			if(itemt.thrown == true){
				if(throwerRushValue < throwerRushCD && throwerRushOn == false) throwerRushValue += 1;
				if(MartainsOrder.ThrowingRush.JustPressed && throwerRushValue >= 1200 && throwerRushOn == false) {
					throwerRushOn = true;
					Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 24, 7f);
					throwerRushValue = 1200;
					CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), new Color(200, 200, 200, 50),"Rush!");//100
				}
				
				throwerVisual++;
				if(throwerVisual > 30 && !throwerRushOn) {
					if(throwerRushValue >= 0*(throwerRushCD/1200f) && throwerRushValue < 300*(throwerRushCD/1200f)) {
						Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("ThrCharge1"), 0, 0f, player.whoAmI);
					}
					if(throwerRushValue >= 300*(throwerRushCD/1200f) && throwerRushValue < 600*(throwerRushCD/1200f)) {
						Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("ThrCharge2"), 0, 0f, player.whoAmI);
					}
					if(throwerRushValue >= 600*(throwerRushCD/1200f) && throwerRushValue < 900*(throwerRushCD/1200f)) {
						Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("ThrCharge3"), 0, 0f, player.whoAmI);
					}
					if(throwerRushValue >= 900*(throwerRushCD/1200f) && throwerRushValue < 1200*(throwerRushCD/1200f)) {
						Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("ThrCharge4"), 0, 0f, player.whoAmI);
					}
					if(throwerRushValue >= 1200*(throwerRushCD/1200f)) {
						Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("ThrCharge5"), 0, 0f, player.whoAmI);
					}
					throwerVisual = 0;
				}
			}
				if(throwerRushOn == true && throwerRushValue > 0) {
					throwerRushValue -= 2;
				}
				if(throwerRushValue <= 0) throwerRushOn = false;
			if(throwerRushOn) player.thrownVelocity += ((player.thrownVelocity*0.75f)+0.25f);
			
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
			if(voidStarStore > 25)voidStarStore = 25;
			
			if(fishOfSpirit)player.runAcceleration += 0.05f;
			if(fishOfWrath)player.moveSpeed += 0.10f;
			if(fishOfPurity)player.statLifeMax2 += 50;
        }
	    public override void ProcessTriggers(TriggersSet triggersSet) {
			if (galaxyBonus && player.controlUseItem && player.controlUseTile) {
				var mousePos = Main.ReverseGravitySupport(Main.MouseScreen) + Main.screenPosition;
				if(Collision.SolidCollision(mousePos, player.width, player.height) == false && !player.HasBuff(mod.BuffType("GalaxyCD"))) {
				for(int i = 0; i < 7; i++) {
				int dust = Dust.NewDust(player.position, player.width, player.height, 66, player.velocity.X*0.5f, player.velocity.Y*0.5f, 75, Color.Purple, 0.95f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].velocity *= 2.5f;
					dust = Dust.NewDust(player.position, player.width, player.height, 66, player.velocity.X*0.5f, player.velocity.Y*0.5f, 75, Color.White, 0.95f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].velocity *= 2.5f;
				}
				
				//player.position = mousePos;
				player.Teleport(mousePos, 1);
				player.AddBuff(mod.BuffType("GalaxyCD"), 600);
				for(int i = 0; i < 7; i++) {
				int dust = Dust.NewDust(player.position, player.width, player.height, 66, player.velocity.X*0.5f, player.velocity.Y*0.5f, 75, Color.Purple, 0.95f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].velocity *= 2.5f;
					dust = Dust.NewDust(player.position, player.width, player.height, 66, player.velocity.X*0.5f, player.velocity.Y*0.5f, 75, Color.White, 0.95f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].velocity *= 2.5f;
				}
				}
			}
		}
        public virtual void PostItemCheck() {
            if (autoUse && !player.noItems && !player.inventory[player.selectedItem].channel)
			{
				player.releaseUseItem = true;
				if (player.itemAnimation == 1 && player.inventory[player.selectedItem].stack > 0)
				{
					if (player.inventory[player.selectedItem].shoot > 0 && player.whoAmI != Main.myPlayer && player.controlUseItem && player.inventory[player.selectedItem].useStyle == 5)
					{
						//player.ApplyAnimation(player.inventory[player.selectedItem]);
						if (player.inventory[player.selectedItem].UseSound != null)
						{
							Main.PlaySound(player.inventory[player.selectedItem].UseSound, player.Center);
						}
					}
					else
					{
						player.itemAnimation = 0;
					}
				}
			}
        }
		public override float UseTimeMultiplier(Item item) {
			float qUseTime = 1f;
			//if(item.thrown) {qUseTime=(qUseTime+player.thrownVelocity)/2f;}
			//if(item.summon) {qUseTime=(qUseTime+summonSpeed)/2f;}
			if(item.thrown) {qUseTime=qUseTime*player.thrownVelocity;}
			if(item.summon) {qUseTime=qUseTime*summonSpeed;}
			if(monsterPower) {qUseTime=qUseTime*1.25f;}
            return qUseTime;
        }

        public override void UpdateBiomes()
        {
            //ZoneAstral = MartainWorld.astralTiles > 50;
            ZoneVoid = MartainWorld.voidTiles > 100;
			ZoneWoods = (MartainWorld.woodsTiles > 285 && player.ZoneOverworldHeight && !player.ZoneSnow && !player.ZoneCorrupt && !player.ZoneJungle && !player.ZoneHoly && !player.ZoneCrimson && !player.ZoneDesert && !player.ZoneGlowshroom && !player.ZoneBeach && !ZoneVoid);
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneVoid)
            {
                return mod.GetTexture("VoidBiomeMapBackground");
            }
			if (ZoneWoods)
            {
                return mod.GetTexture("DeepWoodsMapBackground");
            }
            return null;
        }

        /*public override void UpdateBiomeVisuals() {
			bool useVoidMonolith = voidMonolith && !NPC.AnyNPCs(NPCID.MoonLordCore);
			player.ManageSpecialBiomeVisuals("MartainsOrder:MonolithVoid", useVoidMonolith, player.Center);
		}*/
		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) 
		{
			if(enchantedBook && item.melee == true && Main.rand.Next(5)==0) {
				Main.PlaySound(2, (int)target.Center.X, (int)target.Center.Y, 1, 1.5f, -0.05f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("Sweep"), damage/2, knockback/2f, player.whoAmI, 1+player.meleeCrit);
			}
        }
		
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			if(enchantedBook && proj.melee == true && Main.rand.Next(5)==0 && proj.type != mod.ProjectileType("Sweep")) {
				Main.PlaySound(2, (int)target.Center.X, (int)target.Center.Y, 1, 1.5f, -0.05f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("Sweep"), damage/2, knockback/2f, player.whoAmI, 1+player.meleeCrit);
			}
            if ((proj.minion || ProjectileID.Sets.MinionShot[proj.type]) && target.whoAmI == player.MinionAttackTargetNPC)
            {
                damage += summonTagDamage;
                if (summonTagCrit > 0)
                {
                    if (Main.rand.Next(1, 101) < summonTagCrit)
                    {
                        crit = true;
                    }
                }
            }
        }
		
		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
			ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
			if(monsterPower || nimbusPower || florianPower)playSound = false;
			
			if(damage > player.statLife && lifeTotem && !player.HasBuff(mod.BuffType("TotemCD"))) {
				for(int i = 0; i < 10; i++) {
				int dust = Dust.NewDust(player.position, player.width, player.height, 66, player.velocity.X*0.5f, player.velocity.Y*0.5f, 75, Color.Fuchsia, 0.95f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].scale = 1.5f;
				}
				Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 24, 7f);
				player.AddBuff(mod.BuffType("TotemCD"),3600);
				player.statLife += player.statManaMax;
				CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), new Color(225, 175, 200, 50),"Revived");
				return false;
			}
			return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
		}

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
			if(monsterPower)Main.PlaySound(4, (int)player.position.X, (int)player.position.Y, 30, 1f);
			if(nimbusPower)Main.PlaySound(4, (int)player.position.X, (int)player.position.Y, 33, 1f);
			if(nimbusPower)Main.PlaySound(6, (int)player.position.X, (int)player.position.Y, 1, 1.5f,-0.2f);
			
			if(!Main.expertMode && damage > (player.statLife/5) && Main.rand.Next(4)==0 || Main.expertMode && damage > (player.statLife/5) && Main.rand.Next(3)==0)
			{
				player.AddBuff(mod.BuffType("Fracture"), (int)(3600*2.5f));
			}
			for (int i = 0; i < 200; i++)
            {
                NPC npc = Main.npc[i];
			if(player.statLife < (int)(player.statLifeMax/4) && npc.boss == true)
			{
				player.AddBuff(mod.BuffType("LastBreath"), 3600);
			}
			
			}
			
			if(mahoganyScroll && Main.rand.Next(4)==0) {
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Bamboo"), (int)(5*player.allDamage), 2f, player.whoAmI, 4);
			}
			
			if(spirit1Bonus) {
				player.AddBuff(mod.BuffType("SpiritBonus"), 420);
			}
			
            if (crystalShardsBonus == true) {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(hitDirection + Main.rand.NextFloat(-6f, 6f)), (int)(hitDirection + Main.rand.NextFloat(-6f, 6f)), mod.ProjectileType("CrystalArmorShard"), (int)((1+damage/4)*player.thrownDamage), 5f, player.whoAmI, 1+player.thrownCrit);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(-hitDirection + Main.rand.NextFloat(-4f, 4f)), (int)(-hitDirection + Main.rand.NextFloat(-4f, 4f)), mod.ProjectileType("CrystalArmorShard"), (int)((1+damage/4)*player.thrownDamage), 5f, player.whoAmI, 1+player.thrownCrit);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(-hitDirection + Main.rand.NextFloat(-6f, 6f)), (int)(-hitDirection + Main.rand.NextFloat(-6f, 6f)), mod.ProjectileType("CrystalArmorShard"), (int)((1+damage/4)*player.thrownDamage), 5f, player.whoAmI, 1+player.thrownCrit);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(-hitDirection + Main.rand.NextFloat(-4f, 4f)), (int)(-hitDirection + Main.rand.NextFloat(-4f, 4f)), mod.ProjectileType("CrystalArmorShard"), (int)((1+damage/4)*player.thrownDamage), 5f, player.whoAmI, 1+player.thrownCrit);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(hitDirection + Main.rand.NextFloat(-6f, 6f)), (int)(hitDirection + Main.rand.NextFloat(-6f, 6f)), mod.ProjectileType("CrystalArmorShard"), (int)((1+damage/4)*player.thrownDamage), 5f, player.whoAmI, 1+player.thrownCrit);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(hitDirection + Main.rand.NextFloat(-4f, 4f)), (int)(hitDirection + Main.rand.NextFloat(-4f, 4f)), mod.ProjectileType("CrystalArmorShard"), (int)((1+damage/4)*player.thrownDamage), 5f, player.whoAmI, 1+player.thrownCrit);
            }
			if(beeWasp) {
				Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(hitDirection + Main.rand.NextFloat(-6f, 6f)), (int)(hitDirection + Main.rand.NextFloat(-9f, 9f)), mod.ProjectileType("WWWasp"), (int)((1+damage/5)*player.meleeDamage), 5.2f, player.whoAmI, 2+player.meleeCrit);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(-hitDirection + Main.rand.NextFloat(-4f, 4f)), (int)(-hitDirection + Main.rand.NextFloat(-7f, 7f)), mod.ProjectileType("WWWasp"), (int)((1+damage/5)*player.meleeDamage), 5.2f, player.whoAmI, 2+player.meleeCrit);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(-hitDirection + Main.rand.NextFloat(-6f, 6f)), (int)(-hitDirection + Main.rand.NextFloat(-9f, 9f)), mod.ProjectileType("WWWasp"), (int)((1+damage/5)*player.meleeDamage), 5.2f, player.whoAmI, 2+player.meleeCrit);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(-hitDirection + Main.rand.NextFloat(-4f, 4f)), (int)(-hitDirection + Main.rand.NextFloat(-7f, 7f)), mod.ProjectileType("WWWasp"), (int)((1+damage/5)*player.meleeDamage), 5.2f, player.whoAmI, 2+player.meleeCrit);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(hitDirection + Main.rand.NextFloat(-6f, 6f)), (int)(hitDirection + Main.rand.NextFloat(-9f, 9f)), mod.ProjectileType("WWWasp"), (int)((1+damage/5)*player.meleeDamage), 5.2f, player.whoAmI, 2+player.meleeCrit);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(hitDirection + Main.rand.NextFloat(-4f, 4f)), (int)(hitDirection + Main.rand.NextFloat(-7f, 7f)), mod.ProjectileType("WWWasp"), (int)((1+damage/5)*player.meleeDamage), 5.2f, player.whoAmI, 2+player.meleeCrit);
			}
			
			for (int m = 0; m < 200; m++)
            {
				NPC source1 = Main.npc[m];
				Projectile source2 = Main.projectile[m];
			if (tundraRose && (source1.coldDamage == true || source2.coldDamage == true))
			{
				damage *= 0.01f;
			}
			}
        }
		
		public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) {
			// Make sure this condition is the same as the condition in the Buff to remove itself. We do this here instead of in ModItem.UpdateAccessory in case we want future upgraded items to set blockyAccessory
			if (player.statLife < (player.statLifeMax/4) && monsterAcc) {
				player.AddBuff(mod.BuffType("Monster"), 60, true);
			}
			if (player.ZoneRain && nimbusAcc) {
				player.AddBuff(mod.BuffType("Nimbus"), 60, true);
			}
			if (Main.dayTime && florianAcc) {
				player.AddBuff(mod.BuffType("Florian"), 60, true);
			}
		}
		public override void UpdateVanityAccessories() {
			for (int n = 13; n < 18 + player.extraAccessorySlots; n++) {
				Item item = player.armor[n];
				if (item.type == mod.ItemType("EnragedBlood")) {
					monsterHideVanity = false;
					monsterForceVanity = true;
				}
				if (item.type == mod.ItemType("NimbusMedal")) {
					nimbusHideVanity = false;
					nimbusForceVanity = true;
				}
				if (item.type == mod.ItemType("FlowerCrystal")) {
					florianHideVanity = false;
					florianForceVanity = true;
				}
				
			}
		}

        public override void UpdateBadLifeRegen()
        {
            if (garnetCurse)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
                if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
                //player.lifeRegen -= 16;
            }
			if (spiritFlame)
			{
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 5;
			}
			
			if(lessManaSick) {
				Player.manaSickTimeMax = 510;
			}
			else{Player.manaSickTimeMax = 600;}
			
			if(blackHole) {
				Player.defaultItemGrabRange = 3038;
			}
			else {
				Player.defaultItemGrabRange = 38;
			}

			if(player.statMana < 0) {
				manaCD++;
				if(manaCD >= 5) {
					player.statMana += 1;
					manaCD = 0;
				}
			}
			if(fireflySpirit) {
				fireflySpiritCD++;
				if(fireflySpiritCD >= 15) {
					player.statMana += 1;
					player.ManaEffect(1);
					fireflySpiritCD = 0;
				}
			}
			if(livingSkull) {
				livingSkullCD++;
				if(livingSkullCD >= 16) {
					player.statLife += 1;
					player.HealEffect(1);
					livingSkullCD = 0;
				}
			}
			for (int i = 0; i < 200; i++) {
				Player help = Main.player[i];
				float offsetX = help.Center.X - player.Center.X;
				float offsetY = help.Center.Y - player.Center.Y;
				float distance = (float)Math.Sqrt(offsetX * offsetX + offsetY * offsetY);
				if(manaTank && help != Main.player[player.whoAmI] && help.active && !help.dead) {
					if(manaTankCD < 60)manaTankCD++;
					if(help.team == player.team && help.statMana < help.statManaMax && help.statMana < player.statMana - 25 && player.statMana > 25 && manaTankCD >= 15 && distance < 350f) {
						help.statMana += 1;
						help.ManaEffect(1);
						player.statMana -= 1;
						CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), new Color(30, 30, 75, 100),"-1");
						manaTankCD -= 15;
					}
				}
				if(aloeCream && !help.dead && player.active && help.active && !player.dead) {
					help.lifeRegen += 1;
				}
				if(nacionalDefense && !help.dead && player.active && help.active && !player.dead) {
					help.statDefense += 3;
					help.endurance += 0.03f;
				}
			}
			if(dankScroll && player.inventory[player.selectedItem].consumable == true && player.inventory[player.selectedItem].thrown == true) {
				player.thrownCrit += 5;
			}
			if(sanguineScroll) {
				if(throwerRushOn)player.thrownDamage += 0.25f;
				if(!throwerRushOn)player.thrownDamage -= 0.17f;
			}
			if(throwerRushOn && fractalShardsBonus && Main.rand.Next(3)==0)Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), mod.ProjectileType("Fragtal3"), (int)(30*player.thrownDamage), 8f, player.whoAmI, 4+player.thrownCrit);
			if(throwerRushOn && spirit2Bonus && Main.rand.Next(10)==0)Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("SpiritAura"), (int)(20*player.thrownDamage), 4f, player.whoAmI, 1+player.thrownCrit);
			if(throwerRushOn && dustTyphoon == 1 && Main.rand.Next(7)==0)Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.NextFloat(-7f, 7f), Main.rand.NextFloat(-7f, 7f), mod.ProjectileType("Dust1"), (int)(20*player.thrownDamage), 4f, player.whoAmI, 1+player.thrownCrit);
			if(throwerRushOn && dustTyphoon == 2 && Main.rand.Next(7)==0)Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.NextFloat(-7.2f, 7.2f), Main.rand.NextFloat(-7.2f, 7.2f), mod.ProjectileType("Dust2"), (int)(20*player.thrownDamage), 4f, player.whoAmI, 2+player.thrownCrit);
			
			/*if(monsterAcc && player.ownedProjectileCounts[mod.ProjectileType("MonsterHead")] < 1)
			{
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("MonsterHead"), 0, 0f, player.whoAmI);
			}*/
			if(nimbusPower && Main.rand.Next(22)==0)
			{
				Projectile.NewProjectile(player.Center.X + Main.rand.Next(-15,16), player.Center.Y, 0f, 3f, 239, (int)(25*player.magicDamage), 1.5f, player.whoAmI, 2+player.magicCrit);
			}
        }

        public override void UpdateDead()
        {
            garnetCurse = false;
			spiritFlame = false;
        }

        public virtual void PostUpdate()
        {

        }
		
		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk) {
			if (junk) {
				return;
			}
			/*if (player.FindBuffIndex(BuffID.TwinEyesMinion) > -1 && liquidType == 0 && Main.rand.NextBool(3)) {
				caughtType = ModContent.ItemType<SparklingSphere>();
			}
			if (player.gravDir == -1f && questFish == ModContent.ItemType<ExampleQuestFish>() && Main.rand.NextBool()) {
				caughtType = ModContent.ItemType<ExampleQuestFish>();
			}*/
			if(ZoneWoods && MartainWorld.forestSpirits && Main.rand.Next(5)==0) {
				caughtType = mod.ItemType("FishOfSpirit");
			}
			if(ZoneWoods && MartainWorld.forestSpirits && Main.hardMode && Main.rand.Next(5)==0) {
				caughtType = mod.ItemType("FishOfWrath");
			}
			if(ZoneWoods && MartainWorld.forestSpirits && NPC.downedMoonlord && Main.rand.Next(5)==0) {
				caughtType = mod.ItemType("FishOfPurity");
			}
			if(ZoneVoid && Main.rand.Next(3)==0) {
				caughtType = mod.ItemType("VoidGill");
			}
			if(player.ZoneDungeon && Main.rand.Next(3)==0) {
				caughtType = mod.ItemType("TrapFish");
			}
		}

		public override void GetFishingLevel(Item fishingRod, Item bait, ref int fishingLevel) {
			/*if (player.FindBuffIndex(ModContent.BuffType<CarMount>()) > -1) {
				fishingLevel = (int)(fishingLevel * 1.1f);
			}*/
		}

		public override void GetDyeTraderReward(List<int> dyeItemIDsPool) {
			/*if (player.FindBuffIndex(BuffID.UFOMount) > -1) {
				dyeItemIDsPool.Clear();
				dyeItemIDsPool.Add(ItemID.MartianArmorDye);
			}*/
		}

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (garnetCurse)
            {
                if (Main.rand.NextBool(5))//&& drawInfo.shadow == 0f
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 60, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.dust[dust].scale = 1.75f;
                    Main.playerDrawDust.Add(dust);
                    dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 109, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, Color.Black, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.dust[dust].scale = 1.7f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.2f;
                g *= 0.5f;
                b *= 0.5f;
                fullBright = true;
            }
			if (spiritFlame)
			{
				if (Main.rand.NextBool(5))
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 59, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.9f;
                    Main.dust[dust].velocity.Y -= 0.4f;
                    Main.dust[dust].scale = 1.8f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.3f;
                g *= 0.3f;
                b *= 0.6f;
                fullBright = true;
			}
			
			/*if(throwerRushValue >= 1200 && throwerRushOn == false) {
				int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 66, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 100, Color.Gray, 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0.65f;
                    Main.dust[dust].scale = 0.45f;
                    Main.playerDrawDust.Add(dust);
			}*/
			if(throwerRushOn == true) {
				if(!sanguineScroll) {
					int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 66, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 100, new Color(200,200,200,200), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.75f;
                    Main.dust[dust].scale = 0.85f;
                    Main.playerDrawDust.Add(dust);
				}
				if(sanguineScroll) {
					int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 66, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 100, new Color(200,5,5,200), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.75f;
                    Main.dust[dust].scale = 0.85f;
                    Main.playerDrawDust.Add(dust);
				}
			}
			
			if(MartainWorld.forestSpirits) {
				if(Main.rand.Next(25)==0) {
					Gore.NewGore(new Vector2(player.position.X + Main.rand.Next(-800,801), player.position.Y - 700), new Vector2(Main.rand.NextFloat(-3f,3f),8f), mod.GetGoreSlot("Gores/SpiritDroplet"), 0.8f);
				}
			}

        }
		
		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
			if (player.HasBuff(mod.BuffType("Fracture")) && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) {
				switch (Main.rand.Next(2)) {
					case 0:
						damageSource = PlayerDeathReason.ByCustomReason(player.name + " bled out internally");
						break;
					default:
						damageSource = PlayerDeathReason.ByCustomReason(player.name + " couldn't handle the broken bones");
						break;
				}
			}
			return true;
		}
		
		public override void FrameEffects() {
			if ((florianPower || florianForceVanity) && !florianHideVanity) {
				player.legs = mod.GetEquipSlot("FlorianLegs", EquipType.Legs);
				player.body = mod.GetEquipSlot("FlorianBody", EquipType.Body);
				player.head = mod.GetEquipSlot("FlorianHead", EquipType.Head);
			}
			if ((nimbusPower || nimbusForceVanity) && !nimbusHideVanity) {
				player.legs = mod.GetEquipSlot("NimbusLegs", EquipType.Legs);
				player.body = mod.GetEquipSlot("NimbusBody", EquipType.Body);
				player.head = mod.GetEquipSlot("NimbusHead", EquipType.Head);
			}
			if ((monsterPower || monsterForceVanity) && !monsterHideVanity) {
				player.legs = mod.GetEquipSlot("MonsterLegs", EquipType.Legs);
				player.body = mod.GetEquipSlot("MonsterBody", EquipType.Body);
				player.head = mod.GetEquipSlot("MonsterHead", EquipType.Head);
			}
			/*if (nullified) {
				Nullify();
			}*/
		}
		
		public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo) {
			if ((monsterPower || monsterForceVanity) && !monsterHideVanity) {
				player.headRotation = player.velocity.Y * (float)player.direction * 0.1f;
				player.headRotation = Utils.Clamp(player.headRotation, -0.3f, 0.3f);
				player.headRotation +=Main.rand.NextFloat(-0.35f,0.35f);
			}
		}
		
    }
}