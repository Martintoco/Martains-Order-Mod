/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace MartainsOrder.Projectiles.VisualOnPlayer
{
	public class SmoothHomingProjectile : ModProjectile
	{
		//Saucedbox/Sprucecat
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("s m o o t h b o i");
		}

		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 24;
			projectile.alpha = 1;
			projectile.timeLeft = 800;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;	
			projectile.aiStyle = 0;
		}
		public override void AI()
		{
			//Player
			Player target = Main.player[Main.myPlayer];
			//Make it move for 600 ticks
			if (projectile.timeLeft > 600)
			{
				//This is the main stuff
				projectile.rotation = projectile.DirectionTo(target.Center * 1).ToRotation();
				projectile.velocity = projectile.rotation.ToRotationVector2() * 3f;

			}
			//Continue on in the same direction but not at the player until its time is over
			if(projectile.timeLeft < 600)
            {
				projectile.velocity = projectile.oldVelocity;
            }
			//epic
		}
		
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
			projectile.timeLeft = 0;		
        }
        public override void Kill(int timeLeft)
        {
			Main.PlaySound(SoundID.Item69, projectile.position);
		}       
	}
}*/