using Terraria.ModLoader;

namespace MartainsOrder.Items.Gamer.Vanities
{
    [AutoloadEquip(EquipType.Head)]
    public class GamerHeadphones : ModItem
    {
        public virtual void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
            //drawAltHair = false;
        }
        public virtual bool DrawHead()
        {
            return true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gamer Headset");
            Tooltip.SetDefault("Makes you feel like an Epic gamer");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = 5000;
            item.rare = 4;
            item.vanity = true;
        }

    }
}