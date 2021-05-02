using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Waters
{
    public class AstralWater : ModWaterStyle
    {
        public override bool ChooseWaterStyle()
            => Main.bgStyle == mod.GetSurfaceBgStyleSlot("AstralSurfaceBgStyle");

        public override int ChooseWaterfallStyle()
            => mod.GetWaterfallStyleSlot("AstralWaterfall");

        public override int GetSplashDust()
            => mod.DustType("AstralWaterSplash");

        public override int GetDropletGore()
            => mod.GetGoreSlot("Gores/AstralWaterDroplet");

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1.09f;
            g = 1f;
            b = 1.17f;
        }

        public override Color BiomeHairColor()
            => Color.Purple;
    }
}