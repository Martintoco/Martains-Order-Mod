using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.Items.Extra
{
    public class SeptimusBlaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Septimus' Blaster");
            Tooltip.SetDefault("Big laser boi"
            + "\nShoots  l a s e r s");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LaserMachinegun);
            item.damage = 419;
            item.crit = 29;
            item.magic = true;
            item.mana -= 2;
            item.width = 58;
            item.height = 36;
            item.useTime = 5;
            item.useAnimation = 5;
            item.value = 1000000;
            item.rare = 11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SeptimusBlaster");
            item.glowMask = -1;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, 4);
        }
    }
}
