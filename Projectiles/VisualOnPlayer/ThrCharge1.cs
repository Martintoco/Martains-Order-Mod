using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace MartainsOrder.Projectiles.VisualOnPlayer
{
    public class ThrCharge1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thrower Meter");
        }
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.scale = 1f;
            projectile.timeLeft = 35;
        }
        public virtual bool? CanCutTiles()
        {
            return false;
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 255);
        }
        public override void AI()
        {
			if(Main.player[projectile.owner].GetModPlayer<MyPlayer>().throwerRushOn)projectile.Kill();
            projectile.position.X = Main.player[projectile.owner].position.X - (18 * Main.player[projectile.owner].direction);
            projectile.position.Y = Main.player[projectile.owner].position.Y - 22;
			if(projectile.timeLeft <= 0)projectile.active = false;
        }
    }
	
	public class ThrCharge2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thrower Meter");
        }
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.scale = 1f;
            projectile.timeLeft = 35;
        }
        public virtual bool? CanCutTiles()
        {
            return false;
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 255);
        }
        public override void AI()
        {
			if(Main.player[projectile.owner].GetModPlayer<MyPlayer>().throwerRushOn)projectile.Kill();
            projectile.position.X = Main.player[projectile.owner].position.X - (18 * Main.player[projectile.owner].direction);
            projectile.position.Y = Main.player[projectile.owner].position.Y - 22;
			if(projectile.timeLeft <= 0)projectile.active = false;
        }
    }
	
	public class ThrCharge3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thrower Meter");
        }
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.scale = 1f;
            projectile.timeLeft = 35;
        }
        public virtual bool? CanCutTiles()
        {
            return false;
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 255);
        }
        public override void AI()
        {
			if(Main.player[projectile.owner].GetModPlayer<MyPlayer>().throwerRushOn)projectile.Kill();
            projectile.position.X = Main.player[projectile.owner].position.X - (18 * Main.player[projectile.owner].direction);
            projectile.position.Y = Main.player[projectile.owner].position.Y - 22;
			if(projectile.timeLeft <= 0)projectile.active = false;
        }
    }
	
	public class ThrCharge4 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thrower Meter");
        }
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.scale = 1f;
            projectile.timeLeft = 35;
        }
        public virtual bool? CanCutTiles()
        {
            return false;
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 255);
        }
        public override void AI()
        {
			if(Main.player[projectile.owner].GetModPlayer<MyPlayer>().throwerRushOn)projectile.Kill();
            projectile.position.X = Main.player[projectile.owner].position.X - (18 * Main.player[projectile.owner].direction);
            projectile.position.Y = Main.player[projectile.owner].position.Y - 22;
			if(projectile.timeLeft <= 0)projectile.active = false;
        }
    }
	
	public class ThrCharge5 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thrower Meter");
        }
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.scale = 1f;
            projectile.timeLeft = 35;
        }
        public virtual bool? CanCutTiles()
        {
            return false;
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 255);
        }
        public override void AI()
        {
			if(Main.player[projectile.owner].GetModPlayer<MyPlayer>().throwerRushOn)projectile.Kill();
            projectile.position.X = Main.player[projectile.owner].position.X - (18 * Main.player[projectile.owner].direction);
            projectile.position.Y = Main.player[projectile.owner].position.Y - 22;
			if(projectile.timeLeft <= 0)projectile.active = false;
        }
    }
}