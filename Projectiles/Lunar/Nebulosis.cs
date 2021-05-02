using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.Lunar
{
    public class Nebulosis : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebulosis");
            Main.projFrames[projectile.type] = 4;
            //aiType = 14;
        }

        public override void SetDefaults()
        {
            projectile.width = 70;
            projectile.height = 62;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
			projectile.tileCollide = false;
			projectile.scale = Main.rand.NextFloat(1.1f, 1.3f);
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 45;
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
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 8, 1f, 0f);
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;

            int item = 0;

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(MessageID.KillProjectile);
            }

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(Terraria.ID.MessageID.SyncItem, -1, -1, null, item, 1f, 0f, 0f, 0, 0, 0);
            }
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override void AI()
        {
			projectile.rotation += 0.121f;
            if (++projectile.frameCounter >= 0 && projectile.frameCounter <= 1)
            {
                //projectile.frameCounter = 0;
                projectile.frame = Main.rand.Next(0, 4);
            }
			
			if (projectile.frame == 0)
            {
				
			}
			if (projectile.frame == 1)
            {
				
			}
			if (projectile.frame == 2)
            {
				
			}
			if (projectile.frame == 3)
            {
				
			}
			
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			projectile.damage = (int)((float)projectile.damage * 0.87f);
		}
		
		public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft >= 150)
            {
                return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 200);
            }
            byte num4 = (byte)(projectile.timeLeft * 3);
            byte num5 = (byte)(200.0 * ((double)num4 / (double)byte.MaxValue));
            return new Color((int)num4, (int)num4, (int)num4, (int)num5);
        }

    }
}