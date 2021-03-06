using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Whips
{

    public abstract class ModWhip : ModProjectile
    {
        private List<Vector2> _whipPointsForCollision = new List<Vector2>();
        private Player player;
        public float rangeMult = 1f;
        public int summonTagDamage;
        public int summonTagCrit;
        public int buffGivenToPlayer;
        public int buffTime;
		private float IncrementationBonus = 0f;
		//private int pinnacleCount = 0;

        private Rectangle handPos = new Rectangle(0, 0, 0, 0);

        private float rangeMultiplier;
        private float timeToFlyOut;
        private int segments;

        public override bool CloneNewInstances => true;

        public virtual void SafeSetDefaults()
        { }
        public override void SetDefaults()
        {

            projectile.width = 26;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.scale = 1f;
            projectile.ownerHitCheck = true;
            projectile.extraUpdates = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            summonTagDamage = 0;
            summonTagCrit = 0;
            buffGivenToPlayer = -1;
            buffTime = 120;


            SafeSetDefaults();

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //NPC nPC = Main.npc[i];
            if (Main.player[projectile.owner].meleeEnchant > 0)
            {
                byte meleeEnchant = Main.player[projectile.owner].meleeEnchant;
                if (meleeEnchant == 1)
                {
                    target.AddBuff(70, 60 * Main.rand.Next(5, 10));
                }
                if (meleeEnchant == 2)
                {
                    target.AddBuff(39, 60 * Main.rand.Next(3, 7));
                }
                if (meleeEnchant == 3)
                {
                    target.AddBuff(24, 60 * Main.rand.Next(3, 7));
                }
                if (meleeEnchant == 5)
                {
                    target.AddBuff(69, 60 * Main.rand.Next(10, 20));
                }
                if (meleeEnchant == 6)
                {
                    target.AddBuff(31, 60 * Main.rand.Next(1, 4));
                }
                if (meleeEnchant == 8)
                {
                    target.AddBuff(20, 60 * Main.rand.Next(5, 10));
                }
                if (meleeEnchant == 4)
                {
                    target.AddBuff(72, 120);
                }
            }
			if(Main.player[projectile.owner].magmaStone)target.AddBuff(24, Main.rand.Next(60, 361));
			if(Main.player[projectile.owner].GetModPlayer<MyPlayer>().everfrostStone)target.AddBuff(44, Main.rand.Next(55, 351));
			
			if (projectile.type == mod.ProjectileType("FlowerWhipWhip") && Main.rand.Next(2) == 0)
            {
				projectile.damage = (int)((float)projectile.damage * 0.45);
			}
			if (projectile.type == mod.ProjectileType("YellowPhaseWhip") || projectile.type == mod.ProjectileType("PurplePhaseWhip") ||
			projectile.type == mod.ProjectileType("BluePhaseWhip") || projectile.type == mod.ProjectileType("GreenPhaseWhip") ||
			projectile.type == mod.ProjectileType("RedPhaseWhip") || projectile.type == mod.ProjectileType("WhitePhaseWhip") ||
			projectile.type == mod.ProjectileType("OrangePhaseWhip") || projectile.type == mod.ProjectileType("BlackPhaseWhip") ||
			projectile.type == mod.ProjectileType("LimePhaseWhip") || projectile.type == mod.ProjectileType("BrownPhaseWhip") ||
			projectile.type == mod.ProjectileType("GrayPhaseWhip") || projectile.type == mod.ProjectileType("TealPhaseWhip") )
            {
				target.AddBuff(mod.BuffType("PhaseGlow"), 600);
				projectile.damage = (int)((float)projectile.damage * 0.62);
			}
			if (projectile.type == mod.ProjectileType("StarFlailWhip") && Main.rand.Next(2) == 0)
            {
				projectile.damage = (int)((float)projectile.damage * 0.53);
			}
			if (projectile.type == mod.ProjectileType("MWhipWhip"))
            {
				if(player.ownedProjectileCounts[mod.ProjectileType("MWSummon")] == 0)
				{
					Projectile.NewProjectile(target.Center.X, target.Center.Y, projectile.velocity.X/2, projectile.velocity.Y/2, mod.ProjectileType("MWSummon"), projectile.damage/2, projectile.knockBack/2, projectile.owner, 0f, 0f);
				}
				
				projectile.damage = (int)((float)projectile.damage * 0.63);
			}
			if (projectile.type == mod.ProjectileType("TulipWhipWhip"))
            {
				Projectile.NewProjectile(target.Center.X, target.Center.Y, projectile.velocity.X+Main.rand.NextFloat(-1f,1f), projectile.velocity.Y+Main.rand.NextFloat(-1f,1f), mod.ProjectileType("Pix"), projectile.damage/2, projectile.knockBack/2, projectile.owner, 0f, 0f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, -projectile.velocity.X+Main.rand.NextFloat(-1f,1f), -projectile.velocity.Y+Main.rand.NextFloat(-1f,1f), mod.ProjectileType("Pix"), projectile.damage/2, projectile.knockBack/2, projectile.owner, 0f, 0f);
				if(Main.rand.Next(3)==0)Projectile.NewProjectile(target.Center.X, target.Center.Y, projectile.velocity.X/2+Main.rand.NextFloat(-1f,1f), projectile.velocity.Y/2+Main.rand.NextFloat(-1f,1f), mod.ProjectileType("Pix"), projectile.damage/2, projectile.knockBack/2, projectile.owner, 0f, 0f);
				
				projectile.damage = (int)((float)projectile.damage * 0.68);
			}
			if (projectile.type == mod.ProjectileType("GarnetWhipWhip"))
            {
				target.AddBuff(mod.BuffType("GarnetCurse"), 180);
				projectile.damage = (int)((float)projectile.damage * 0.75);
			}
			if (projectile.type == mod.ProjectileType("StardustWhip"))
            {
				target.AddBuff(mod.BuffType("StarConstelation"), 240);
				projectile.damage = (int)((float)projectile.damage * 0.89);
			}
			if (projectile.type == mod.ProjectileType("ShadeToungeWhip"))
            {
				target.AddBuff(mod.BuffType("Empty"), 240);
				Main.player[projectile.owner].statLife += (int)(projectile.damage*0.05f);
				Main.player[projectile.owner].HealEffect((int)(projectile.damage*0.05f));
				projectile.damage = (int)((float)projectile.damage * 0.86);
			}
			if (projectile.type == mod.ProjectileType("EoWWhipWhip"))
            {
				Projectile.NewProjectile(target.Center.X, target.Center.Y, (-3 + Main.rand.Next(-2, 2)), (-3 + Main.rand.Next(-2, 2)), mod.ProjectileType("EoWW"), projectile.damage, 0f, projectile.owner, 0f, 0f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, (3 + Main.rand.Next(-2, 2)), (3 + Main.rand.Next(-2, 2)), mod.ProjectileType("EoWW"), projectile.damage, 0f, projectile.owner, 0f, 0f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, (3 + Main.rand.Next(-2, 2)), (-3 + Main.rand.Next(-2, 2)), mod.ProjectileType("EoWW"), projectile.damage, 0f, projectile.owner, 0f, 0f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, (-3 + Main.rand.Next(-2, 2)), (3 + Main.rand.Next(-2, 2)), mod.ProjectileType("EoWW"), projectile.damage, 0f, projectile.owner, 0f, 0f);
				projectile.damage = (int)((float)projectile.damage * 0.93);
            /*if (meleeEnchant == 1) target.AddBuff( 70, 60 * Main.rand.Next(5, 10) );
            if (meleeEnchant == 2) target.AddBuff( 39, 60 * Main.rand.Next(3, 7) );
            if (meleeEnchant == 3) target.AddBuff( 24, 60 * Main.rand.Next(3, 7) );
            if (meleeEnchant == 4) target.AddBuff(72, 120);
            if (meleeEnchant == 5) target.AddBuff( 69, 60 * Main.rand.Next( 10, 20));
            if (meleeEnchant == 6) target.AddBuff(31, 60 * Main.rand.Next(1, 4));
            if (meleeEnchant == 8) target.AddBuff(20, 60 * Main.rand.Next(5, 10));*/
            }
            if (projectile.type == mod.ProjectileType("SalvageHoneyWhipWhip"))
            {
				projectile.damage = (int)((float)projectile.damage * 0.94);
				Main.player[projectile.owner].AddBuff(mod.BuffType("SalvageSweetness"), 180);
            }
			if (projectile.type == mod.ProjectileType("ZenithWhip"))
            {
				projectile.damage = (int)((float)projectile.damage * 0.94);
				Main.player[projectile.owner].AddBuff(mod.BuffType("Pinnacle"), 300);
				target.AddBuff(mod.BuffType("GarnetCurse"), 180);
				target.AddBuff(BuffID.ShadowFlame, 180);
				target.AddBuff(mod.BuffType("PhaseGlow"), 600);
            }

            player.MinionAttackTargetNPC = target.whoAmI;
            player.GetModPlayer<MyPlayer>().summonTagDamage = summonTagDamage;
            player.GetModPlayer<MyPlayer>().summonTagCrit = summonTagCrit;
            if (buffGivenToPlayer != -1) { player.AddBuff(buffGivenToPlayer, buffTime); }
            NpcEffects(target, damage, knockback, crit);
        }
        public virtual void NpcEffects(NPC target, int damage, float knockback, bool crit)
        { }

        public virtual void StatusNPC(int i)
        {

        }

        public override void AI()
        {
			/*if(projectile.type == mod.ProjectileType("PinnacleExtraWhip")) {Main.projFrames[projectile.type] = 12;
			if (++projectile.frameCounter >= 0 && projectile.frameCounter <= 1)
            {
                projectile.frame = Main.rand.Next(0, 12);
            }
			}*/
            //if (Main.player[projectile.owner].GetModPlayer<MyPlayer>().garnetWhipRange == true) rangeMult = (rangeMult * 1.10f);
            //if (Main.player[projectile.owner].GetModPlayer<MyPlayer>().accWhipRange == true) rangeMult = (rangeMult * 1.10f);
			rangeMult=((rangeMult*Main.player[projectile.owner].GetModPlayer<MyPlayer>().whipExtraRange));

            if (projectile.ai[0] == 0) { projectile.velocity *= rangeMult; projectile.ai[0] = 1; }
            player = Main.player[projectile.owner];
            projectile.rotation = projectile.velocity.ToRotation() + (float)Math.PI / 2f;
            projectile.ai[0] += 1f / player.meleeSpeed;
            GetWhipSettings(projectile);
            projectile.Center = GetPlayerArmPosition(projectile) + projectile.velocity * (projectile.ai[0] - 1f);
            projectile.spriteDirection = ((!(Vector2.Dot(projectile.velocity, Vector2.UnitX) < 0f)) ? 1 : (-1));
            if (projectile.ai[0] >= timeToFlyOut || player.itemAnimation == 0)
            {
                projectile.Kill();
                return;
            }
            player.heldProj = projectile.whoAmI;
            player.itemAnimation = player.itemAnimationMax - (int)(projectile.ai[0] / (float)projectile.MaxUpdates);
            player.itemTime = player.itemAnimation;
            if (projectile.ai[0] == (float)(int)(timeToFlyOut / 2f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Vector2 position = _whipPointsForCollision[_whipPointsForCollision.Count - 1];
                Main.PlaySound(SoundID.Item39, position);
            }


            float t2 = projectile.ai[0] / timeToFlyOut;
            float num2 = GetLerpValue(0.1f, 0.7f, t2, clamped: true) * GetLerpValue(0.9f, 0.7f, t2, clamped: true);
            if (num2 > 0.1f && Main.rand.NextFloat() < num2 / 2f)
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));

            }
			float dustVelX = (projectile.velocity.X * 1.1f)+Main.rand.NextFloat(0.5f,1.5f);
			float dustVelY = (projectile.velocity.Y * 1.1f)+Main.rand.NextFloat(0.5f,1.5f);
			
			//if(player.ownedProjectileCounts[mod.ProjectileType("ZenithWhip")] >= 1 && projectile.type == mod.ProjectileType("ZenithWhip")) {
            if (projectile.type == mod.ProjectileType("FlowerWhipWhip") && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 2, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 0.5f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = Main.rand.NextFloat(1.15f,1.35f);
            }
			if (projectile.type == mod.ProjectileType("StarFlailWhip") && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 66, dustVelX * 1f, dustVelY * 1f, 100, Color.Teal, 0.5f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = Main.rand.NextFloat(0.9f,1.1f);
            }
            if (projectile.type == mod.ProjectileType("MWhipWhip") && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 57, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 1f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = Main.rand.NextFloat(1.4f,1.6f);
            }
			if (projectile.type == mod.ProjectileType("TulipWhipWhip") && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 57, Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, default(Color), 0.8f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = Main.rand.NextFloat(1.0f,1.2f);
                if (Main.rand.Next(3) == 0)
                {
                    num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 47, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 0.75f);
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].scale = Main.rand.NextFloat(1.1f,1.3f);
                }

            }
            if (projectile.type == mod.ProjectileType("GarnetWhipWhip") && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 60, dustVelX * 1.1f, dustVelY * 1.1f, 50, default(Color), 1.15f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = Main.rand.NextFloat(1.4f,1.6f);
            }
			if (projectile.type == mod.ProjectileType("StardustWhip") && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 135, dustVelX * 1.2f, dustVelY * 1.2f, 100, default(Color), 1.15f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = Main.rand.NextFloat(1.9f,2.1f);
            }
			if (projectile.type == mod.ProjectileType("ShadeToungeWhip") && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 109, dustVelX * 1.1f, dustVelY * 1.1f, 100, default(Color), 1.15f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = Main.rand.NextFloat(1.8f,2.2f);
            }
            if (projectile.type == mod.ProjectileType("EoWWhipWhip") && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 75, dustVelX * 1.1f, dustVelY * 1.1f, 75, default(Color), 1.35f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = Main.rand.NextFloat(1.4f,1.6f);
            }
            if (projectile.type == mod.ProjectileType("SalvageHoneyWhipWhip") && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 153, dustVelX * 1f, dustVelY * 1f, 75, default(Color), 1.05f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = Main.rand.NextFloat(1.4f,1.6f);
            }
			if (projectile.type == mod.ProjectileType("ZenithWhip") && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
				/*pinnacleCount++;
				if(pinnacleCount >= 10 && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f)) {
					_whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
				Projectile.NewProjectile(r2.TopLeft().X, r2.TopLeft().Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("PinnacleExtra"), projectile.damage/2, projectile.knockBack, projectile.owner, 0f, 0f);
				}*/
				_whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r3 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num3 = Dust.NewDust(r3.TopLeft(), r3.Width, r3.Height, 66, dustVelX * 1f, dustVelY * 1f, 75, Main.DiscoColor, 1.05f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = Main.rand.NextFloat(0.8f,0.9f);
			}

            if (Main.player[projectile.owner].meleeEnchant > 0 && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                byte meleeEnchant = Main.player[projectile.owner].meleeEnchant;
                if (meleeEnchant == 1)
                {
                    _whipPointsForCollision.Clear();
                    FillWhipControlPoints(projectile, _whipPointsForCollision);
                    Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                    int num3 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 171, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 1.05f);
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].fadeIn = 1.5f;
                    Main.dust[num3].velocity *= 0.25f;
                }
                if (meleeEnchant == 2)
                {
                    _whipPointsForCollision.Clear();
                    FillWhipControlPoints(projectile, _whipPointsForCollision);
                    Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                    int num291 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 75, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 1.05f);
                    Main.dust[num291].noGravity = true;
                    Main.dust[num291].velocity *= 0.7f;
                    Main.dust[num291].velocity.Y -= 0.5f;
                }
                if (meleeEnchant == 3)
                {
                    _whipPointsForCollision.Clear();
                    FillWhipControlPoints(projectile, _whipPointsForCollision);
                    Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                    int num292 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 6, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 1.05f);
                    Main.dust[num292].noGravity = true;
                    Main.dust[num292].velocity *= 0.7f;
                    Main.dust[num292].velocity.Y -= 0.5f;
                }
                if (meleeEnchant == 4)
                {
                    _whipPointsForCollision.Clear();
                    FillWhipControlPoints(projectile, _whipPointsForCollision);
                    Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                    int num293 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 57, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 1.05f);
                    Main.dust[num293].noGravity = true;
                    Main.dust[num293].velocity.X /= 2f;
                    Main.dust[num293].velocity.Y /= 2f;
                }
                if (meleeEnchant == 5)
                {
                    _whipPointsForCollision.Clear();
                    FillWhipControlPoints(projectile, _whipPointsForCollision);
                    Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                    int num294 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 169, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 1.05f);
                    Main.dust[num294].velocity.X += projectile.spriteDirection;
                    Main.dust[num294].velocity.Y += 0.2f;
                    Main.dust[num294].noGravity = true;
                }
                if (meleeEnchant == 6)
                {
                    _whipPointsForCollision.Clear();
                    FillWhipControlPoints(projectile, _whipPointsForCollision);
                    Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                    int num295 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 135, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 1.05f);
                    Main.dust[num295].velocity.X += projectile.spriteDirection;
                    Main.dust[num295].velocity.Y += 0.2f;
                    Main.dust[num295].noGravity = true;
                }
                if (meleeEnchant == 7)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        _whipPointsForCollision.Clear();
                        FillWhipControlPoints(projectile, _whipPointsForCollision);
                        Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                        int num296 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, Main.rand.Next(139, 143), dustVelX * 1f, dustVelY * 1f, 100, default(Color), 1.05f);
                        Main.dust[num296].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
                        Main.dust[num296].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
                        Main.dust[num296].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
                        Main.dust[num296].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
                        Main.dust[num296].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;

                        int type10 = Main.rand.Next(276, 283);
                        int num297 = Gore.NewGore(r2.TopLeft(), projectile.velocity, type10);
                        Main.gore[num297].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
                        Main.gore[num297].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
                        Main.gore[num297].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
                        Main.gore[num297].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
                        Main.gore[num297].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
                    }
                }
                if (meleeEnchant == 8)
                {
                    _whipPointsForCollision.Clear();
                    FillWhipControlPoints(projectile, _whipPointsForCollision);
                    Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                    int num298 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 46, 0f, 0f, 100, default(Color), 1.05f);
                    Main.dust[num298].noGravity = true;
                    Main.dust[num298].fadeIn = 1.5f;
                    Main.dust[num298].velocity *= 0.25f;
                }
            }
			if (Main.player[projectile.owner].magmaStone && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num291 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 6, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 1.05f);
                Main.dust[num291].noGravity = true;
				Main.dust[num291].scale = 1.5f;
                Main.dust[num291].velocity *= 1f;
                Main.dust[num291].velocity.Y -= 0.2f;
            }
			if (Main.player[projectile.owner].GetModPlayer<MyPlayer>().everfrostStone && projectile.ai[0] > (float)(int)(timeToFlyOut / 2.2f) && projectile.ai[0] < (float)(int)(timeToFlyOut / 1.25f))
            {
                _whipPointsForCollision.Clear();
                FillWhipControlPoints(projectile, _whipPointsForCollision);
                Rectangle r2 = Utils.CenteredRectangle(_whipPointsForCollision[_whipPointsForCollision.Count - 1], new Vector2(30f, 30f));
                int num291 = Dust.NewDust(r2.TopLeft(), r2.Width, r2.Height, 135, dustVelX * 1f, dustVelY * 1f, 100, default(Color), 1.05f);
                Main.dust[num291].noGravity = true;
				Main.dust[num291].scale = 1.5f;
                Main.dust[num291].velocity *= 1f;
                Main.dust[num291].velocity.Y -= 0.2f;
            }
			//}
        }
        public void FillWhipControlPoints(Projectile proj, List<Vector2> controlPoints)
        {
            GetWhipSettings(proj);
            float AnimationLevel = proj.ai[0] / timeToFlyOut;
            float Incrementation = 0.55f;
            float Step = 1f + Incrementation;
            float RotationMult = (float)Math.PI * 10f * (1f - AnimationLevel * Step) * (float)(-proj.spriteDirection) / (float)segments;
            float AnimPos = AnimationLevel * Step;
            float level = 0f;
            if (AnimPos > 1f)
            {
                level = (AnimPos - 1f) / Incrementation;
                AnimPos = MathHelper.Lerp(1f, 0f, level);
            }
            float useTimeDiff = proj.ai[0] - 1f;
            useTimeDiff = (float)(Main.player[proj.owner].HeldItem.useAnimation * 2) * AnimationLevel;
            float SegmentDistMult = proj.velocity.Length() * useTimeDiff * AnimPos * rangeMultiplier / (float)segments;
            float Scale = 1f;
            Vector2 playerArmPosition = GetPlayerArmPosition(proj);
            Vector2 ArmPos = playerArmPosition;
            float rotationDiff = 0f - (float)Math.PI / 2f;
            Vector2 value = ArmPos;
            float Rotation = 0f + (float)Math.PI / 2f + (float)Math.PI / 2f * (float)proj.spriteDirection;
            Vector2 value2 = ArmPos;
            float RoationPlusDiff = 0f + (float)Math.PI / 2f;
            controlPoints.Add(playerArmPosition);
            for (int i = 0; i < segments; i++)
            {
                float SegmentOffset = (float)i / (float)segments;
                float Inc = RotationMult * SegmentOffset * Scale;
                Vector2 startOff = ArmPos + rotationDiff.ToRotationVector2() * SegmentDistMult;
                Vector2 midOff = value2 + RoationPlusDiff.ToRotationVector2() * (SegmentDistMult * 2f);
                Vector2 endOff = value + Rotation.ToRotationVector2() * (SegmentDistMult * 2f);
                float AnimOffset = 1f - AnimPos;
                float EndVal = 1f - AnimOffset * AnimOffset;
                Vector2 value3 = Vector2.Lerp(midOff, startOff, EndVal * 0.9f + 0.1f);
                Vector2 value4 = Vector2.Lerp(endOff, value3, EndVal * 0.7f + 0.3f);
                Vector2 spinningpoint = playerArmPosition + (value4 - playerArmPosition) * new Vector2(1f, Step);
                float num17 = level;
                num17 *= num17;
                Vector2 item = spinningpoint.RotatedBy(proj.rotation + 4.712389f * num17 * (float)proj.spriteDirection, playerArmPosition);
                controlPoints.Add(item);
                rotationDiff += Inc;
                RoationPlusDiff += Inc;
                Rotation += Inc;
                ArmPos = startOff;
                value2 = midOff;
                value = endOff;
            }
        }

        public void GetWhipSettings(Projectile proj)
        {
            timeToFlyOut = Main.player[proj.owner].itemAnimationMax * proj.MaxUpdates;
            segments = 21;
            rangeMultiplier = 1;


        }
        public float GetLerpValue(float from, float to, float t, bool clamped = false)
        {
            if (clamped)
            {
                if (from < to)
                {
                    if (t < from)
                    {
                        return 0f;
                    }
                    if (t > to)
                    {
                        return 1f;
                    }
                }
                else
                {
                    if (t < to)
                    {
                        return 1f;
                    }
                    if (t > from)
                    {
                        return 0f;
                    }
                }
            }
            return (t - from) / (to - from);
        }



        public Vector2 GetPlayerArmPosition(Projectile proj)
        {
            Player targetSearchResults = Main.player[proj.owner];
            Vector2 value = Main.OffsetsPlayerOnhand[targetSearchResults.bodyFrame.Y / 56] * 2f;
            if (targetSearchResults.direction != 1)
            {
                value.X = (float)targetSearchResults.bodyFrame.Width - value.X;
            }
            if (targetSearchResults.gravDir != 1f)
            {
                value.Y = (float)targetSearchResults.bodyFrame.Height - value.Y;
            }
            value -= new Vector2(targetSearchResults.bodyFrame.Width - targetSearchResults.width, targetSearchResults.bodyFrame.Height - 42) / 2f;
            return targetSearchResults.RotatedRelativePoint(targetSearchResults.MountedCenter - new Vector2(20f, 42f) / 2f + value + Vector2.UnitY * targetSearchResults.gfxOffY);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {

            List<Vector2> list = new List<Vector2>();
            FillWhipControlPoints(projectile, list);
            Texture2D value = mod.GetTexture("Whips/WhipTexture");
            Microsoft.Xna.Framework.Rectangle value2 = value.Frame();
            Vector2 origin = new Vector2(value2.Width / 2, 2f);
            Microsoft.Xna.Framework.Color originalColor = Microsoft.Xna.Framework.Color.White;

            Vector2 value3 = list[0];
            for (int i = 0; i < list.Count - 1; i++)
            {
                Vector2 vector = list[i];
                Vector2 vector2 = list[i + 1] - vector;
                float rotation = vector2.ToRotation() - (float)Math.PI / 2f;
                Microsoft.Xna.Framework.Color color = GetColor(vector.ToTileCoordinates(), originalColor);
                Vector2 scale = new Vector2(1f, (vector2.Length() + 2f) / (float)value2.Height);
                spriteBatch.Draw(value, value3 - Main.screenPosition, value2, color, rotation, origin, scale, SpriteEffects.None, 0f);
                value3 += vector2;
            }

            DrawWhip(projectile, list, spriteBatch);

            return false;
        }
        private Vector2 DrawWhip(Projectile proj, List<Vector2> controlPoints, SpriteBatch spriteBatch)
        {
            Texture2D value = ModContent.GetTexture(Texture);
            Rectangle rectangle = value.Frame(1, 5);
            int height = rectangle.Height;
            rectangle.Height -= 2;
            Vector2 vector = rectangle.Size() / 2f;
            Vector2 vector2 = controlPoints[0];
            for (int i = 0; i < controlPoints.Count - 1; i++)
            {
                bool flag = true;
                Vector2 origin = vector;
                switch (i)
                {
                    case 0:
                        origin.Y -= 4f;
                        break;
                    case 3:
                        rectangle.Y = height;
                        break;
                    case 5:
                    case 7:

                    case 9:
                    case 11:
                    case 13:
                        rectangle.Y = height * 2;
                        break;
                    case 15:
                    case 17:
                        rectangle.Y = height * 3;
                        break;
                    case 19:
                        rectangle.Y = height * 4;
                        break;
                    default:
                        flag = false;
                        break;
                }
                Vector2 vector3 = controlPoints[i];
                Vector2 vector4 = controlPoints[i + 1] - vector3;
                if (flag)
                {
                    float rotation = vector4.ToRotation() - (float)Math.PI / 2f;
                    Color alpha = proj.GetAlpha(GetColor(vector3.ToTileCoordinates()));
                    spriteBatch.Draw(value, vector2 - Main.screenPosition, rectangle, alpha, rotation, origin, 1f, SpriteEffects.None, 0f);
                    handPos = new Rectangle((int)vector2.X, (int)vector2.Y, rectangle.Width, rectangle.Height);
                    ItemCheck_MeleeHitNPCs(player.HeldItem, handPos, (int)(player.HeldItem.damage * player.minionDamage), player.HeldItem.knockBack);

                }
                vector2 += vector4;
            }
            return vector2;


        }
        public Color GetColor(Point tileCoords, Color originalColor)
        {
            if (Main.gameMenu)
            {
                return originalColor;
            }
            return new Color(Lighting.GetColor(tileCoords.X, tileCoords.Y).ToVector3() * originalColor.ToVector3());
        }
        public Color GetColor(Point tileCoords)
        {
            if (Main.gameMenu)
            {
                return Color.White;
            }
            return new Color(Lighting.GetColor(tileCoords.X, tileCoords.Y).ToVector3() * 1.2f);
        }
        public void ApplyNPCOnHitEffects(Item sItem, Rectangle itemRectangle, int damage, float knockBack, int npcIndex, int dmgRandomized, int dmgDone)
        {
            bool fontDeathText = !Main.npc[npcIndex].immortal;

            if (player.beetleOffense && fontDeathText)
            {
                player.beetleCounter += dmgDone;
                player.beetleCountdown = 0;
            }

            if (player.meleeEnchant == 7)
            {
                Projectile.NewProjectile(Main.npc[npcIndex].Center.X, Main.npc[npcIndex].Center.Y, Main.npc[npcIndex].velocity.X, Main.npc[npcIndex].velocity.Y, ProjectileID.ConfettiMelee, 0, 0f, player.whoAmI);
            }


            if (Main.npc[npcIndex].value > 0f && player.coins && Main.rand.Next(5) == 0)
            {
                int type = 71;
                if (Main.rand.Next(10) == 0)
                {
                    type = 72;
                }
                if (Main.rand.Next(100) == 0)
                {
                    type = 73;
                }
                int Coin = Item.NewItem((int)Main.npc[npcIndex].position.X, (int)Main.npc[npcIndex].position.Y, Main.npc[npcIndex].width, Main.npc[npcIndex].height, type);
                Main.item[Coin].stack = Main.rand.Next(1, 11);
                Main.item[Coin].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
                Main.item[Coin].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)player.direction;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, Coin);
                }
            }
        }

        public void ItemCheck_MeleeHitNPCs(Item sItem, Rectangle itemRectangle, int originalDamage, float knockBack)
        {
            for (int HitNPC = 0; HitNPC < 200; HitNPC++)
            {
                if (!Main.npc[HitNPC].active || Main.npc[HitNPC].immune[player.whoAmI] != 0 || player.attackCD != 0)
                {
                    continue;
                }

                if (!Main.npc[HitNPC].dontTakeDamage && Main.npc[HitNPC].immune[player.whoAmI] == 0)
                {
                    if (!Main.npc[HitNPC].friendly || (Main.npc[HitNPC].type == NPCID.Guide && player.killGuide) || (Main.npc[HitNPC].type == NPCID.Clothier && player.killClothier))
                    {
                        Rectangle vector = new Rectangle((int)Main.npc[HitNPC].position.X, (int)Main.npc[HitNPC].position.Y, Main.npc[HitNPC].width, Main.npc[HitNPC].height);
                        if (itemRectangle.Intersects(vector) && (Main.npc[HitNPC].noTileCollide || player.CanHit(Main.npc[HitNPC])))
                        {
                            int num = Main.DamageVar(originalDamage); ;

                            int NPCtype = Item.NPCtoBanner(Main.npc[HitNPC].BannerID());
                            if (NPCtype > 0 && player.NPCBannerBuff[NPCtype] == true)
                            {
                                num = ((!Main.expertMode) ? ((int)((float)num * ItemID.Sets.BannerStrength[Item.BannerToItem(NPCtype)].NormalDamageDealt)) : ((int)((float)num * ItemID.Sets.BannerStrength[Item.BannerToItem(NPCtype)].ExpertDamageDealt)));
                            }



                            int RealDamage = Main.DamageVar(num);

                            if (Main.npc[HitNPC].life > 5)
                            {
                                player.OnHit(Main.npc[HitNPC].Center.X, Main.npc[HitNPC].Center.Y, Main.npc[HitNPC]);
                            }
                            if (player.armorPenetration > 0)
                            {
                                RealDamage += Main.npc[HitNPC].checkArmorPenetration(player.armorPenetration);
                            }
                            int dmgDone = (int)Main.npc[HitNPC].StrikeNPC(RealDamage, knockBack, player.direction, false);
                            if (sItem.modItem != null)
                            {



                                sItem.modItem.OnHitNPC(player, Main.npc[HitNPC], RealDamage, knockBack, false);
                            }
                            OnHitNPC(Main.npc[HitNPC], RealDamage, knockBack, false);
                            ApplyNPCOnHitEffects(sItem, itemRectangle, num, knockBack, HitNPC, RealDamage, dmgDone);
                            int num5 = Item.NPCtoBanner(Main.npc[HitNPC].BannerID());
                            if (num5 >= 0)
                            {
                                player.lastCreatureHit = num5;
                            }
                            if (Main.netMode != NetmodeID.SinglePlayer)
                            {


                                NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, HitNPC, RealDamage, knockBack, player.direction);

                            }
                            if (player.accDreamCatcher)
                            {
                                player.addDPS(RealDamage);
                            }
                            Main.npc[HitNPC].immune[player.whoAmI] = player.itemAnimation;
                            player.attackCD = Math.Max(1, (int)((double)player.itemAnimationMax * 0.33));
                        }
                    }
                }
                else if (Main.npc[HitNPC].type == NPCID.BlueJellyfish || Main.npc[HitNPC].type == NPCID.PinkJellyfish || Main.npc[HitNPC].type == NPCID.GreenJellyfish || Main.npc[HitNPC].type == NPCID.BloodJelly)
                {
                    Rectangle value = new Rectangle((int)Main.npc[HitNPC].position.X, (int)Main.npc[HitNPC].position.Y, Main.npc[HitNPC].width, Main.npc[HitNPC].height);
                    if (itemRectangle.Intersects(value) && (Main.npc[HitNPC].noTileCollide || player.CanHit(Main.npc[HitNPC])))
                    {
                        player.Hurt(PlayerDeathReason.LegacyDefault(), (int)((double)Main.npc[HitNPC].damage * 1.3), -player.direction);
                        Main.npc[HitNPC].immune[player.whoAmI] = player.itemAnimation;
                        player.attackCD = (int)((double)player.itemAnimationMax * 0.33);
                    }
                }


            }
        }

    }
}
