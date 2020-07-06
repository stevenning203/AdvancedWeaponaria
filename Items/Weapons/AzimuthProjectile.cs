using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace MoreWeaponaria.Items.Weapons
{
    public class AzimuthProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Azimuth Star");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.melee = true;
            projectile.arrow = true;
            projectile.damage = 1;
            projectile.tileCollide = false;
            projectile.timeLeft = 60;
        }
        
        public override void AI()
        {
            projectile.alpha = projectile.timeLeft / 300;
            projectile.velocity.Y += projectile.ai[0];
            Lighting.AddLight(projectile.position, new Vector3(125, 125, 25));
            projectile.velocity = (Main.MouseWorld - projectile.position) / 2;

            if (Main.rand.Next(50) == 25)
                for (int i = 0; i < 5; i++)
                {
                    Projectile.NewProjectile(new Vector2(projectile.position.X - 50 + i * 20, projectile.position.Y - 1000), new Vector2(Main.rand.Next(-5, 5), 25), ProjectileID.JestersArrow, 2500, 2f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile(new Vector2(projectile.position.X - 50 + i * 20, projectile.position.Y + 1000), new Vector2(Main.rand.Next(-5, 5), -25), ProjectileID.Starfury, 2500, 2f, Main.myPlayer, 0f, 0f);
                }
        }
        
    }
}