using Terraria;
using System;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MartainsOrder.Projectiles.TerraGrim
{
    public class CurvedAbyssinian : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Curved Abyssinian");
            aiType = 52;
        }

        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = 3;
            projectile.penetrate = 3;
            projectile.scale = 1f;
            projectile.thrown = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.timeLeft = 90;
			projectile.extraUpdates = 1;
            projectile.usesLocalNPCImmunity = true;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            byte num4 = (byte)(255 - (projectile.timeLeft*2.5f));
            byte num5 = (byte)(100.0 * ((double)num4 / (double)byte.MaxValue));
            return new Color((int)num4, (int)num4, (int)num4, (int)num5);
        }
        public override void AI()
        {
			UpdateOldPos(projectile);
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.7f, 0.9f, 0.7f);
        }
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (!Main.gameInactive && !Main.gameMenu && !Main.gamePaused)
                UpdateOldPos(projectile);
            Color color = default(Color);
			byte num4 = (byte)(255 - (projectile.timeLeft*2.5f));
            byte num5 = (byte)(100.0 * ((double)num4 / (double)byte.MaxValue));
			color = new Color((int)num4, (int)num4, (int)num4, (int)num5);
			
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 pos = projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
            int y = texture.Height / Main.projFrames[projectile.type] * projectile.frame; 
            int tHeight = texture.Height / Main.projFrames[projectile.type];
            Rectangle source = new Rectangle(0, y, texture.Width, tHeight);
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                color = new Color((byte)(color.R*0.8f),(byte)(color.G*0.8f),(byte)(color.B*0.8f),(byte)(color.A*0.8f));
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