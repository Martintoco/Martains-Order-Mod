using Terraria;
using System;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MartainsOrder.Items.Lunar
{
    public class SolarSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sun Slash");
			Tooltip.SetDefault("'Rain down the sun's fury'");
        }
		
		private int meteoriteCD = 0;
        public override void SetDefaults()
        {
            item.damage = 143;
			item.melee = true;
            item.crit = 4;
            item.useStyle = 1;
            item.width = 42;
            item.height = 42;
			item.scale = 1.3f;
            item.useAnimation = 23;
            item.useTime = 23;
            item.shootSpeed = 15f;
            item.knockBack = 4.5f;
            item.rare = 10;
			item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.value = 100000;
            item.shoot = mod.ProjectileType("SolarMeteorite");
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			position.Y = (Main.MouseWorld.Y-650);
			position.X = ((Main.MouseWorld.X*3)+player.Center.X)/4;
			speedY = 30f;
			speedX /= 5f;
			speedX += Main.rand.NextFloat(-2.0f,2.0f);
			meteoriteCD++;
            //if(player.ownedProjectileCounts[item.shoot] < 1)return true;
			if(meteoriteCD >= 2){meteoriteCD = 0;return true;}
			else return false;
        }
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			target.AddBuff(189, 300);
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6, player.velocity.X * 0.25f + (float)(player.direction * 3), player.velocity.Y * 0.25f - 2.25f, 100, default(Color), 1.5f);
			Main.dust[dust].noGravity = true;
        }
		public virtual void UseItemHitbox(Player player, ref Rectangle hitbox, ref bool noHitbox)
		{
			hitbox.X = (int)(hitbox.X *1.3f);
			hitbox.Y = (int)(hitbox.Y *1.3f);
			hitbox.Width = (int)(hitbox.Width *1.3f);
			hitbox.Height = (int)(hitbox.Height *1.3f);
        }
		
    }
}
