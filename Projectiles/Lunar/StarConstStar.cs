using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.Lunar
{
    public class StarConstStar : ModProjectile
    {
		private int light = 0;
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Constelation Star");
            //aiType = 83;
        }

        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 28;
            projectile.aiStyle = 0;
			projectile.friendly = false;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.scale = 1f;
            projectile.penetrate = 2;
            projectile.timeLeft = 120;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 60;
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override void AI()
        {
			light+=5;
			projectile.velocity=(projectile.velocity*0.97f);
			if(Main.player[projectile.owner].ownedProjectileCounts[mod.ProjectileType("StarConstStar")] > 45) {
			if(Main.rand.Next(3)==0) projectile.timeLeft -= 135;
				else projectile.active = false;
			}
            if (projectile.timeLeft <= 2)
            {
				projectile.hide = true;
				projectile.friendly = true;
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);

                projectile.width = 340;
                projectile.height = 340;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                projectile.damage = 85;
                projectile.knockBack = 4f;
				
				Main.PlaySound(SoundID.Item10, projectile.position);
            }
			if (projectile.timeLeft <= 5) {
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, 0f, 0f, 100, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 2.1f;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, 0f, 0f, 100, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 1.9f;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, 0f, 0f, 100, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 2f;
			Main.dust[dust].noLight = true;
			}
        }
        public override Color? GetAlpha(Color lightColor) 
		{
		return new Color(light+50, light+50, light+50, light);
		}

    }
}