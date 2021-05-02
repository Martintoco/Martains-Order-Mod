using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.NPCs
{
    public class IceBlock : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Block");
        }

        public override void SetDefaults()
        {
            npc.width = 42;
            npc.height = 52;
            npc.aiStyle = -1;
            npc.damage = 0;
            npc.defense = 24;
            npc.lifeMax = 100;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.Item27;
			npc.noGravity = false;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 0;
            //npc.loot = (ItemID.Gel, 1);
            npc.dontTakeDamage = false;
            //banner = npc.type;
            //bannerItem = mod.ItemType("ClamBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.ZoneSnow && MartainWorld.downedBritzz)
            {
                return 0.4f;
            }
            else
            {
                return 0f;
            }
        }

        public override void AI()
        {
			if(npc.ai[0] <= 0){
				npc.direction = 1;
				if(Main.rand.Next(2)==0)npc.direction = -1;
			}
			npc.ai[0]++;
			if(npc.wet && npc.velocity.Y > -1f)npc.velocity.Y -= 0.3f;
			if(npc.oldVelocity.Y > 4f && npc.velocity.Y == 0f){npc.life=0;npc.HitEffect(0,100);npc.NPCLoot();Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 27);}
        }
		
		public override void HitEffect(int hitDirection, double damage)
        {
			for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 67, 2 * hitDirection, -2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 1.05f;
            }
			if (npc.life <= 0)
            {
				for (int i = 0; i < 6; i++)
				{
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 68, 2 * hitDirection, -2f);
                Main.dust[dust].noGravity = false;
                Main.dust[dust].scale = 1.10f;
				}
			}
        }

        public override void NPCLoot()
        {
			if (Main.rand.Next(2) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.IceBlock, Main.rand.Next(2, 5));
            }
			Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
			switch (Main.rand.Next(0,19))
            {
                case 0:
                    Item.NewItem(npc.getRect(), ItemID.CopperCoin, Main.rand.Next(58, 78));
                    break;
                case 1:
                    Item.NewItem(npc.getRect(), ItemID.RottenChunk, Main.rand.Next(1, 4));
                    break;
                case 2:
                    Item.NewItem(npc.getRect(), ItemID.Vertebrae, Main.rand.Next(1, 4));
                    break;
                case 3:
                    Item.NewItem(npc.getRect(), ItemID.FossilOre, Main.rand.Next(4, 17));
                    break;
                case 4:
                    Item.NewItem(npc.getRect(), ItemID.SlushBlock, Main.rand.Next(8, 15));
                    break;
                case 5:
                    Item.NewItem(npc.getRect(), ItemID.ShiverthornSeeds, Main.rand.Next(1, 3));
                    break;
                case 6:
                    NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, NPCID.Zombie);
                    break;
				case 7:
                    NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, NPCID.UndeadMiner);
                    break;
				case 8:
                    Item.NewItem(npc.getRect(), ItemID.IceSkates, 1);
                    break;
				case 9:
                    Item.NewItem(npc.getRect(), ItemID.IceMirror, 1);
                    break;
				case 10:
                    Item.NewItem(npc.getRect(), ItemID.BlizzardinaBottle, 1);
                    break;
				case 11:
                    NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, NPCID.Harpy);
                    break;
				case 12:
                    NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, NPCID.Piranha);
                    break;
				case 13:
                    Item.NewItem(npc.getRect(), ItemID.SiltBlock, Main.rand.Next(7, 14));
                    break;
                case 14:
                    Item.NewItem(npc.getRect(), mod.ItemType("Geode"), Main.rand.Next(6, 13));
                    break;
				case 15:
                    Item.NewItem(npc.getRect(), mod.ItemType("EverfrostStone"), 1);
                    break;
				case 16:
                    Item.NewItem(npc.getRect(), mod.ItemType("TundraRose"), 1);
                    break;
                default:
                    Item.NewItem(npc.getRect(), ItemID.IceBlock, Main.rand.Next(5, 12));
                    break;
            }
        }
    }
}
