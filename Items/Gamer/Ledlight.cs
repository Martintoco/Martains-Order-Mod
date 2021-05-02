using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MartainsOrder.Items.Gamer
{
    public class Ledlight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gamer LedLight");
            Tooltip.SetDefault("Lighten your surroundings with Style!"
            + "\nPeriodically changes colors");
        }

        public override void SetDefaults()
        {
            item.noMelee = true;
            item.width = 22;
            item.height = 22;
            item.channel = true;
            item.useTime = 1;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.knockBack = 0f;
            item.value = 25000;
            item.rare = 6;
            //item.UseSound = SoundID.Item91;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Nule");//Ledlight
            item.shootSpeed = 3.5f;
            Item.staff[item.type] = true;
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = (float)Math.PI / 8;
            int spreadRange = 10;
            Vector2 direction = new Vector2(speedX, speedY);
            direction = direction.RotatedBy(spread / 2f);
            for (int b = 0; b < spreadRange; b++)
            {
                direction = direction.RotatedBy(-spread / spreadRange);
                for (int l = 0; l < 1000; l++)
                {
                    if (Collision.CanHit(position, 0, 0, position + (l * direction), 0, 0))
                    {
						Color ledLight = Main.DiscoColor;
                        Lighting.AddLight(position + (l * direction), ledLight.R/220+0.05f, ledLight.G/220+0.05f, ledLight.B/220+0.05f);
                    }
                }
            }
            return false;
        }

        public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
        {
            wetTorch = true;
            glowstick = true;
        }

        public virtual bool? CanCutTiles()
        {
            return false;
        }

    }
}