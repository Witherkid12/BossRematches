using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace BossRematches.Projectiles
{
    public class UltraBlast : ModProjectile
    {
        int brightnessAlpha = 0; //Used later in GetAlpha
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.knockBack = 9;
            Projectile.friendly = true;
            Projectile.maxPenetrate = -1;      //Infinite penetration
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180;         //Projectile is killed after 3 seconds (180 frames)
            Projectile.tileCollide = false;    //Doesn't die when touching blocks
            DrawOffsetX = -12;
            Projectile.alpha = 255; //Spawns invisible
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);  //Rotates towards velocity, adds 90 degrees cos upwards sprite
            Lighting.AddLight(Projectile.Center, 1f, 0f, 1f);      //Adds magenta light to the projectile

            if (Main.rand.NextBool(2)) // only spawn 50% of the time
            {
                int choice = Main.rand.Next(3); // choose a random number: 0, 1, or 2
                if (choice == 0) // use that number to select dustID: 15, 57, or 58
                {
                    choice = 15;
                }
                else if (choice == 1)
                {
                    choice = 57;
                }
                else
                {
                    choice = 58;
                }
                // Spawn the dust
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, choice, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);

            }

        }

        public override Color? GetAlpha(Color lightColor)
        {
            if (Projectile.timeLeft > 165)
            {
                brightnessAlpha += 15;             //Increases opacity for 13 frames, lets me fade in. 
            }
            else if (Projectile.timeLeft <= 15)
            {
                brightnessAlpha -= 15;            //Decreases opacity for the last 13 frames of its lifetime, fades out.
            }
            return new Color(brightnessAlpha, 0, brightnessAlpha, brightnessAlpha); //Magenta light
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 3; //Gives enemies 3 i-frames instead of default 10
        }





    }
}

