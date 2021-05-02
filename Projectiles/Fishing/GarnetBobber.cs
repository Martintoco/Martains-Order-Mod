using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.Fishing
{
    public class GarnetBobber : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Bobber");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BobberWooden);
            drawOriginOffsetY = -2;
            drawOriginOffsetX = 2;
            projectile.width = 14;
            projectile.height = 14;
        }

        public override void AI()
        {
            /*if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 0.9f);
                Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].velocity /= 2f;
            }*/
        }

        public override bool PreDrawExtras(SpriteBatch spriteBatch)
        {

            Lighting.AddLight(projectile.Center, 0.85f, 0.45f, 0.45f);
			
            int xPositionAdditive = 45;
            float yPositionAdditive = 35f;

            Player player = Main.player[projectile.owner];
            if (!projectile.bobber || player.inventory[player.selectedItem].holdStyle <= 0)
                return false;

            Vector2 lineOrigin = player.MountedCenter;
            lineOrigin.Y += player.gfxOffY;
            int type = player.inventory[player.selectedItem].type;
			
            float gravity = player.gravDir;

            if (type == mod.ItemType("GarnetFishingPole"))
            {
                lineOrigin.X += xPositionAdditive * player.direction;
                if (player.direction < 0)
                {
                    lineOrigin.X -= 13f;
                }
                lineOrigin.Y -= yPositionAdditive * gravity;
            }

            if (gravity == -1f)
            {
                lineOrigin.Y -= 12f;
            }
			
            lineOrigin = player.RotatedRelativePoint(lineOrigin + new Vector2(8f), true) - new Vector2(8f);
            Vector2 playerToProjectile = projectile.Center - lineOrigin;
            bool canDraw = true;
            if (playerToProjectile.X == 0f && playerToProjectile.Y == 0f)
                return false;

            float playerToProjectileMagnitude = playerToProjectile.Length();
            playerToProjectileMagnitude = 12f / playerToProjectileMagnitude;
            playerToProjectile *= playerToProjectileMagnitude;
            lineOrigin -= playerToProjectile;
            playerToProjectile = projectile.Center - lineOrigin;
			
            while (canDraw)
            {
                float height = 12f;
                float positionMagnitude = playerToProjectile.Length();
                if (float.IsNaN(positionMagnitude) || float.IsNaN(positionMagnitude))
                    break;

                if (positionMagnitude < 20f)
                {
                    height = positionMagnitude - 8f;
                    canDraw = false;
                }
                playerToProjectile *= 12f / positionMagnitude;
                lineOrigin += playerToProjectile;
                playerToProjectile.X = projectile.position.X + projectile.width * 0.5f - lineOrigin.X;
                playerToProjectile.Y = projectile.position.Y + projectile.height * 0.1f - lineOrigin.Y;
                if (positionMagnitude > 12f)
                {
                    float positionInverseMultiplier = 0.3f;
                    float absVelocitySum = Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y);
                    if (absVelocitySum > 16f)
                    {
                        absVelocitySum = 16f;
                    }
                    absVelocitySum = 1f - absVelocitySum / 16f;
                    positionInverseMultiplier *= absVelocitySum;
                    absVelocitySum = positionMagnitude / 80f;
                    if (absVelocitySum > 1f)
                    {
                        absVelocitySum = 1f;
                    }
                    positionInverseMultiplier *= absVelocitySum;
                    if (positionInverseMultiplier < 0f)
                    {
                        positionInverseMultiplier = 0f;
                    }
                    absVelocitySum = 1f - projectile.localAI[0] / 100f;
                    positionInverseMultiplier *= absVelocitySum;
                    if (playerToProjectile.Y > 0f)
                    {
                        playerToProjectile.Y *= 1f + positionInverseMultiplier;
                        playerToProjectile.X *= 1f - positionInverseMultiplier;
                    }
                    else
                    {
                        absVelocitySum = Math.Abs(projectile.velocity.X) / 3f;
                        if (absVelocitySum > 1f)
                        {
                            absVelocitySum = 1f;
                        }
                        absVelocitySum -= 0.5f;
                        positionInverseMultiplier *= absVelocitySum;
                        if (positionInverseMultiplier > 0f)
                        {
                            positionInverseMultiplier *= 2f;
                        }
                        playerToProjectile.Y *= 1f + positionInverseMultiplier;
                        playerToProjectile.X *= 1f - positionInverseMultiplier;
                    }
                }
                Color lineColor = Lighting.GetColor((int)lineOrigin.X / 16, (int)(lineOrigin.Y / 16f), new Color(255,100,100,200));//Fuchsia
                float rotation = playerToProjectile.ToRotation() - MathHelper.PiOver2;
                Main.spriteBatch.Draw(Main.fishingLineTexture, new Vector2(lineOrigin.X - Main.screenPosition.X + Main.fishingLineTexture.Width * 0.5f, lineOrigin.Y - Main.screenPosition.Y + Main.fishingLineTexture.Height * 0.5f), new Rectangle(0, 0, Main.fishingLineTexture.Width, (int)height), lineColor, rotation, new Vector2(Main.fishingLineTexture.Width * 0.5f, 0f), 1f, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
