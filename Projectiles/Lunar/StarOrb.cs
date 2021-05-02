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
    public class StarOrb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stellar Orb");
        }

        public override void SetDefaults()
        {
            projectile.aiStyle = 0;
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.timeLeft = 120;
            projectile.penetrate = 1;
            projectile.hide = false;
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;
		
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			target.AddBuff(mod.BuffType("StarConstelation"), 120);
        }

        public override void AI()
		{
			UpdateOldPos(projectile);
			projectile.velocity *= 1.004f;
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.35f, 0.35f, 1.0f);
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, 0f, 0f, 100, default(Color), 1f);
            Main.dust[dust].velocity *= 0f;
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 0.9f;
			
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                if (target.dontTakeDamage == false && target.CanBeChasedBy(this, true))
                {
                    float shootToX = target.position.X + (float)target.width / 2 - projectile.Center.X + Main.rand.Next(target.width / -2, target.width / 2);
                    float shootToY = target.position.Y + (float)target.height / 2 - projectile.Center.Y + Main.rand.Next(target.width / -2, target.width / 2);
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance < 600f && !target.friendly && target.active && projectile.timeLeft / 2f == (int)projectile.timeLeft / 2)
                    {
                        distance = 5.75f / distance;
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        projectile.velocity.X = (shootToX+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X)/6;
                        projectile.velocity.Y = (shootToY+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y)/6;
                    }
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item12, projectile.position);
            for (int i = 0; i < 12; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 1f;
				Main.dust[dustIndex].scale = 1f;
            }
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
                color = new Color((byte)(color.R*0.7f),(byte)(color.G*0.7f),(byte)(color.B*0.95f),(byte)(color.A*0.7f));
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