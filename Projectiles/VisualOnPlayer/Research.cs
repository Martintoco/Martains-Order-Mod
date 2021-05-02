using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace MartainsOrder.Projectiles.VisualOnPlayer
{
    public class Research : ModProjectile
    {
        public float researchLight = 1f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Research");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 22;
            projectile.aiStyle = 0;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.scale = 1.1f;
            projectile.timeLeft = 300;
            projectile.alpha = 50;
        }

        public virtual bool? CanCutTiles()
        {
            return false;
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;
        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] >= 120) { projectile.alpha++; researchLight -= 0.01f; }

            if (++projectile.frameCounter >= 7)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
			
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), researchLight, researchLight, researchLight);

            projectile.position.X = Main.player[projectile.owner].position.X;
            projectile.position.Y = Main.player[projectile.owner].position.Y - 30;
			if(projectile.timeLeft <= 0)projectile.active = false;
        }

    }
}