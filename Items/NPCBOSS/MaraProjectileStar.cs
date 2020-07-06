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
    public class MaraProjectileStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star!");
        }
        public override void SetDefaults()
        {
            projectile.width = 50;
            projectile.height = 50;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 30;
            projectile.timeLeft = 600;
            projectile.hostile = true;
            projectile.scale = 1f;
            projectile.tileCollide = false;
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
            Lighting.AddLight(projectile.position, new Vector3(100, 0, 0));
            projectile.rotation += 3f;
        }
    }
}
