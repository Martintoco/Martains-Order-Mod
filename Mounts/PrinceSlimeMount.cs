using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MartainsOrder.Mounts
{
    public class PrinceSlimeMount : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.spawnDust = 99;
            mountData.buff = mod.BuffType("PrinceSlimeMount");
            mountData.heightBoost = 20;
            mountData.fallDamage = 0.05f;
            mountData.runSpeed = 10f;
            mountData.dashSpeed = 7f;
            mountData.flightTimeMax = 0;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 18;
            mountData.acceleration = 1.8f;
            mountData.jumpSpeed = 19.5f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 7;
            mountData.constantJump = true;
            int[] offset = new int[mountData.totalFrames];
            for (int i = 0; i < offset.Length; i++)
            {
                offset[i] = 20;
            }
            offset[1] -= 2;
            offset[3] += 2;
            mountData.playerYOffsets = offset;
            mountData.xOffset = 1;
            mountData.bodyFrame = 3;
            mountData.yOffset = 10;
            mountData.playerHeadOffset = 22;

            mountData.standingFrameCount = 3;
            mountData.standingFrameDelay = 10;
            mountData.standingFrameStart = 0;

            mountData.runningFrameCount = 5;
            mountData.runningFrameDelay = 25;
            mountData.runningFrameStart = 2;

            mountData.flyingFrameCount = 0;
            mountData.flyingFrameDelay = 0;
            mountData.flyingFrameStart = 0;

            mountData.inAirFrameCount = 2;
            mountData.inAirFrameDelay = 5;
            mountData.inAirFrameStart = 3;

            mountData.idleFrameCount = 3;
            mountData.idleFrameDelay = 15;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;

            mountData.swimFrameCount = 2;
            mountData.swimFrameDelay = 10;
            mountData.swimFrameStart = 3;

            if (Main.netMode != 2)
            {
                mountData.backTextureExtra = null;
                mountData.frontTexture = null;
                mountData.frontTextureExtra = null;

                mountData.textureWidth = mountData.backTexture.Width;
                mountData.textureHeight = mountData.backTexture.Height;
            }

        }
    }
}