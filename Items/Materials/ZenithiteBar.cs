using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWeaponaria.Items.Materials
{
    public class ZenithiteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zenithite Bar");
            Tooltip.SetDefault("A mysterious bar... looks oddly like the Zenith sword?");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.rare = ItemRarityID.Red;
            item.value = Item.buyPrice(gold: 25);
            item.maxStack = 999;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "Zenithite", 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
