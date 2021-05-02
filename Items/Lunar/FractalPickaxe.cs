using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Lunar
{
    public class FractalPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fractal Pickaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 80;
            item.melee = true;
            item.crit = 4;
            item.width = 36;
            item.height = 36;
            item.scale = 1f;
            item.useTime = 6;
            item.useAnimation = 12;
            item.pick = 225;
			item.tileBoost += 4;
            item.useStyle = 1;
            item.knockBack = 5.5f;
            item.value = 150000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
		
		public override Color? GetAlpha(Color lightColor) { return new Color(255, 255, 255, 255);}
		
    }
	
	public class GalaxyPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Pickaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 80;
            item.melee = true;
            item.crit = 4;
            item.width = 36;
            item.height = 36;
            item.scale = 1f;
            item.useTime = 6;
            item.useAnimation = 12;
            item.pick = 225;
			item.tileBoost += 4;
            item.useStyle = 1;
            item.knockBack = 5.5f;
            item.value = 150000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
		
		public override Color? GetAlpha(Color lightColor) { return new Color(255, 255, 255, 255);}
		
    }
}