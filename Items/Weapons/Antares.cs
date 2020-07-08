using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWeaponaria.Items.Weapons
{
    public class Antares : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antares");
            Tooltip.SetDefault("Shine Bright!");
        }

        public override void SetDefaults()
        {
            item.damage = 300;
            item.ranged = true;
            item.width = 40;
            item.height = 80;
            item.maxStack = 1;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 10f;
            item.value = 12000000;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 10f;
            item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), ProjectileID.JestersArrow, 225, 5f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), ProjectileID.HolyArrow, 1095, 5f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), ProjectileID.BulletHighVelocity, 800, 2f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), ProjectileID.OrnamentFriendly, 225, 2f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), ProjectileID.BallofFire, 120, 2f, Main.myPlayer, 0f, 0f);
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 50);
            recipe.AddIngredient(mod, "ZenithiteBar", 15);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}