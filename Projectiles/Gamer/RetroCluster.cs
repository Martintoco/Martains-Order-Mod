using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.Gamer
{
    public class RetroCluster : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("8-bit Cluster");
        }

        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 44;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 5;
			projectile.timeLeft = 90;
			projectile.tileCollide = false;
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
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;
			
			for(int i = 0; i < 7; i++) {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 8, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 100, Color.White, 1.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 2f;
			}
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;
		
        public override void AI()
        {
			projectile.velocity *= 0.978f;
			projectile.rotation += 0.3f;
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.2f, 0.2f, 0.2f);
        }

    }
}