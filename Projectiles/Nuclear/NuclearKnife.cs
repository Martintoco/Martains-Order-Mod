using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.Nuclear
{
    public class NuclearKnife : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nuclear Knife");
            aiType = 14;
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 42;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.scale = 1.2f;
            projectile.penetrate = 50;
            projectile.tileCollide = false;
            projectile.timeLeft = 120;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
        }

        private const float maxTicks = 60f;
        private const int alphaReducation = 25;

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(20, 180);
            target.AddBuff(70, 180);
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            target.AddBuff(20, 180);
            target.AddBuff(70, 180);
        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.8f, 1.4f, 0.1f);
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 178, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.6f);
            Main.dust[dust].noGravity = true;
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        /*public virtual void PostDraw(/*SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
        {
	    /*Texture2D texture = ("Projectiles.NuclearKnife");//mod.GetTexture("items/MyItem_Glowmask");
	        spriteBatch.Draw
	        (
		    texture,
		    new Vector2
		    (
			    item.position.X - Main.screenPosition.X + item.width * 0.5f,
			    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
		    ),
		    new Rectangle(0, 0, texture.Width, texture.Height),
		    Color.White,
		    rotation,
		    texture.Size() * 0.5f,
		    scale, 
		    SpriteEffects.None, 
		    0f
	        );
        }*/
    }
}