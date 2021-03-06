﻿using System;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace MartainsOrder.Projectiles.Assasin
{
	public class Celsius : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celsius");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 28;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
			projectile.timeLeft = 12;
			projectile.tileCollide = true;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;
		
        public override void AI()
        {
			UpdateOldPos(projectile);
			projectile.spriteDirection = projectile.direction;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if(Main.player[projectile.owner].GetModPlayer<MyPlayer>().throwerRushOn) {
				if(projectile.timeLeft <= 2) {
					projectile.velocity *= 0.5f;
					projectile.tileCollide = false;
					projectile.hide = true;
					projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
					projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
					projectile.width = 96;
					projectile.height = 96;
					projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
					projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
				}
				projectile.velocity *= 1.05f;
			}
			//Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.1f, 0.1f, 0.1f);
        }
		public override void Kill(int timeLeft)
        {
            if (Main.player[projectile.owner].GetModPlayer<MyPlayer>().throwerRushOn)
            {
                projectile.tileCollide = false;
                projectile.hide = true;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);

                projectile.width = 96;
                projectile.height = 96;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            
            Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 14, 0.5f, 0.05f);
            for (int i = 0; i < 15; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, Color.Yellow, 1f);
                Main.dust[dustIndex].velocity *= 1.5f;
                Main.dust[dustIndex].noGravity = true;
            }
            for (int i = 0; i < 35; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 125, default(Color), 1f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 1.5f;
            }
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 14;
            projectile.height = 28;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			}
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			projectile.damage = (int)((float)projectile.damage * 0.95);
			target.AddBuff(BuffID.OnFire, Main.rand.Next(120,180));
		}
		public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 150);
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (!Main.gameInactive && !Main.gameMenu && !Main.gamePaused)
                UpdateOldPos(projectile);
            Color color = new Color(255,255,255,150);
			
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 pos = projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
            int y = texture.Height / Main.projFrames[projectile.type] * projectile.frame; 
            int tHeight = texture.Height / Main.projFrames[projectile.type];
            Rectangle source = new Rectangle(0, y, texture.Width, tHeight);
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                color = new Color((byte)(color.R*0.8f),(byte)(color.G*0.7f),(byte)(color.B*0.7f),(byte)(color.A*0.7f));
				float scale = 1f;
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