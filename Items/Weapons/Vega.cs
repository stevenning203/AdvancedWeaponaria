using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWeaponaria.Items.Weapons
{
    public class Vega : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vega");
            Tooltip.SetDefault("Effective at close range");
        }

        public override void SetDefaults()
        {
            item.damage = 800;
            item.ranged = true;
            item.width = 98;
            item.height = 30;
            item.maxStack = 1;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 3f;
            item.value = 12000000;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item36;
            item.noMelee = true;
            item.useAmmo = AmmoID.Bullet;
            item.shootSpeed = 25f;
            item.autoReuse = false;
            item.crit = 12;
            item.shoot = ProjectileID.WoodenArrowFriendly;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-30, 1);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 75; i++)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY + Main.rand.Next(-15, 16)), ProjectileID.BulletHighVelocity, 500, 3f, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shotgun);
            recipe.AddIngredient(mod, "ZenithiteBar", 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}