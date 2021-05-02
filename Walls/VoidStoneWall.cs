using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Walls
{
    public class VoidStoneWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            dustType = 109;
            drop = mod.ItemType("VoidStoneWall");
            AddMapEntry(new Color(7, 7, 7));
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 2 : 5;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = -5f;
            g = -5f;
            b = -5f;
        }
    }
}