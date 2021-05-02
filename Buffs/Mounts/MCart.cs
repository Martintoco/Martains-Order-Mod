using Terraria;
using Terraria.ModLoader;

namespace MartainsOrder.Buffs.Mounts
{
	public class MCart : ModBuff
	{ 
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Martinite Minecart");
			Description.SetDefault("shioom");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("MCart"), player);
			player.buffTime[buffIndex] = 10;
			
			if(player.ownedProjectileCounts[mod.ProjectileType("MCartAura")] < 1)Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("MCartAura"), 75, 3f, player.whoAmI);
		}
	}
}