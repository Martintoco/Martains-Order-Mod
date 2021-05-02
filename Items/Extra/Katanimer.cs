using Terraria;
using System;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MartainsOrder.Items.Extra
{
    public class Katanimer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Katanimer");
			Tooltip.SetDefault("katanita");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
			item.melee = true;
            item.crit = 5;
            item.useStyle = 1;
            item.width = 46;
            item.height = 46;
			item.scale = 2.7f;
            item.useAnimation = 22;
            item.useTime = 22;
            item.knockBack = 5f;
            item.rare = 11;
			item.autoReuse = true;
			item.useTurn = true;
            item.UseSound = SoundID.Item1;
            item.value = 90000;
        }
		public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 66, player.velocity.X * 0.25f + (float)(player.direction * 3), player.velocity.Y * 0.25f - 2.25f, 100, Color.LightBlue, 1.2f);
			Main.dust[dust].noGravity = true;
        }
		public virtual void UseItemHitbox(Player player, ref Rectangle hitbox, ref bool noHitbox)
		{
			hitbox.X = (int)(hitbox.X *2.75f);
			hitbox.Y = (int)(hitbox.Y *2.75f);
			hitbox.Width = (int)(hitbox.Width *2.75f);
			hitbox.Height = (int)(hitbox.Height *2.75f);
        }
		
    }
}
