using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MartainsOrder.Items.VanillaChanges;

namespace MartainsOrder.Items.VanillaChanges
{
    /*public class GlobalItemsVariables : GlobalItem
    {
        //public override bool InstancePerEntity => true;
        //public bool swingStabState = false;
        //public override bool CloneNewInstances => true;
    }*/
	public abstract class MartainRarityItem : ModItem
    {
		
	public int MRarity = 0;
    public Color? customNameColor = null;

    public override void ModifyTooltips(List<TooltipLine> list)
    {
        if (customNameColor != null)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = (Color)customNameColor;
                }
            }
            return;
        }
		
        if (item.modItem is MartainRarityItem MyModItem && MyModItem.MRarity != 0)
        {
            Color Rare;
            switch (MyModItem.MRarity)
            {
                default: Rare = Color.White; break;
				case 18: Rare = BaseColor.VoidRarity; break;
                case 19: Rare = BaseColor.NuclearRarity; break;
            }
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = Rare;
                }
            }
        }
	}
	}
	public static class BaseColor {
		public static Color VoidRarity => new Color(MartainWorld.voidCCD+37, MartainWorld.voidCCD+37, MartainWorld.voidCCD+37);
		public static Color NuclearRarity => new Color(MartainWorld.nuclearCCD+(MartainWorld.nuclearCCD-5), 255-(MartainWorld.nuclearCCD/8), MartainWorld.nuclearCCD);
	}
	
}