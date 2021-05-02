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
	public class Dustter : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dustter");
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 30;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
			projectile.timeLeft = 11;
			projectile.tileCollide = true;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;
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
				if(projectile.timeLeft == 5)Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (projectile.velocity.X/3f)+Main.rand.NextFloat(-3f,3f), (projectile.velocity.Y/2f)+Main.rand.NextFloat(-3f,3f), mod.ProjectileType("Dust1"), projectile.damage/2, projectile.knockBack/2f, projectile.owner, 0f, 0f);
				projectile.velocity *= 1.05f;
			}
			//Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.1f, 0.1f, 0.1f);
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			projectile.damage = (int)((float)projectile.damage * 0.95);
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
                color = new Color((byte)(color.R*0.7f),(byte)(color.G*0.7f),(byte)(color.B*0.75f),(byte)(color.A*0.7f));
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