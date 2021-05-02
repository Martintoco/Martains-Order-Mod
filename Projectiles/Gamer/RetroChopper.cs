using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace MartainsOrder.Projectiles.Gamer
{
    public class RetroChopper : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("8-bit Chopper");
        }

        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.melee = false;
            projectile.penetrate = 7;
            projectile.tileCollide = false;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
			projectile.timeLeft = 600;
        }
		
		public override void AI()
        {
			projectile.velocity *= 1.0035f;
			projectile.rotation += 0.25f;
			
			float preToX = Main.player[projectile.owner].position.X + (float)Main.player[projectile.owner].width / 2 - projectile.Center.X;
            float preToY = Main.player[projectile.owner].position.Y + (float)Main.player[projectile.owner].height / 2 - projectile.Center.Y;
            float dis = (float)System.Math.Sqrt((double)(preToX * preToX + preToY * preToY));
			
			if(projectile.timeLeft < 60 || projectile.penetrate <= 1 || dis >= 500f) {
                Player target = Main.player[projectile.owner];
                if (!target.dead)
                {
                    float shootToX = target.position.X + (float)target.width / 2 - projectile.Center.X;
                    float shootToY = target.position.Y + (float)target.height / 2 - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
					if(distance <= 3f) projectile.Kill();
					
                    if (target.active)
                    {
                        distance = 3.8f / distance;

                        shootToX *= distance * 3;
                        shootToY *= distance * 3;

                        projectile.velocity.X = (shootToX+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X)/6;
                        projectile.velocity.Y = (shootToY+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y)/6;
                    }
                }
			}
			else {
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                if (target.dontTakeDamage == false && target.CanBeChasedBy(this, true))
                {
                    float shootToX = target.position.X + (float)target.width / 2 - projectile.Center.X + Main.rand.Next(target.width / -2, target.width / 2);
                    float shootToY = target.position.Y + (float)target.height / 2 - projectile.Center.Y + Main.rand.Next(target.width / -2, target.width / 2);
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance < 300f && !target.friendly && target.active)
                    {
                        distance = 3.7f / distance;

                        shootToX *= distance * 3;
                        shootToY *= distance * 3;

                        projectile.velocity.X = (shootToX+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X)/6;
                        projectile.velocity.Y = (shootToY+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y)/6;
                    }
                }
            }
			
			}
        }
		
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 200);
        }
    }
}