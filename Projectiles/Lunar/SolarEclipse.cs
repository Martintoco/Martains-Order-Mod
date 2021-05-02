using System;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace MartainsOrder.Projectiles.Lunar
{
    public class SolarEclipse : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
            // Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 395f;
            // Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = (16.7f*Main.player[projectile.owner].meleeSpeed);
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 1;
            projectile.width = 20;
            projectile.height = 20;
            // aiStyle 99 is used for all yoyos, and is Extremely suggested, as yoyo are extremely difficult without them
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1.1f;
			drawOriginOffsetY = -2;
        }
        // notes for aiStyle 99: 
        // localAI[0] is used for timing up to YoyosLifeTimeMultiplier
        // localAI[1] can be used freely by specific types
        // ai[0] and ai[1] usually point towards the x and y world coordinate hover point
        // ai[0] is -1f once YoyosLifeTimeMultiplier is reached, when the player is stoned/frozen, when the yoyo is too far away, or the player is no longer clicking the shoot button.
        // ai[0] being negative makes the yoyo move back towards the player
        // Any AI method can be used for dust, spawning projectiles, etc specific to your yoyo.

        public override void PostAI()
        {
			UpdateOldPos(projectile);
			
			if(Main.rand.Next(2)==0) {
            int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X*0.5f, projectile.velocity.Y*0.5f, 100, default(Color), 1.5f);
            Main.dust[dustIndex].velocity *= 2f;
			Main.dust[dustIndex].noGravity = true;
			Main.dust[dustIndex].fadeIn = 2f;
			}
			
			if(projectile.velocity.X <= 0 && projectile.velocity.Y <= 0) {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			}
        }
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 612, (int)(projectile.damage/2), knockback+2f, projectile.owner, 0f, 0f);
			target.AddBuff(189, 180);
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(240, 240, 240, 0);
        }
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (!Main.gameInactive && !Main.gameMenu && !Main.gamePaused)
                UpdateOldPos(projectile);
            Color color = default(Color);
			color.R = Utils.Clamp<byte>(color.R, 50, 255);
            color.G = Utils.Clamp<byte>(color.G, 50, 250);
            color.B = Utils.Clamp<byte>(color.B, 50, 250);
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 pos = projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
            int y = texture.Height / Main.projFrames[projectile.type] * projectile.frame; 
            int tHeight = texture.Height / Main.projFrames[projectile.type];
            Rectangle source = new Rectangle(0, y, texture.Width, tHeight);
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                color = new Color((byte)(color.R*0.95f),(byte)(color.G*0.7f),(byte)(color.B*0.65f),(byte)(color.A*0.65f));
				float scale = 1f;
                //float scale = 1f - (1f / projectile.oldPos.Length * i);
                spriteBatch.Draw(texture, projectile.oldPos[i] + new Vector2(texture.Width * 0.5f, texture.Height * 0.5f) - Main.screenPosition, null, color, projectile.rotation, new Vector2(texture.Width * 0.5f, texture.Height * 0.5f), scale, SpriteEffects.None, 0f);
            }
            spriteBatch.Draw(texture, pos, new Rectangle?(source), color, projectile.rotation, source.Size() / 2, projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public static void UpdateOldPos(Projectile projectile)
        {
            projectile.oldPos[0] = projectile.position;
            for (int i = (projectile.oldPos.Length - 1); i > 0; i--)
                projectile.oldPos[i] = projectile.oldPos[i - 1];
            projectile.oldRot[0] = projectile.rotation;
            for (int i = (projectile.oldRot.Length - 1); i > 0; i--)
                projectile.oldRot[i] = projectile.oldRot[i - 1];
        }
    }
	
	/*public class SolarEclipseBoom : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Explosion");
			Main.projFrames[projectile.type] = 5;
			//aiType = 495;
        }

        public override void SetDefaults()
        {
			projectile.aiStyle = 0;
			projectile.width = 60;
			projectile.height = 60;
			projectile.scale = 1f;
            projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			//projectile.extraUpdates = 1;
			projectile.timeLeft = 15;
			projectile.melee = true;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;
        }     
		
		private const float maxTicks = 60f;
        private const int alphaReducation = 25;
		
		public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1f, 0.6f, 0.2f);
			
			if (++projectile.frameCounter >= 3) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 5) {
					projectile.frame = 0;
				}
			}
			//int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, (Main.rand.Next(-5,6)), (Main.rand.Next(-5,6)), 100, default(Color), 1.50f);
			//Main.dust[dust].noGravity = true;
			//Main.dust[dust].scale = 2f;
        }
		
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 100);
        }
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			target.AddBuff(189, 180);
        }
    }*/
}
