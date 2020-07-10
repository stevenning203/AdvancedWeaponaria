using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWeaponaria.Items.Weapons
{
    public class Star74 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star74");
            Tooltip.SetDefault("Not an AK");
        }

        public override void SetDefaults()
        {
            item.damage = 800;
            item.ranged = true;
            item.width = 40;
            item.height = 80;
            item.maxStack = 1;
            item.useTime = 3;
            item.useAnimation = 3;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 3f;
            item.value = 12000000;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item40;
            item.noMelee = true;
            item.useAmmo = AmmoID.Bullet;
            item.shootSpeed = 100f;
            item.autoReuse = true;
            item.shoot = ProjectileID.SniperBullet;
            item.crit = 50;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-30, 1);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Megashark);
            recipe.AddIngredient(mod, "ZenithiteBar", 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}