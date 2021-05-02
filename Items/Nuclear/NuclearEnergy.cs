using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MartainsOrder.Items.VanillaChanges;

namespace MartainsOrder.Items.Nuclear
{
    public class NuclearEnergy : MartainRarityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nuclear Energy");
            Tooltip.SetDefault("'Corrisive powerful source, mostly unstable'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.maxStack = 999;
            item.value = 50000;
			
            item.rare = 7;
			MRarity = 19;
        }
		
        public override Color? GetAlpha(Color lightColor) { return new Color(250, 250, 250, 255);}
		
        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = BaseColor.NuclearRarity;
                }
            }
        }
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NuclearEnergy"), 1);
			//recipe.AddTile(mod.TileType("NuclearPlant"));
			recipe.SetResult(mod.ItemType("NuclearWaste"), 25);
			recipe.AddRecipe();
		}
    }
	
}