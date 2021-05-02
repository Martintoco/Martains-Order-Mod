using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Mounts
{
    public class PrinceSlimeMount : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tentacled Slime");
            Description.SetDefault("BOING 2:tentacle boogaloo");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(mod.MountType("PrinceSlimeMount"), player);
            player.buffTime[buffIndex] = 10;
            player.armorEffectDrawShadow = true;
            player.gravDir = 1;
			player.maxFallSpeed += 20f;
			player.extraFall += 3;
			player.gravity += 0.5f;
			player.armorEffectDrawShadowSubtle = true;
            //if (player.velocity.Y >= 2f) player.velocity.Y *= 99.9f;

            if (player.wet)
            {
                player.wetSlime = 30;
                if (player.velocity.Y > 2f) player.velocity.Y *= 0.9f;
                player.velocity.Y -= 1f;
                if (player.velocity.Y < -7f) player.velocity.Y = -7f;
                if (player.controlJump) player.velocity.Y = -20f;
            }
            var checkDamagePlayer = player.getRect();
            checkDamagePlayer.Offset(0, player.height - 2);
            checkDamagePlayer.Inflate(12, 6);

            for (var i = 0; i < 200; i++)
            {
                var npc = Main.npc[i];
                if (npc.active && !npc.dontTakeDamage && !npc.friendly && npc.immune[player.whoAmI] == 0)
                {
                    var checkDamageNPC = npc.getRect();
                    if (checkDamagePlayer.Intersects(checkDamageNPC) && (npc.noTileCollide || Collision.CanHit(player.Center,/* player.width, player.height,*/ 0, 0, npc.position, npc.width, npc.height)))
                    {
                        var damage = (60 * player.minionDamage * player.allDamage);
                        var knockBack = 5f;
                        var direction = player.direction;
                        if (player.velocity.X > 0f)
                        {
                            direction = -1;
                        }
                        if (player.velocity.X < 0f)
                        {
                            direction = 1;
                        }
                        if (player.whoAmI == Main.myPlayer)
                        {
                            npc.StrikeNPC((int)damage, knockBack, direction, false, false, false);
                            if (Main.netMode != 0)
                                NetMessage.SendData(28, -1, -1, NetworkText.FromLiteral(""), npc.whoAmI, (float)1, knockBack, (float)direction, (int)damage);
                        }
                        npc.immune[player.whoAmI] = 10;
                        player.velocity.Y = -10f;
						if(player.controlJump)player.velocity.Y = -30f;
						//player.fallStart2 += 20;
						//player.gravity = 0f;
						player.fallStart = (int)(player.position.Y / 16f);
                        player.immune = true;
                        break;
                    }
                }
            }
        }
    }
}