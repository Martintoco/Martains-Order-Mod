using Terraria;
using System;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MartainsOrder.Projectiles.Flask
{
	public class VoidBiomeFlask : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void barren Biome Flask");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 24;
            projectile.aiStyle = 0;
            projectile.friendly = false;
			projectile.hostile = false;
            projectile.scale = 1f;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 600;
			projectile.rotation = 840f;
        }
		
		private float rotate = 0f;

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;
		
		public virtual bool? CanCutTiles()
        {
            return false;
        }
		public override Color? GetAlpha(Color lightColor)
        {
			return new Color(250, 250, 250, 10);
        }
		
		public override void AI()
        {
			projectile.rotation /= 1.095f;
			projectile.velocity *= 0.975f;
			
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 109, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 1f;
            dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("VoidSolution"), projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 1f;
			
			if(projectile.timeLeft == 598) Main.PlaySound(4, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
			if(projectile.timeLeft <= 300) {
				//for (int i = 0; i < 2; i++)
                //{
					rotate += 0.0211f+(rotate/100f);
                    int num54 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y,(float)((Math.Cos(rotate) * 12f)*-1),(float)((Math.Sin(rotate) * 12f)*-1), mod.ProjectileType("VoidSolution"), 0, 0f, 0);
				//}
			}
		}
    }
}