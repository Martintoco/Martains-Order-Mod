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
	public class MelioArcus : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Melio Arcus");
			Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 22;
            projectile.aiStyle = 0;
            projectile.friendly = false;
			projectile.hostile = false;
			projectile.ranged = true;
            projectile.scale = 1f;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 75;
        }
		public override Color? GetAlpha(Color lightColor)
        {
            byte num4 = (byte)(255 - (projectile.timeLeft*3));
            byte num5 = (byte)(100.0 * ((double)num4 / (double)byte.MaxValue));
            return new Color((int)num4, (int)num4, (int)num4, (int)num5);
        }
		public override void AI()
        {
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.65f, 0.8f, 0.65f);
			projectile.velocity *= 0.85f;
			projectile.spriteDirection = projectile.direction;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			
			if (++projectile.frameCounter >= 6)
            {
				if(projectile.frame < 4) {
					projectile.frameCounter = 0;
					projectile.frame ++;
				}
            }
			if(projectile.frame == 3 && projectile.frameCounter == 5){Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y,projectile.velocity.X*125.75f,projectile.velocity.Y*125.75f, mod.ProjectileType("MelioArcus2"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
			Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 5, 1f, 0f);
			}
		}
    }
	
	public class MelioArcus2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grim-flash Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 0;
            projectile.friendly = true;
			projectile.ranged = true;
            projectile.scale = 1f;
            projectile.penetrate = 2;
            projectile.tileCollide = true;
            projectile.timeLeft = 30;
			projectile.hide = true;
			projectile.extraUpdates = 2;
			projectile.usesLocalNPCImmunity = true;
			projectile.arrow = true;
        }
		public override void AI()
        {
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.65f, 0.8f, 0.65f);
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, projectile.velocity.X * 0.15f, projectile.velocity.Y * 0.15f, 100, Color.Teal, 1.4f);
            Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 0.9f;
		}
    }
}