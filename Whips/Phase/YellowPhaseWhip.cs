using Microsoft.Xna.Framework;
using Terraria;

namespace MartainsOrder.Whips.Phase
{
	public class YellowPhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Yellow PhaseWhip");
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
			DisplayName.SetDefault("Purple PhaseWhip");
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
			DisplayName.SetDefault("Blue PhaseWhip");
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
			DisplayName.SetDefault("Green PhaseWhip");
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
			DisplayName.SetDefault("Red PhaseWhip");
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
			DisplayName.SetDefault("White PhaseWhip");
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
			DisplayName.SetDefault("Orange PhaseWhip");
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
			DisplayName.SetDefault("Dark PhaseWhip");
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
	public class LimePhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Lime PhaseWhip");
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
	public class BrownPhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Brown PhaseWhip");
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
	public class GrayPhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Gray PhaseWhip");
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
	public class TealPhaseWhip : ModWhip
    {
        public override void SafeSetDefaults()
        {
			DisplayName.SetDefault("Teal PhaseWhip");
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
	
}
