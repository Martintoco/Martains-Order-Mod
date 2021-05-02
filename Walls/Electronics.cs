using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Walls
{
    public class Electronics : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            dustType = 226;
            drop = mod.ItemType("Electronics");
            AddMapEntry(new Color(150, 175, 100));
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 2 : 5;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.2f;
            g = 0.28f;
            b = 0.07f;
        }
    }
}