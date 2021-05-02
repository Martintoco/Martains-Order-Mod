using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Zinc
{
    public class ZincSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Scepter");
            Tooltip.SetDefault("Summons a Zinc Shield"
			+ "\nThere can only be one");
            //+ "\n(The summon has unlimited time, the seconds below are bugged)");

        }
        public override void SetDefaults()
        {
            //item.damage = 19;
            item.summon = true;
            item.mana = 15;
            item.width = 28;
            item.height = 28;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3f;
            item.value = 27000;
            item.rare = 2;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("ZincSummon");
            item.shootSpeed = 0f;
            //item.buffType = mod.BuffType("ZincSummon");
            //item.buffTime = 600;
            item.autoReuse = false;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			player.AddBuff(mod.BuffType("ZincSummon"), 600);
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  //this make so you can only spawn one of this projectile at the time,
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ZincBar"), 17);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}