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
    public class RecursiveNailers : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Recursive Nailers");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.SpikyBall);
            projectile.tileCollide = true;
			projectile.timeLeft = 300;
			projectile.penetrate = 25;
			projectile.extraUpdates = 1;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            return projHitbox.Intersects(targetHitbox);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10, 0.75f, 0f);
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;

            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 46, Main.rand.NextFloat(-2f,2f), Main.rand.NextFloat(-2f,2f), 100, Color.Lime, 1.50f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 1.25f;
			
			if(Main.rand.Next(3)==0) {
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 42, 0.75f, 0f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.NextFloat(-4f,4f), Main.rand.NextFloat(-8f,0f), mod.ProjectileType("RecursiveNailers"), projectile.damage, projectile.knockBack/2f, projectile.owner, 0f, 0f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.NextFloat(-4f,4f), Main.rand.NextFloat(-8f,0f), mod.ProjectileType("RecursiveNailers"), projectile.damage, projectile.knockBack/2f, projectile.owner, 0f, 0f);
			}
			
            int item = 0;

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(MessageID.KillProjectile);
            }

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(Terraria.ID.MessageID.SyncItem, -1, -1, null, item, 1f, 0f, 0f, 0, 0, 0);
            }
			if (projectile.owner == Main.myPlayer)
            {
                int itemb =
                Main.rand.NextBool(11)
                    ? Item.NewItem(projectile.getRect(), mod.ItemType("RecursiveNailers"))
                    : 0;

                if (Main.netMode == 1 && itemb >= 0)
                {
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, itemb, 1f);
                }
            }
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override void AI()
        {
			UpdateOldPos(projectile);
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (!Main.gameInactive && !Main.gameMenu && !Main.gamePaused)
                UpdateOldPos(projectile);
			Color color = new Color(200,200,200,90);
            /*Color color = default(Color);
			color.R = Utils.Clamp<byte>(color.R, 75, 255);
            color.G = Utils.Clamp<byte>(color.G, 75, 255);
            color.B = Utils.Clamp<byte>(color.B, 75, 255);*/
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 pos = projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
            int y = texture.Height / Main.projFrames[projectile.type] * projectile.frame; 
            int tHeight = texture.Height / Main.projFrames[projectile.type];
            Rectangle source = new Rectangle(0, y, texture.Width, tHeight);
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                color = new Color((byte)(color.R*0.7f),(byte)(color.G*0.85f),(byte)(color.B*0.7f),(byte)(color.A*0.7f));
				float scale = 1f;
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
}