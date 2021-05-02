using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Projectiles.VisualOnPlayer
{
    public class GlobalProjectiles : GlobalProjectile
    {
		public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
		
		public int oldUpdates = 0;
        public override void SetDefaults(Projectile projectile)
        {
			projectile.usesLocalNPCImmunity = true;
            if (projectile.type == ProjectileID.Bee)
            {
                projectile.damage -= (projectile.damage / 3);
                //projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = 65;
            }
            if (projectile.type == ProjectileID.GiantBee)
            {
                projectile.damage -= (projectile.damage / 3);
                //projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = 50;
            }
            if (projectile.type == ProjectileID.Wasp)
            {
                projectile.damage -= (projectile.damage / 3);
                //projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = 50;
            }
            if (projectile.type == ProjectileID.BulletHighVelocity)
            {
                projectile.penetrate = 2;
            }
			if (projectile.type == 625 || projectile.type == 626 || projectile.type == 627)
            {
                if(projectile.damage > 50)projectile.damage = (int)(projectile.damage*0.525f);
            }
			/*if (projectile.minion == true || projectile.melee == false && projectile.ranged == false && projectile.magic == false && projectile.thrown == false && Main.player[projectile.owner].active)
            {
                projectile.usesLocalNPCImmunity = true;
            }*/
			oldUpdates = projectile.extraUpdates;
        }
		
		public int yoyoSpiritCD = 0;
		public int voodooJetsCD = 0;
		public bool homingSightCheck = false;
		public override void AI(Projectile projectile) 
		{
			Player player = Main.player[projectile.owner];
			
			if(player.GetModPlayer<MyPlayer>().engineerBelt && projectile.sentry == true) projectile.extraUpdates = oldUpdates + 1;
			if(!player.GetModPlayer<MyPlayer>().engineerBelt && projectile.sentry == true) projectile.extraUpdates = oldUpdates;
			
			if(player.GetModPlayer<MyPlayer>().voodooJets && projectile.minion == true) {
				voodooJetsCD++;
				if(voodooJetsCD > 4) {
					projectile.extraUpdates = oldUpdates + 1;
					voodooJetsCD = 0;
				}
				else projectile.extraUpdates = oldUpdates;
				if(Main.rand.Next(15)==0) {int num14 = Dust.NewDust(new Vector2(projectile.position.X - 4f, projectile.position.Y - 4f), projectile.width + 8, projectile.height + 8, 27, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
				Main.dust[num14].position = (Main.dust[num14].position + projectile.Center) / 2f;
				Main.dust[num14].noGravity = true;
				Main.dust[num14].velocity *= 1.5f;
				}
			}
			if(player.GetModPlayer<MyPlayer>().homingSight == true && projectile.arrow == true && projectile.ranged == true) {
				Vector2 oldVelHS = new Vector2(projectile.velocity.X, projectile.velocity.Y);
				for(int i = 0; i < 200; i++) {
					NPC target = Main.npc[i];
					if (target.active && target.dontTakeDamage == false && target.CanBeChasedBy(this, true))
					{
                    float shootToX = target.position.X + (float)target.width / 2 - projectile.Center.X + Main.rand.Next(target.width / -2, target.width / 2);
                    float shootToY = target.position.Y + (float)target.height / 2 - projectile.Center.Y + Main.rand.Next(target.width / -2, target.width / 2);
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance < 650f && target.active)
                    {
                        distance = 7f / distance;
						
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
						
                        projectile.velocity.X = ((oldVelHS.X*25f)+(projectile.oldVelocity.X*24f)+shootToX)/50f;
                        projectile.velocity.Y = ((oldVelHS.Y*25f)+(projectile.oldVelocity.Y*24f)+shootToY)/50f;
						projectile.velocity *= 1.005f;
                    }
					}
				}
				if(Main.rand.Next(15)==0) {int num14 = Dust.NewDust(new Vector2(projectile.position.X - 4f, projectile.position.Y - 4f), projectile.width + 8, projectile.height + 8, 27, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
				Main.dust[num14].position = (Main.dust[num14].position + projectile.Center) / 2f;
				Main.dust[num14].noGravity = true;
				Main.dust[num14].velocity *= 1.5f;
				}
			}
			if(!player.GetModPlayer<MyPlayer>().voodooJets && projectile.minion == true) projectile.extraUpdates = oldUpdates;
			
			if(player.GetModPlayer<MyPlayer>().hookUp && projectile.aiStyle == 7) {
				projectile.velocity *= 1.06f;
			}
			if(player.GetModPlayer<MyPlayer>().hookVoid && projectile.aiStyle == 7) {
				Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.65f, 0.65f, 0.65f);
				projectile.damage += 3;
				projectile.friendly = true;
			}
			if(player.GetModPlayer<MyPlayer>().yoyoSpeed && projectile.aiStyle == 99 && projectile.ai[0] != -1) {
				projectile.velocity *= 1.11f;
			}
			if(player.GetModPlayer<MyPlayer>().yoyoLight && projectile.aiStyle == 99) {
				/*if(player.GetModPlayer<MyPlayer>().yoyoSpirit)Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.4f, 0.45f, 0.925f);
				if(player.GetModPlayer<MyPlayer>().yoyoSpeed)Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1.0f, 0.15f, 0.15f);*/
				Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.65f, 0.65f, 0.65f);
			}
			if(player.GetModPlayer<MyPlayer>().yoyoSpirit && projectile.aiStyle == 99) {
				yoyoSpiritCD++;
				if(yoyoSpiritCD >= 2) {
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X*0.05f, projectile.velocity.Y*0.05f, mod.ProjectileType("SpiritDroplet"), projectile.damage/2, projectile.knockBack/2f, projectile.owner, 0f, 0f);
				yoyoSpiritCD= 0;
				}
			}
			if(player.GetModPlayer<MyPlayer>().paperWorks && (projectile.aiStyle == 16 || projectile.type == mod.ProjectileType("CoalRocket") || projectile.type == mod.ProjectileType("FishyumRocket")) && projectile.ranged) {
				Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.65f, 0.65f, 0.65f);
			}
			if(player.GetModPlayer<MyPlayer>().frozenQuiver && projectile.type == ProjectileID.WoodenArrowFriendly && projectile.ranged == true) {
				projectile.type = ProjectileID.FrostburnArrow;
			}
			if(player.GetModPlayer<MyPlayer>().everfrostStone && projectile.thrown == true && projectile.friendly) {
				int num14 = Dust.NewDust(new Vector2(projectile.position.X - 4f, projectile.position.Y - 4f), projectile.width + 8, projectile.height + 8, 135, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num14].scale = 1.5f;
				}
				Main.dust[num14].noGravity = true;
				Main.dust[num14].velocity.X *= 2f;
				Main.dust[num14].velocity.Y *= 2f;
				projectile.coldDamage = true;
			}
			if(player.GetModPlayer<MyPlayer>().dankScroll && player.inventory[player.selectedItem].consumable == true && player.inventory[player.selectedItem].thrown == true && projectile.thrown == true && Main.rand.Next(3)==0) {
				int num14 = Dust.NewDust(new Vector2(projectile.position.X - 4f, projectile.position.Y - 4f), projectile.width + 8, projectile.height + 8, 4, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, Color.Blue, 2f);
				Main.dust[num14].noGravity = true;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num14].scale = 1.25f;
				}
				Main.dust[num14].velocity.X *= 2f;
				Main.dust[num14].velocity.Y *= 2f;
				if(Main.rand.Next(3)==0)projectile.timeLeft += 1;
				if(Main.rand.Next(6)==0)projectile.penetrate *= 2;
			}
            if(projectile.thrown && projectile.damage > 1 && Main.rand.Next(9)==0)projectile.damage = (int)(projectile.damage*0.999f);
			
			if(player.GetModPlayer<MyPlayer>().magmaBonus && projectile.aiStyle == 99 && Main.rand.Next(45)==0) {
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X*0.05f, projectile.velocity.Y*0.05f, mod.ProjectileType("MagmaAura"), projectile.damage/2, projectile.knockBack/2f, projectile.owner, 0f, 0f);
			}
		}
		
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
			Player player = Main.player[projectile.owner];
			if(player.GetModPlayer<MyPlayer>().paperWorks && (projectile.aiStyle == 16 || projectile.type == mod.ProjectileType("CoalRocket") || projectile.type == mod.ProjectileType("FishyumRocket")) && projectile.ranged) {
				target.AddBuff(BuffID.OnFire, 300);
			}
			if(player.GetModPlayer<MyPlayer>().everfrostStone && projectile.thrown == true) {
				if (Main.rand.Next(7) == 0)
				{
					target.AddBuff(44, 350); //10 less than magmastone
				}
				else if (Main.rand.Next(3) == 0)
				{
					target.AddBuff(44, 110); //10 less than magmastone
				}
				else
				{
					target.AddBuff(44, 55); //5 less than magmastone
				}
			}
			if(player.GetModPlayer<MyPlayer>().spiderNesting && (projectile.minion == true || player.inventory[player.selectedItem].summon == true) && Main.rand.Next(3)==0 && projectile.type != mod.ProjectileType("VenomSpider")) {
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X*0.333f+Main.rand.NextFloat(-1f,1f), projectile.velocity.Y*0.333f+Main.rand.NextFloat(-1f,1f), mod.ProjectileType("VenomSpider"), projectile.damage/2, projectile.knockBack/2f, projectile.owner, 0f, 0f);
			}
		}
		
		public override void Kill(Projectile projectile, int timeLeft)
        {
			Player player = Main.player[projectile.owner];
			if(player.GetModPlayer<MyPlayer>().firecrackers && projectile.friendly && player.inventory[player.selectedItem].consumable == true && projectile.thrown && projectile.type != mod.ProjectileType("Firecrackers")) {
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("Firecrackers"), projectile.damage/2, projectile.knockBack/2f, projectile.owner, 0f, 0f);
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14, 0.75f, 0f);
			}
		}
    }
}