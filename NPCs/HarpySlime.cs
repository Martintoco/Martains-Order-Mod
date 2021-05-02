using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MartainsOrder.NPCs
{
    public class HarpySlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harpy Slime");
            Main.npcFrameCount[npc.type] = 2;
            aiType = NPCID.BlueSlime;
        }

        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 34;
            animationType = NPCID.BlueSlime;
            npc.aiStyle = NPCID.BlueSlime;
            npc.damage = 40;
            npc.defense = 5;
            npc.lifeMax = 125;
            npc.knockBackResist = 0.5f;
			npc.npcSlots = 1f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 525;
            //npc.loot = (ItemID.Gel, 1);
            npc.buffImmune[BuffID.Poisoned] = false;
            npc.buffImmune[BuffID.Confused] = false;
            banner = npc.type;
            bannerItem = mod.ItemType("HarpySlimeBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneSkyHeight)
            {
                return 1.1f;
            }
            else
            {
                return 0f;
            }
        }

        public override void AI()
        {
            npc.velocity = npc.velocity * (1f);
            npc.TargetClosest(true);
            Vector2 targetPosition = new Vector2 (Main.player[npc.target].position.X+Main.player[npc.target].width*0.5f, Main.player[npc.target].position.Y+Main.player[npc.target].height*0.5f);

            npc.velocity.X = npc.velocity.X * (1.000f);
            if (npc.velocity.Y < 0) npc.velocity.Y = npc.velocity.Y * (1.020f);
            if (npc.velocity.Y > 0) npc.velocity.Y = npc.velocity.Y * (0.890f);
			
			if(targetPosition.Y > (npc.position.Y - 100)) npc.velocity.Y += 0.1f;
        }
		
		public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int i = 0; i < 11; i++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 4, 2 * hitDirection, -2f);
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale = 1.25f;
					Main.dust[dust].color = Color.DarkBlue;
                }
            }
        }

        public override void NPCLoot()
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HarpySlime1"), 1.1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HarpySlime2"), 1.1f);
            }
            Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(2, 6));
            Item.NewItem(npc.getRect(), ItemID.Feather, Main.rand.Next(1, 4));
            if (Main.rand.Next(30) == 0 && Main.expertMode)
            {
                Item.NewItem(npc.getRect(), ItemID.SlimeStaff, 1);
            }
            if (Main.rand.Next(3) == 0 && Main.hardMode)
            {
                Item.NewItem(npc.getRect(), ItemID.SoulofFlight, Main.rand.Next(1, 3));
            }
        }
    }
}
