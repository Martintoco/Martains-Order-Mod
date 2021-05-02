using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.Gamer
{
    public class RetroBlock : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("8-bit Block");
			Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 36;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.minion = true;
			projectile.minionSlots = 0;
            projectile.penetrate = 3;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
            projectile.timeLeft = 180;
			projectile.tileCollide = true;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            return projHitbox.Intersects(targetHitbox);
        }
		
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
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
			projectile.velocity.Y += 0.8f;
			
			if (++projectile.frameCounter >= 0 && projectile.frameCounter <= 1)
            {
                //projectile.frameCounter = 0;
                projectile.frame = Main.rand.Next(0, 4);
            }
        }

    }
}