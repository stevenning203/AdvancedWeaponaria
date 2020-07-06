using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace MoreWeaponaria.Items.NPCBOSS
{
    public class MaraProjectileOrb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ORB!");
        }
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.timeLeft = 2000;
            projectile.hostile = true;
            projectile.scale = 1f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.Yellow;
        }
        public override void AI()
        {
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation += 0.25f;
            if (projectile.rotation >= 6)
            {
                projectile.rotation = 0f;
            }
        }
    }
}
