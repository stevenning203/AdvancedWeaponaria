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
    public class Pickstar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pickstar");
            Tooltip.SetDefault("Pickaxe made of stars... Somehow?");
        }
        public override void SetDefaults()
        {
            item.damage = 160;
            item.melee = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 2;
            item.useAnimation = 12;
            item.pick = 295;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2;
            item.value = 100000000;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 30);
            recipe.AddIngredient(mod, "ZenithiteBar", 12);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
