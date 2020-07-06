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
    public class Azimuth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Azimuth");
            Tooltip.SetDefault("Sword of Mara.. Antisword of Zenith");
        }
        public override void SetDefaults()
        {
            item.damage = 75;
            item.melee = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 10;
            item.value = 100000000;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Item, player.position, 9);
            Projectile.NewProjectile(player.Center, new Vector2(10f, 0), mod.ProjectileType("AzimuthProjectile"), 0, 5f);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 50);
            recipe.AddIngredient(mod, "ZenithiteBar", 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
