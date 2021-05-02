using System;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace MartainsOrder.Items.Lunar
{
    public class StardustSentry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twinkle Star");
            Tooltip.SetDefault("Summons a Twinkle Star sentry that shoots homing orbs");
        }

        public override void SetDefaults()
        {
            item.damage = 92;
            item.mana = 15;
            item.width = 32;
            item.height = 32;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 4;
            item.noMelee = true;
            item.knockBack = 3.25f;
            item.value = 100000;
            item.rare = 10;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("StardustSentrySentry");
            item.summon = true;
            item.sentry = true;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            Main.PlaySound(2, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 6, 0.25f, 0.3f);

            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
    }

    public class StardustSentrySentry : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twinkle Star");
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.sentry = true;
            projectile.width = 50;
            projectile.height = 50;
			projectile.scale = 1.2f;
            projectile.hostile = false;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = Projectile.SentryLifeTime;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.sentry = true;
            //projectile.minion = true;
            projectile.usesLocalNPCImmunity = true;
        }

        private NPC target;

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9, 0.75f);

            for (int i = 0; i < 12; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 2.5f);
                Main.dust[dust].noGravity = false;
				Main.dust[dust].scale = 1.25f;
                Main.dust[dust].velocity *= 0.75f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override void AI()
        {
			UpdateOldPos(projectile);
            Player player = Main.player[projectile.owner];
            player.UpdateMaxTurrets();
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1.75f+Main.rand.NextFloat(-0.05f,0.25f), 1.75f+Main.rand.NextFloat(-0.05f,0.25f), 2.75f);
            if(Main.rand.Next(8)==0)Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 4, 0.05f, 0.2f);

            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 5)
                {
                    projectile.frame = 0;
                }
            }

            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                if (player.HasMinionAttackTargetNPC)
                {
                    target = Main.npc[player.MinionAttackTargetNPC];
                }

                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y - 0.02f;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
				
                if (distance < 700f && !target.friendly && target.active && target.CanBeChasedBy(this, true))
                {
                    if (projectile.ai[0] >= 30f)
                    {
                        distance = 3.55f / distance;
						
                        shootToX *= distance * 4;
                        shootToY *= distance * 4;
                        int damage = 39;              
						
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("StarOrb"), damage, 0, Main.myPlayer, 0f, 0f);
                        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34, 1.5f, 0.2f);
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
        }
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (!Main.gameInactive && !Main.gameMenu && !Main.gamePaused)
                UpdateOldPos(projectile);
            Color color = new Color(255,255,255,255);
			
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 pos = projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
            int y = texture.Height / Main.projFrames[projectile.type] * projectile.frame; 
            int tHeight = texture.Height / Main.projFrames[projectile.type];
            Rectangle source = new Rectangle(0, y, texture.Width, tHeight);
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                color = new Color((byte)(color.R*0.7f),(byte)(color.G*0.7f),(byte)(color.B*0.95f),(byte)(color.A*0.7f));
				float scale = projectile.scale;
                //float scale = 1f - (1f / projectile.oldPos.Length * i);
                spriteBatch.Draw(texture, projectile.oldPos[i] + new Vector2(texture.Width * 0.5f, tHeight * 0.5f) - Main.screenPosition + new Vector2(6, 6), new Rectangle?(source), color, projectile.oldRot[0], source.Size() / 2, scale, SpriteEffects.None, 0f);
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

}