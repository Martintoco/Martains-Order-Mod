using System;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.Lunar
{
    public class Fragtal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cracktal");
            //aiType = 166;
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
			projectile.timeLeft = 60;
			projectile.extraUpdates = 1;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            return projHitbox.Intersects(targetHitbox);
        }
		public override void ModifyHitPvp(Player target, ref int damage, ref bool crit)
        {
			projectile.timeLeft = 5;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			projectile.timeLeft = 5;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;

            int item = 0;

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(MessageID.KillProjectile);
            }

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(Terraria.ID.MessageID.SyncItem, -1, -1, null, item, 1f, 0f, 0f, 0, 0, 0);
            }
			
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 6.25f, 0f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -6.25f, 0f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 6.25f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -6.25f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
			
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5.45f, 3.15f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5.45f, 3.15f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 3.15f, -5.45f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -3.15f, -5.45f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
			
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 3.15f, 5.45f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -3.15f, 5.45f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5.45f, -3.15f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5.45f, -3.15f, mod.ProjectileType("Fragtal2"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(245, 245, 245, 150);
        }

        public override void AI()
        {
			UpdateOldPos(projectile);
			projectile.rotation += 0.6f;
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (!Main.gameInactive && !Main.gameMenu && !Main.gamePaused)
                UpdateOldPos(projectile);
            Color color = new Color(250,250,250,100);
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 pos = projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
            int y = texture.Height / Main.projFrames[projectile.type] * projectile.frame; 
            int tHeight = texture.Height / Main.projFrames[projectile.type];
            Rectangle source = new Rectangle(0, y, texture.Width, tHeight);
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                color = new Color((byte)(color.R*0.7f),(byte)(color.G*0.85f),(byte)(color.B*0.7f),(byte)(color.A*0.7f));
				float scale = 1f;
                spriteBatch.Draw(texture, projectile.oldPos[i] + new Vector2(texture.Width * 0.5f, texture.Height * 0.5f) - Main.screenPosition, null, color, projectile.rotation, new Vector2(texture.Width * 0.5f, texture.Height * 0.5f), scale, SpriteEffects.None, 0f);
            }
            spriteBatch.Draw(texture, pos, new Rectangle?(source), color, projectile.rotation, source.Size() / 2, projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public static void UpdateOldPos(Projectile projectile)
        {
            projectile.oldPos[0] = projectile.position;
            for (int i = (projectile.oldPos.Length - 1); i > 0; i--)
                projectile.oldPos[i] = projectile.oldPos[i - 1];
            projectile.oldRot[0] = projectile.rotation;
            for (int i = (projectile.oldRot.Length - 1); i > 0; i--)
                projectile.oldRot[i] = projectile.oldRot[i - 1];
        }

    }
	
	public class Fragtal2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cracktal Shard");
            aiType = 14;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 18;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.thrown = true;
			projectile.tileCollide = false;
            projectile.penetrate = 3;
			projectile.timeLeft = 60;
			projectile.extraUpdates = 1;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            return projHitbox.Intersects(targetHitbox);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;

            int item = 0;

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(MessageID.KillProjectile);
            }

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(Terraria.ID.MessageID.SyncItem, -1, -1, null, item, 1f, 0f, 0f, 0, 0, 0);
            }
			
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X*1.45f, projectile.velocity.Y*1.45f, mod.ProjectileType("Fragtal3"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X*-1.45f, projectile.velocity.Y*-1.45f, mod.ProjectileType("Fragtal3"), projectile.damage/2, 0f, projectile.owner, 0f, 0f);
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(245, 245, 245, 125);
        }

        public override void AI()
        {
			//epic
        }

    }

    public class Fragtal3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fractal Shard");
            Main.projFrames[projectile.type] = 3;
            aiType = 14;
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 14;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.thrown = true;
			projectile.tileCollide = false;
            projectile.penetrate = 3;
			projectile.damage = 38;
            projectile.timeLeft = 45;
			projectile.extraUpdates = 1;
			projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            return projHitbox.Intersects(targetHitbox);
        }

        public override void Kill(int timeLeft)
        {
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;

            int item = 0;

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(MessageID.KillProjectile);
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft >= 60)
            {
                return new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 100);
            }
            byte num4 = (byte)(projectile.timeLeft * 3);
            byte num5 = (byte)(100.0 * ((double)num4 / (double)byte.MaxValue));
            return new Color((int)num4, (int)num4, (int)num4, (int)num5);

        }

        public override void AI()
        {
            if (++projectile.frameCounter >= 0 && projectile.frameCounter <= 1)
            {
                //projectile.frameCounter = 0;
                projectile.frame = Main.rand.Next(0, 3);
            }
			if (projectile.damage <= 0) projectile.damage += 1;
        }

    }
}