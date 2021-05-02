using System;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace MartainsOrder.Projectiles.Assasin
{
	public class RGBDagger : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RGB Dagger");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
			projectile.timeLeft = 15;
			projectile.tileCollide = true;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 5;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;
		
        public override void AI()
        {
			UpdateOldPos(projectile);
			projectile.spriteDirection = projectile.direction;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if(Main.player[projectile.owner].GetModPlayer<MyPlayer>().throwerRushOn) {
				Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), Main.DiscoColor.R, Main.DiscoColor.G, Main.DiscoColor.B);
				projectile.velocity *= 1.075f; //1.05f
			}
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			projectile.damage = (int)((float)projectile.damage * 0.95);
		}
		public override Color? GetAlpha(Color lightColor) => new Color(Main.DiscoColor.R+50, Main.DiscoColor.G+50, Main.DiscoColor.B+50, 125);
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (!Main.gameInactive && !Main.gameMenu && !Main.gamePaused)
                UpdateOldPos(projectile);
            Color color = Main.DiscoColor;
			
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 pos = projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
            int y = texture.Height / Main.projFrames[projectile.type] * projectile.frame; 
            int tHeight = texture.Height / Main.projFrames[projectile.type];
            Rectangle source = new Rectangle(0, y, texture.Width, tHeight);
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                color = new Color((byte)(color.R*0.8f),(byte)(color.G*0.8f),(byte)(color.B*0.8f),(byte)(color.A*0.7f));
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