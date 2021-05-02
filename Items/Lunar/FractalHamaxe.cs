using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class FractalHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fractal Hamaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 60;
            item.melee = true;
            item.crit = 4;
            item.width = 56;
            item.height = 54;
            item.scale = 1f;
            item.useTime = 7;
            item.useAnimation = 28;
            item.axe = 30;
            item.hammer = 100;
			item.tileBoost += 4;
            item.useStyle = 1;
            item.knockBack = 7f;
            item.value = 150000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
		
		public override Color? GetAlpha(Color lightColor) { return new Color(255, 255, 255, 255);}
		
    }
	
	public class GalaxyHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Hamaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 60;
            item.melee = true;
            item.crit = 4;
            item.width = 54;
            item.height = 52;
            item.scale = 1f;
            item.useTime = 7;
            item.useAnimation = 28;
            item.axe = 30;
            item.hammer = 100;
			item.tileBoost += 4;
            item.useStyle = 1;
            item.knockBack = 7f;
            item.value = 150000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
		
		public override Color? GetAlpha(Color lightColor) { return new Color(255, 255, 255, 255);}
		
    }
}