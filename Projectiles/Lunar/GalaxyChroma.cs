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
    public class GalaxyChroma : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Chroma");
        }

        public override void SetDefaults()
        {
            projectile.aiStyle = 0;
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.timeLeft = 150;
            projectile.penetrate = 2;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override void AI()
		{
			UpdateOldPos(projectile);
			projectile.velocity *= 1.0055f;
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.9f, 0.3f, 0.9f);
			Color galaxy;
			switch (Main.rand.Next(0,3))
			{
				case 0:
					galaxy = new Color(245,245,50,245);
				break;
				case 1:
                    galaxy = new Color(245,50,245,245);
                break;
				default:
					galaxy = new Color(50,245,245,245);
                break;
			}
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 100, galaxy, 0.9f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 0.9f;
			
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                if (target.friendly == false && target.damage > 0 && target.dontTakeDamage == false && target.CanBeChasedBy(this, true))
                {
                    float shootToX = target.position.X + (float)target.width / 2 - projectile.Center.X + Main.rand.Next(target.width / -2, target.width / 2);
                    float shootToY = target.position.Y + (float)target.height / 2 - projectile.Center.Y + Main.rand.Next(target.width / -2, target.width / 2);
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance < 700f && !target.friendly && target.active && projectile.timeLeft / 3f == (int)projectile.timeLeft / 3)
                    {
                        distance = 5.95f / distance;
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
            Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 29, 0.5f, 0.2f);
            for (int i = 0; i < 10; i++)
            {
				Color galaxy;
				switch (Main.rand.Next(0,3))
				{
					case 0:
					galaxy = new Color(245,245,50,245);
					break;
					case 1:
                    galaxy = new Color(245,50,245,245);
                    break;
					default:
					galaxy = new Color(50,245,245,245);
                    break;
				}
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 100, galaxy, 0.9f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 0.9f;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 100, Color.Purple, 0.9f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 0.9f;
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
                color = new Color((byte)(color.R*0.8f),(byte)(color.G*0.7f),(byte)(color.B*0.85f),(byte)(color.A*0.7f));
				float scale = 1f - (1f / projectile.oldPos.Length * i);
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