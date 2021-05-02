using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.Lunar
{
    public class ElectroRocket : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electro Rocket");
        }

        public override void SetDefaults()
        {
            projectile.aiStyle = 1;
			aiType = 14;
            projectile.ranged = true;
            projectile.width = 14;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 135;
            projectile.penetrate = -1;
            projectile.hide = false;
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;
		
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (Main.expertMode)
            {
                if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail)
                {
                    damage /= 5;
                }
            }
			
			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
				projectile.Kill();
			}
			projectile.timeLeft = 3;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                projectile.velocity.X = oldVelocity.X * -0.75f;
            }
            if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                projectile.velocity.Y = oldVelocity.Y * -0.75f;
            }
			projectile.timeLeft -= 2;
            return false;
        }

        public override void AI()
		{
			projectile.velocity = projectile.velocity*(1.0075f);
				
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229, 0f, 0f, 100, default(Color), 1f);
            Main.dust[dust].velocity *= 0f;
			Main.dust[dust].noGravity = true;
			Main.dust[dust].alpha = 200;
			Main.dust[dust].scale = 1f;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 1f;
			Main.dust[dust].velocity *= 0f;
			
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                if (target.dontTakeDamage == false && target.CanBeChasedBy(this, true))
                {
                    float shootToX = target.position.X + (float)target.width / 2 - projectile.Center.X + Main.rand.Next(target.width / -2, target.width / 2);
                    float shootToY = target.position.Y + (float)target.height / 2 - projectile.Center.Y + Main.rand.Next(target.width / -2, target.width / 2);
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance < 600f && !target.friendly && target.active && projectile.timeLeft / 4f == (int)projectile.timeLeft / 4)
                    {
                        distance = 4.85f / distance;
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        projectile.velocity.X = (shootToX+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X)/6;
                        projectile.velocity.Y = (shootToY+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y)/6;
                    }
                }
            }

            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                projectile.hide = true;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);

                projectile.width = 160;
                projectile.height = 160;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            }
            return;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                projectile.hide = true;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);

                projectile.width = 160;
                projectile.height = 160;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            }
            Main.PlaySound(SoundID.Item14, projectile.position);
            for (int i = 0; i < 30; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 0.55f);
                Main.dust[dustIndex].velocity *= 1.5f;
                Main.dust[dustIndex].noGravity = true;
            }
            for (int i = 0; i < 70; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, 0f, 0f, 100, default(Color), 0.60f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 1f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, 0f, -2f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 1.15f;
                Main.dust[dustIndex].noGravity = false;
            }
            for (int g = 0; g < 1; g++)
            {
                int goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 0.2f);
                Main.gore[goreIndex].scale = 0.9f;
                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.3f;
                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.0f;
                goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 0.2f);
                Main.gore[goreIndex].scale = 0.9f;
                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.3f;
                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.0f;
                goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 0.2f);
                Main.gore[goreIndex].scale = 0.9f;
                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.3f;
                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
                goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 0.2f);
                Main.gore[goreIndex].scale = 0.9f;
                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.3f;
                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
            }
            // reset size to normal width and height.
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 14;
            projectile.height = 22;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
        }

    }
}