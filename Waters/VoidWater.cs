using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Waters
{
    public class VoidWater : ModWaterStyle
    {
        public override bool ChooseWaterStyle()
            => Main.bgStyle == mod.GetSurfaceBgStyleSlot("VoidSurfaceBgStyle");

        public override int ChooseWaterfallStyle()
            => mod.GetWaterfallStyleSlot("VoidWaterfall");

        public override int GetSplashDust()
            => mod.DustType("VoidWaterSplash");

        public override int GetDropletGore()
            => mod.GetGoreSlot("Gores/VoidWaterDroplet");

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 0.5f;
            g = 0.5f;
            b = 0.5f;
        }

        public override Color BiomeHairColor()
            => Color.Black;
    }
}