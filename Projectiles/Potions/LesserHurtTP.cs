using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace MartainsOrder.Projectiles.Potions
{
	public class LesserHurtTP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser hurting Throwable potion");
			aiType = 166;
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 22;
            projectile.aiStyle = 2;
            projectile.friendly = false;
			projectile.hostile = false;
            projectile.thrown = true;
            projectile.penetrate = 15;
            projectile.scale = 1f;
            projectile.timeLeft = 600;
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
			projectile.timeLeft = 2;
			return false;
		}

        public override void Kill(int timeLeft)
        {
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 107, 1f, 0f);
			Main.PlaySound(19, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
			
			for(int i = 0; i < 14; i++) {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 76, -projectile.velocity.X * 0.5f, -projectile.velocity.Y * 0.5f, 100, new Color(75, 5, 5, 255), 1.65f);
            Main.dust[dust].noGravity = false;
            Main.dust[dust].scale = 1.25f;
			Main.dust[dust].velocity *= 0.50f;
			}
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override void AI()
        {
			
			if (projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
				projectile.rotation = 0f;
                projectile.hide = true;
				
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);

                projectile.width = 150;
                projectile.height = 150;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
				
            if (projectile.timeLeft == 1) {
			for (int e = 0; e < 200; e++) {
			Player player = Main.player[e];
			Vector2 center = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
			float offsetX = player.Center.X - center.X;
			float offsetY = player.Center.Y - center.Y;
			float distance = (float)Math.Sqrt(offsetX * offsetX + offsetY * offsetY);
			if (distance < 90f && projectile.position.X < player.position.X + player.width && projectile.position.X + projectile.width > player.position.X && projectile.position.Y < player.position.Y + player.height && projectile.position.Y + projectile.height > player.position.Y) {
				if (player.active) {
					projectile.penetrate -= 1;
					//projectile.hostile = true;
					//projectile.damage = 50;
					player.statLife -= 50;CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), new Color(75, 30, 30, 100),"-50");
				}
			}
			}
				for (int i = 0; i < 200; i++)
            {
			NPC npc = Main.npc[i];
			Vector2 cent = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
			float osX = npc.Center.X - cent.X;
			float osY = npc.Center.Y - cent.Y;
			float dis = (float)Math.Sqrt(osX * osX + osY * osY);
			if (dis < 90f && projectile.position.X < npc.position.X + npc.width && projectile.position.X + projectile.width > npc.position.X && projectile.position.Y < npc.position.Y + npc.height && projectile.position.Y + projectile.height > npc.position.Y) {
				if (npc.active) {
					projectile.penetrate -= 1;
					projectile.friendly = true;
					projectile.thrown = false;
					projectile.damage = 50;
					if(npc.friendly == true){npc.life -= 50;CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(75, 30, 30, 100),"-50");}
				}
				projectile.thrown = true;
			}
			}
			}
			
			}
        }

    }
}