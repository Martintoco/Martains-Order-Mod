using Microsoft.Xna.Framework;
using Terraria;

namespace MartainsOrder.Whips
{
    public class FlowerWhipWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Flower Whip");
            summonTagDamage = 3;
            summonTagCrit = 0;
            rangeMult = 1.1f;
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

    }

    public class MWhipWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Martinite Whip");
            summonTagDamage = 6;
            summonTagCrit = 0;
            rangeMult = 1.5f;
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

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
    }
	
	public class YellowPhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
            summonTagDamage = 7;
            summonTagCrit = 0;
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

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
    }
	public class PurplePhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
            summonTagDamage = 7;
            summonTagCrit = 0;
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

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
    }
	public class BluePhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
            summonTagDamage = 7;
            summonTagCrit = 0;
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

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
    }
	public class GreenPhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
            summonTagDamage = 7;
            summonTagCrit = 0;
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

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
    }
	public class RedPhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
            summonTagDamage = 7;
            summonTagCrit = 0;
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

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
    }
	public class WhitePhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
            summonTagDamage = 7;
            summonTagCrit = 0;
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

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
    }
	public class OrangePhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
            summonTagDamage = 7;
            summonTagCrit = 0;
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

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
    }
	public class BlackPhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
            summonTagDamage = 7;
            summonTagCrit = 0;
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

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
    }
	
    public class TulipWhipWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Tulip Whip");
            summonTagDamage = 8;
            summonTagCrit = 3;
            rangeMult = 1.1f;
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

    }

    public class GarnetWhipWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Garnet Whip");
            summonTagDamage = 8;
            summonTagCrit = 0;
            rangeMult = 1.1f;
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

        public override Color? GetAlpha(Color lightColor) => new Color(255, 250, 250, 255);
    }
	
	public class StardustWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Shooting Star");
            summonTagDamage = 0;
            summonTagCrit = 11;
            rangeMult = 1.1f;
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
		
		public override Color? GetAlpha(Color lightColor) => new Color(250, 250, 250, 50);

    }

    public class EoWWhipWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Whipper of Worlds");
            summonTagDamage = 25;
            summonTagCrit = 15;
            rangeMult = 1.1f;
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

    }

    public class SalvageHoneyWhipWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Salvaged Honey Strip");
            summonTagDamage = 23;
            summonTagCrit = 12;
            rangeMult = 1.1f;
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

    }
	
	public class ZenithWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Pinnacle");
            summonTagDamage = 30;
            summonTagCrit = 20;
            rangeMult = 1.1f;
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
		/*public override Color? GetAlpha(Color lightColor) {
			if(Main.player[projectile.owner].ownedProjectileCounts[projectile.type] > 1) {
				return new Color(255, 255, 255, 200);
			}
			else return default(Color);
		}*/
		public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 220);
    }
}
