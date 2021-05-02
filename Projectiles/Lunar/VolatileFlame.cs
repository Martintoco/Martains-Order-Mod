using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.Lunar
{
    public class VolatileFlame : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Volatile Flame");
            //aiType = 85;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(85);
            projectile.aiStyle = 0; //23
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 60;
            projectile.penetrate = 10;
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.NextFloat(-3f,3f), Main.rand.NextFloat(-3f,3f), mod.ProjectileType("VolatileSpark"), (int)(projectile.damage/2), knockback-1f, projectile.owner, 0f, 0f);
			if(Main.rand.Next(3)!=0)Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.NextFloat(-3f,3f), Main.rand.NextFloat(-3f,3f), mod.ProjectileType("VolatileSpark"), (int)(projectile.damage/2), knockback-1f, projectile.owner, 0f, 0f);
            target.AddBuff(BuffID.Electrified, 180);
        }
        public override void ModifyHitPvp(Player target, ref int damage, ref bool crit)
        {
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.NextFloat(-3f,3f), Main.rand.NextFloat(-3f,3f), mod.ProjectileType("VolatileSpark"), (int)(projectile.damage/2), projectile.knockBack-1f, projectile.owner, 0f, 0f);
			if(Main.rand.Next(3)!=0)Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.NextFloat(-3f,3f), Main.rand.NextFloat(-3f,3f), mod.ProjectileType("VolatileSpark"), (int)(projectile.damage/2), projectile.knockBack-1f, projectile.owner, 0f, 0f);
            target.AddBuff(BuffID.Electrified, 180);
        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.9f, 1.1f, 1.2f);
			
			/*if(Main.rand.Next(2)==0) {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226, projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.75f, 100, new Color(200,225,255,10), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 2.25f;
			}*/
			if(Main.rand.Next(6)==0) {
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 100, new Color(190,200,255,10), 1f);
			Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 4f;
			}
			if(Main.rand.Next(8)==0) {
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.75f, 100, new Color(190,200,255,10), 1f);
			Main.dust[dust].noGravity = false;
            Main.dust[dust].scale = 1.5f;
			}
			if(Main.rand.Next(6)==0) {
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 100, new Color(190,255,200,10), 1f);
			Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 4f;
			}
			if(Main.rand.Next(8)==0) {
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.75f, 100, new Color(190,255,200,10), 1f);
			Main.dust[dust].noGravity = false;
            Main.dust[dust].scale = 1.5f;
			}
        }
    }
	
	public class VolatileSpark : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Volatile Spark");
        }

        public override void SetDefaults()
        {
			projectile.CloneDefaults(85);
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 0;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.tileCollide = false;
            projectile.timeLeft = 120;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            target.AddBuff(BuffID.Electrified, 180);
        }
        public override void ModifyHitPvp(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(BuffID.Electrified, 180);
        }

        public override void AI()
        {
			if(projectile.timeLeft <= 60) projectile.friendly = true;
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (target.friendly == false && target.damage > 0 && target.dontTakeDamage == false && target.CanBeChasedBy(this, true) && projectile.timeLeft <= 60 && Main.rand.Next(4)==0)
                {
                    float shootToX = target.position.X + (float)target.width / 2 - projectile.Center.X + Main.rand.Next(target.width / -2, target.width / 2);
                    float shootToY = target.position.Y + (float)target.height / 2 - projectile.Center.Y + Main.rand.Next(target.width / -2, target.width / 2);
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance < 700f && !target.friendly && target.active)
                    {
                        distance = 3f / distance;

                        shootToX *= distance * 3;
                        shootToY *= distance * 3;

                        projectile.velocity.X = (shootToX+projectile.oldVelocity.X+projectile.oldVelocity.X+projectile.oldVelocity.X)/4;
                        projectile.velocity.Y = (shootToY+projectile.oldVelocity.Y+projectile.oldVelocity.Y+projectile.oldVelocity.Y)/4;
                    }
                }
            }
			if(Main.rand.Next(4)==0) {
			/*int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226, projectile.velocity.X * 0f, projectile.velocity.Y * 0f, 100, default(Color), 1f);
			Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 0.30f;
			Main.dust[dust].velocity *= 0.5f;*/
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229, 0f, 0f, 100, default(Color), 1f);
            Main.dust[dust].velocity *= 0f;
			Main.dust[dust].noGravity = true;
			Main.dust[dust].alpha = 200;
			Main.dust[dust].scale = 0.75f;
			}

        }
    }
}