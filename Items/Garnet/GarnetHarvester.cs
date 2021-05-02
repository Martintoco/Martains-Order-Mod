using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Garnet
{
    public class GarnetHarvester : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garnet Harvester");
            Tooltip.SetDefault("Inflicts Garnet Wither to enemies");
        }

        public override void SetDefaults()
        {
            item.damage = 29;
            item.melee = true;
            item.crit = 8;
            item.width = 52;
            item.height = 50;
            item.scale = 1.5f;
            item.useTime = 12;
            item.useAnimation = 28;
            item.pick = 200;
            item.axe = 22;
            item.hammer = 80;
            item.tileBoost += 2;
            item.useStyle = 1;
            item.knockBack = 6f;
            item.value = 42500;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60, player.velocity.X * 0.25f + (float)(player.direction * 3), player.velocity.Y * 0.25f, 100, default(Color), 0.4f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 2f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GarnetBar"), 18);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            target.AddBuff(mod.BuffType("GarnetCurse"), 180);
        }
        public override void ModifyHitPvp(Player player, Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(mod.BuffType("GarnetCurse"), 180);
        }

    }
}