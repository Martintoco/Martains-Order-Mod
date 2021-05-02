using Terraria;
using System;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MartainsOrder.Projectiles.Lunar
{
    public class SolarMeteorite : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Meteorite");
        }

        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = 0;
            projectile.penetrate = 30;
            projectile.scale = 1f;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.timeLeft = 45;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255,255,255,175);
        }
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (Main.expertMode)
            {
                if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail)
                {
                    damage /= 5;
                }
            }
			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
				projectile.Kill();
			}
			projectile.timeLeft = 3;
			target.AddBuff(189, 240);
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.timeLeft = 3;
            return false;
        }
        public override void AI()
        {
			UpdateOldPos(projectile);
			projectile.rotation += 0.2f;
			if(projectile.timeLeft < 30)projectile.tileCollide = true;
			
			int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X*0.5f, projectile.velocity.Y*0.5f, 100, default(Color), 2.7f);
            Main.dust[dustIndex].velocity *= 2f;
			Main.dust[dustIndex].noGravity = true;
			Main.dust[dustIndex].fadeIn = 2.5f;
			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                projectile.hide = true;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);

                projectile.width = 270;
                projectile.height = 270;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            }
            return;
        }
		public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                projectile.hide = true;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);

                projectile.width = 270;
                projectile.height = 270;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            }
            Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 14, 1.5f, -0.2f);
            for (int i = 0; i < 35; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, Main.rand.NextFloat(-4f,4f), -9f, 100, default(Color), 2.7f);
                Main.dust[dustIndex].velocity *= 2f;
				Main.dust[dustIndex].noGravity = false;
				Main.dust[dustIndex].fadeIn = 2.5f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, Main.rand.NextFloat(-6f,6f), -5f, 100, default(Color), 1.5f);
                Main.dust[dustIndex].velocity *= 2f;
				Main.dust[dustIndex].noGravity = false;
				Main.dust[dustIndex].fadeIn = 2.5f;
            }
            // reset size to normal width and height.
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 18;
            projectile.height = 26;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
        }
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (!Main.gameInactive && !Main.gameMenu && !Main.gamePaused)
                UpdateOldPos(projectile);
            Color color = new Color(255,255,255,255);
			
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
                spriteBatch.Draw(texture, projectile.oldPos[i] + new Vector2(texture.Width * 0.5f, texture.Height * 0.5f) - Main.screenPosition, null, color, projectile.oldRot[i], new Vector2(texture.Width * 0.5f, texture.Height * 0.5f), scale, SpriteEffects.None, 0f);
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
}