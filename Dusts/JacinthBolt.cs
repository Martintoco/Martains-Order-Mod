using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace MartainsOrder.Dusts
{
    public class JacinthBolt : ModDust
    {
		public override void SetDefaults()
        {
            updateType = 57;
        }
		
       public static void UpdateDust(Dust dust)
	   {
		   if(!dust.noLight) {
		   float num3 = dust.scale * 0.6f;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			float num5 = num3;
			float num6 = num3;
			float num7 = num3;
				num5 *= 1.5f;
				num6 *= 1.1f;
				num7 *= 0.2f;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num3 * num5, num3 * num6, num3 * num7);
			}
			
			if (dust.customData != null && dust.customData is Player)
			{
				Player player = (Player)dust.customData;
				dust.position += player.position - player.oldPosition;
			}
			else if (dust.customData != null && dust.customData is Projectile)
			{
				Projectile projectile = (Projectile)dust.customData;
				if (projectile.active)
				{
					dust.position += projectile.position - projectile.oldPosition;
				}
			}
			
	   }
	   public Color GetAlpha(Color newColor)
	   {
		   return new Color(255, 255, 255, 0);
	   }
    }
	
	public class PeridotBolt : ModDust
    {
		public override void SetDefaults()
        {
            updateType = 57;
        }
		
       public static void UpdateDust(Dust dust)
	   {
		   if(!dust.noLight) {
		   float num3 = dust.scale * 0.6f;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			float num5 = num3;
			float num6 = num3;
			float num7 = num3;
				num5 *= 1.1f;
				num6 *= 1.5f;
				num7 *= 0.2f;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num3 * num5, num3 * num6, num3 * num7);
			}
			
			if (dust.customData != null && dust.customData is Player)
			{
				Player player = (Player)dust.customData;
				dust.position += player.position - player.oldPosition;
			}
			else if (dust.customData != null && dust.customData is Projectile)
			{
				Projectile projectile = (Projectile)dust.customData;
				if (projectile.active)
				{
					dust.position += projectile.position - projectile.oldPosition;
				}
			}
			
	   }
	   public Color GetAlpha(Color newColor)
	   {
		   return new Color(255, 255, 255, 0);
	   }
    }
	
	public class HematiteBolt : ModDust
    {
		public override void SetDefaults()
        {
            updateType = 57;
        }
		
       public static void UpdateDust(Dust dust)
	   {
		   if(!dust.noLight) {
		   float num3 = dust.scale * 0.6f;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			float num5 = num3;
			float num6 = num3;
			float num7 = num3;
				num5 *= 1.1f;
				num6 *= 1.1f;
				num7 *= 1.1f;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num3 * num5, num3 * num6, num3 * num7);
			}
			
			if (dust.customData != null && dust.customData is Player)
			{
				Player player = (Player)dust.customData;
				dust.position += player.position - player.oldPosition;
			}
			else if (dust.customData != null && dust.customData is Projectile)
			{
				Projectile projectile = (Projectile)dust.customData;
				if (projectile.active)
				{
					dust.position += projectile.position - projectile.oldPosition;
				}
			}
			
	   }
	   public Color GetAlpha(Color newColor)
	   {
		   return new Color(255, 255, 255, 0);
	   }
    }
	
	public class MalachiteBolt : ModDust
    {
		public override void SetDefaults()
        {
            updateType = 57;
        }
		
       public static void UpdateDust(Dust dust)
	   {
		   if(!dust.noLight) {
		   float num3 = dust.scale * 0.6f;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			float num5 = num3;
			float num6 = num3;
			float num7 = num3;
				num5 *= 0.2f;
				num6 *= 1.5f;
				num7 *= 1.2f;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num3 * num5, num3 * num6, num3 * num7);
			}
			
			if (dust.customData != null && dust.customData is Player)
			{
				Player player = (Player)dust.customData;
				dust.position += player.position - player.oldPosition;
			}
			else if (dust.customData != null && dust.customData is Projectile)
			{
				Projectile projectile = (Projectile)dust.customData;
				if (projectile.active)
				{
					dust.position += projectile.position - projectile.oldPosition;
				}
			}
			
	   }
	   public Color GetAlpha(Color newColor)
	   {
		   return new Color(255, 255, 255, 0);
	   }
    }
	
	public class RetroBolt : ModDust
    {
		public override void SetDefaults()
        {
            updateType = 57;
        }
		
       public static void UpdateDust(Dust dust)
	   {
		   if(!dust.noLight) {
		   float num3 = dust.scale * 0.6f;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			float num5 = num3;
			float num6 = num3;
			float num7 = num3;
				num5 *= 1.0f;
				num6 *= 1.0f;
				num7 *= 1.0f;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num3 * num5, num3 * num6, num3 * num7);
			}
			
			if (dust.customData != null && dust.customData is Player)
			{
				Player player = (Player)dust.customData;
				dust.position += player.position - player.oldPosition;
			}
			else if (dust.customData != null && dust.customData is Projectile)
			{
				Projectile projectile = (Projectile)dust.customData;
				if (projectile.active)
				{
					dust.position += projectile.position - projectile.oldPosition;
				}
			}
			
	   }
	   public Color GetAlpha(Color newColor)
	   {
		   return new Color(255, 255, 255, 0);
	   }
    }
}