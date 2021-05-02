using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace MartainsOrder.Projectiles.Gamer
{
    public class Hatty : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hatty");
            aiType = 6;
        }

        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 100;
            projectile.maxPenetrate = 10;
            projectile.extraUpdates = 1;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;
        }
		private int hattyAi = 0; 
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = height = 12;
            return true;
        }
        public override void AI()
        {
			hattyAi++;
			if(hattyAi >= 45 && hattyAi < 315) {
			if(Main.player[projectile.owner].channel){projectile.velocity = projectile.velocity*(0.15f);}
			Player player = Main.player[Main.myPlayer];
			float offsetX = player.Center.X - projectile.Center.X;
			float offsetY = player.Center.Y - projectile.Center.Y;
			float distance = (float)Math.Sqrt(offsetX * offsetX + offsetY * offsetY);
			if (distance < 48f && Main.player[projectile.owner].channel) {
				if (projectile.owner == Main.myPlayer) {
					if(player.gravDir == 1f) {
					player.velocity.Y -= 3f*Player.jumpSpeed;
					}
					if(player.gravDir == -1f) {
					player.velocity.Y += 3f*Player.jumpSpeed;
					}
					//player.fallStart += 10;
					player.fallStart = (int)(player.position.Y / 16f);
					//player.falling
					hattyAi = 315;
					projectile.velocity = projectile.velocity*(0f);
				}
			}
			}
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 267);  //this is the dust that this projectile will spawn
            Main.dust[dust].velocity /= 3f;
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 10f;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            projectile.velocity.X *= -0.975f;
            projectile.velocity.Y *= -0.975f;
        }
    }
}