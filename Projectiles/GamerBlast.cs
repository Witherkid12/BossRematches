using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace BossRematches.Projectiles
{
    public class GamerBlast : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Magic;
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.knockBack = 5;
			Projectile.friendly = true;
			Projectile.maxPenetrate = 5;
			Projectile.penetrate = 5;
			Projectile.timeLeft = 360;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 0;
			DrawOffsetX = -15;
		}

		public override void AI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
			Projectile.spriteDirection = Projectile.direction;
			Projectile.velocity.X = Projectile.velocity.X * Main.rand.NextFloat(0.95f, 1.05f); // Randomises X velocity a bit every tick. did this cos it's funny, probably
			switch (Projectile.velocity.Y)
			{
				case < 0.1f:                   // If velocity is not already quite downwards, make it more downwards
					Projectile.velocity.Y = Projectile.velocity.Y + 0.15f;
					break;
				case < 0.5f and > 0.1f:
					Projectile.velocity.Y = Projectile.velocity.Y + 0.15f;
					Projectile.velocity.Y = Projectile.velocity.Y * 1.15f;
					break;
				case < 2.7f and > 0.5f:// If velocity is already quite downwards, accelerates.
					Projectile.velocity.Y = Projectile.velocity.Y * 1.15f;
					break;
				case > 2.7f:
					Projectile.velocity.Y = Projectile.velocity.Y * 1.06f;
					break;

			}
		}

		public override Color? GetAlpha(Color lightColor)  //Purple light off the projectile
		{
			return new Color(190, 30, 255, 180);
		}
	}
}
