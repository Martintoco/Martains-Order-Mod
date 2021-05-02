using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.Gamer
{
	public class RetroBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("8-bit Bolt");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(122);
            projectile.aiStyle = 0;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 150;
            projectile.penetrate = 3;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;
			
			for (int i = 0; i < 10; i++)
            {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("RetroBolt"), projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 50, default(Color), 4f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 1.25f;
			Main.dust[dust].velocity *= 0.5f;
			}

            int item = 0;

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(MessageID.KillProjectile);
            }

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(Terraria.ID.MessageID.SyncItem, -1, -1, null, item, 1f, 0f, 0f, 0, 0, 0);
            }
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.8f, 0.8f, 0.8f);
			
			for (int i = 0; i < 2; i++)
            {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("RetroBolt"), projectile.velocity.X * 0f, projectile.velocity.Y * 0f, 50, default(Color), 0.01f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 1.25f;
			Main.dust[dust].velocity *= 0.5f;
			}
        }
    }
	
}