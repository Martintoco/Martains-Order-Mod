using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Tantalum
{
    public class TantalumSetry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Drone Control");
            Tooltip.SetDefault("Summons a Tantalum Drone that shoots Missiles");
        }

        public override void SetDefaults()
        {
            item.damage = 37;
            item.mana = 15;
            item.width = 32;
            item.height = 32;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 3;
            item.noMelee = true;
            item.knockBack = 3.25f;
            item.value = 22000;
            item.rare = 5;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("TantalumSetryDrone");
            item.summon = true;
            item.sentry = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TantalumBar"), 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;   //this make so the projectile will spawn at the mouse cursor position
            Main.PlaySound(2, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 37);

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

    public class TantalumSetryDrone : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tantalum Drone Setry");
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            Main.projFrames[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            projectile.sentry = true;
            projectile.width = 40;
            projectile.height = 38;
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

        private float maxDistance = 1000f;

        private int timer;

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(2, projectile.Center, 62);

            for (int i = 0; i < 12; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 28, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 2.50f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
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
            Player player = Main.player[projectile.owner];
            player.UpdateMaxTurrets();
            timer++;

            if(Main.rand.Next(3)==0)Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 19, 0.5f, 0.2f);

            if (++projectile.frameCounter >= 2)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 2)
                {
                    projectile.frame = 0;
                }
            }

            if (timer >= 0 && timer < 60)
            {
                projectile.velocity.Y += 0.007f;
            }
            if (timer == 60) projectile.velocity.Y *= 0.0000001f;
            if (timer >= 60 && timer < 120)
            {
                projectile.velocity.Y += -0.007f;
            }
            if (timer >= 120) { projectile.velocity.Y = 0f; timer = 0; }

            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.5f;
            }
            projectile.rotation += 0f;

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
				
                if (distance < 635f && !target.friendly && target.active && target.CanBeChasedBy(this, true))
                {
                    if (projectile.ai[0] >= 70f) 
                    {
                        distance = 5.9f / distance;
						
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 39;              
						
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("TantalumMissile"), damage, 0, Main.myPlayer, 0f, 0f);
                        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 40);
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;

        }
    }

}