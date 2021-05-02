using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Waters
{
    public class WoodsWater : ModWaterStyle
    {
        public override bool ChooseWaterStyle()
            => Main.bgStyle == mod.GetSurfaceBgStyleSlot("DeepWoodsBgStyle");

        public override int ChooseWaterfallStyle()
            => mod.GetWaterfallStyleSlot("WoodsWaterfall");

        public override int GetSplashDust()
            => mod.DustType("WoodsWaterSplash");

        public override int GetDropletGore()
            => mod.GetGoreSlot("Gores/WoodsWaterDroplet");

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 0.5f;
            g = 0.6f;
            b = 0.8f;
        }

        public override Color BiomeHairColor()
            => Color.Teal;
    }
}