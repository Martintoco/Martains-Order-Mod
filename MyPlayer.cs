using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder
{
    public class MyPlayer : ModPlayer
    {
        private const int saveVersion = 0;

        public bool MElemental = false;
        public bool ZincSummon = false;

        public bool minionName = false;

        //public bool accWhipRange;
        //public bool garnetWhipRange;
		public float whipExtraRange = 1.0f;
		public bool whipGlove = false;
        public bool crystalShardsBonus;

        //public bool e = false;
        //public bool o = false;
        //public static bool hasProjectile;
        //public bool examplePet = false;
        //public bool exampleLightPet = false;
        //public bool OFF;

        //public bool ZoneAstral;
        public bool ZoneVoid;

        public int summonTagDamage;
        public int summonTagCrit;

        public bool garnetCurse;

        //-------RESEARCH-------//

        public float researchVelocityAcc = 1f;
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

        //----------------------//

        public override void ResetEffects()
        {
            MElemental = false;
            ZincSummon = false;
            //accWhipRange = false;
            //garnetWhipRange = false;
			whipExtraRange = 1.0f;
            crystalShardsBonus = false;
            //e = false;
            //o = false;
            //examplePet = false;
            //exampleLightPet = false;
            //OFF = false;
            researchVelocityAcc = 1f;
            researchInMoveAcc = false;
            garnetCurse = false;
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("StartBag"));
            item.stack = 1;
            items.Add(item);
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

            if (researchBiomeForest >= (int)(3600 * researchVelocityAcc) && !researchBiomeForestRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeForestRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeDesert >= (int)(3600 * researchVelocityAcc) && !researchBiomeDesertRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeDesertRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeSnow >= (int)(3600 * researchVelocityAcc) && !researchBiomeSnowRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeSnowRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeCorrupt >= (int)(3600 * researchVelocityAcc) && !researchBiomeCorruptRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeCorruptRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeCrimson >= (int)(3600 * researchVelocityAcc) && !researchBiomeCrimsonRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeCrimsonRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeHallow >= (int)(3600 * researchVelocityAcc) && !researchBiomeHallowRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeHallowRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeJungle >= (int)(3600 * researchVelocityAcc) && !researchBiomeJungleRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeJungleRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeHell >= (int)(3600 * researchVelocityAcc) && !researchBiomeHellRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeHellRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeSky >= (int)(3600 * researchVelocityAcc) && !researchBiomeSkyRecipie)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Research"), 0, 0f, player.whoAmI);
                researchBiomeSkyRecipie = true;
                anyResearch = true;
                Main.PlaySound(SoundID.Item122, player.position);
            }
            if (researchBiomeBeach >= (int)(3600 * researchVelocityAcc) && !researchBiomeBeachRecipie)
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
        }

        public override void UpdateBiomes()
        {
            //ZoneAstral = MartainWorld.astralTiles > 50;
            ZoneVoid = MartainWorld.voidTiles > 100;
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneVoid)
            {
                return mod.GetTexture("VoidBiomeMapBackground");
            }
            return null;
        }

        /*public override void UpdateBiomeVisuals() {
			bool useVoidMonolith = voidMonolith && !NPC.AnyNPCs(NPCID.MoonLordCore);
			player.ManageSpecialBiomeVisuals("MartainsOrder:MonolithVoid", useVoidMonolith, player.Center);
		}*/

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
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

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
			if(!Main.expertMode && damage > (player.statLife/5) && Main.rand.Next(5)==0 || Main.expertMode && damage > (player.statLife/5) && Main.rand.Next(2)==0)
			{
				player.AddBuff(mod.BuffType("Fracture"), 3600*3);
			}
			
            if (crystalShardsBonus == true)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(hitDirection + Main.rand.NextFloat(-6f, 6f)), (int)(hitDirection + Main.rand.NextFloat(-6f, 6f)), mod.ProjectileType("CrystalArmorShard"), (int)(player.thrownDamage / 2), 5f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(-hitDirection + Main.rand.NextFloat(-4f, 4f)), (int)(-hitDirection + Main.rand.NextFloat(-4f, 4f)), mod.ProjectileType("CrystalArmorShard"), (int)(player.thrownDamage / 2), 5f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(-hitDirection + Main.rand.NextFloat(-6f, 6f)), (int)(-hitDirection + Main.rand.NextFloat(-6f, 6f)), mod.ProjectileType("CrystalArmorShard"), (int)(player.thrownDamage / 2), 5f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(-hitDirection + Main.rand.NextFloat(-4f, 4f)), (int)(-hitDirection + Main.rand.NextFloat(-4f, 4f)), mod.ProjectileType("CrystalArmorShard"), (int)(player.thrownDamage / 2), 5f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(hitDirection + Main.rand.NextFloat(-6f, 6f)), (int)(hitDirection + Main.rand.NextFloat(-6f, 6f)), mod.ProjectileType("CrystalArmorShard"), (int)(player.thrownDamage / 2), 5f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(hitDirection + Main.rand.NextFloat(-4f, 4f)), (int)(hitDirection + Main.rand.NextFloat(-4f, 4f)), mod.ProjectileType("CrystalArmorShard"), (int)(player.thrownDamage / 2), 5f, player.whoAmI);
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (garnetCurse)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
                //player.lifeRegen -= 16;
            }
        }

        public override void UpdateDead()
        {
            garnetCurse = false;
        }

        public virtual void PostUpdate()
        {

        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (garnetCurse)
            {
                if (Main.rand.NextBool(5) && drawInfo.shadow == 0f)
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

        }

    }
}