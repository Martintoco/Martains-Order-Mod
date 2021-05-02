using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MartainsOrder.Mounts
{
	public class MCart : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.Minecart = true;
			MountID.Sets.Cart[mod.MountType("MCart")] = true; 
			mountData.MinecartDust = DelegateMethods.Minecart.Sparks; 

			mountData.spawnDust = 57;
			mountData.buff = ModContent.BuffType<Buffs.Mounts.MCart>();

			mountData.flightTimeMax = 0; // 0
			mountData.fallDamage = 0.5f; // 1f
			mountData.runSpeed = 25f; // 10f
			mountData.acceleration = 0.09f; // 0.04f
			mountData.jumpHeight = 15; // 15
			mountData.jumpSpeed = 5.45f; // 5.15
			mountData.blockExtraJumps = true; // true
			mountData.heightBoost = 12;

			mountData.playerYOffsets = new int[] { 9, 9, 9 };
			mountData.xOffset = 2;
			mountData.yOffset = 9;
			mountData.bodyFrame = 3;
			mountData.playerHeadOffset = 14;

			mountData.totalFrames = 3;
			mountData.standingFrameCount = 1;
			mountData.standingFrameDelay = 12;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 3;
			mountData.runningFrameDelay = 12;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 0;
			mountData.flyingFrameDelay = 0;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 0;
			mountData.inAirFrameDelay = 0;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 1;
			mountData.idleFrameDelay = 10;
			mountData.idleFrameStart = 0;
			mountData.idleFrameLoop = false;
			if (Main.netMode != NetmodeID.Server) {
				mountData.textureWidth = mountData.frontTexture.Width;
				mountData.textureHeight = mountData.frontTexture.Height;
			}
		}
		
	}
}
