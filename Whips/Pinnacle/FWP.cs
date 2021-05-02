using Microsoft.Xna.Framework;
using Terraria;

namespace MartainsOrder.Whips.Pinnacle
{
	public class FWP : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 1;
            summonTagCrit = 1;
            rangeMult = 1f;
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 101) < summonTagCrit)
            {
                crit = true;
            }
            if (crit)
            {
                damage *= 2;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(75, 75, 75, 15);
    }
	public class LWP : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 1;
            summonTagCrit = 1;
            rangeMult = 1f;
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 101) < summonTagCrit)
            {
                crit = true;
            }
            if (crit)
            {
                damage *= 2;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(75, 75, 75, 15);
    }
	public class SWP : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 1;
            summonTagCrit = 1;
            rangeMult = 1f;
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 101) < summonTagCrit)
            {
                crit = true;
            }
            if (crit)
            {
                damage *= 2;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(75, 75, 75, 15);
    }
	public class FCWP : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 1;
            summonTagCrit = 1;
            rangeMult = 1f;
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 101) < summonTagCrit)
            {
                crit = true;
            }
            if (crit)
            {
                damage *= 2;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(75, 75, 75, 15);
    }
	public class TWP : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 1;
            summonTagCrit = 1;
            rangeMult = 1f;
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 101) < summonTagCrit)
            {
                crit = true;
            }
            if (crit)
            {
                damage *= 2;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(75, 75, 75, 15);
    }
	public class CWP : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 1;
            summonTagCrit = 1;
            rangeMult = 1f;
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 101) < summonTagCrit)
            {
                crit = true;
            }
            if (crit)
            {
                damage *= 2;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(75, 75, 75, 15);
    }
	public class WWWP : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 1;
            summonTagCrit = 1;
            rangeMult = 1f;
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 101) < summonTagCrit)
            {
                crit = true;
            }
            if (crit)
            {
                damage *= 2;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(75, 75, 75, 15);
    }
	public class DHWP : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 1;
            summonTagCrit = 1;
            rangeMult = 1f;
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 101) < summonTagCrit)
            {
                crit = true;
            }
            if (crit)
            {
                damage *= 2;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(75, 75, 75, 15);
    }
	public class ELWP : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 1;
            summonTagCrit = 1;
            rangeMult = 1f;
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 101) < summonTagCrit)
            {
                crit = true;
            }
            if (crit)
            {
                damage *= 2;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(75, 75, 75, 15);
    }
	public class SFWP : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 1;
            summonTagCrit = 1;
            rangeMult = 1f;
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 101) < summonTagCrit)
            {
                crit = true;
            }
            if (crit)
            {
                damage *= 2;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(75, 75, 75, 15);
    }
	
}
