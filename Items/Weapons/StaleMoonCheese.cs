using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWeaponaria.Items.Weapons
{
    public class StaleMoonCheese : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stale Moon Cheese");
            Tooltip.SetDefault("Old cheese from the moon\nReduces max health to 250\nIncreases health regen massively\nDecreases player damage dealt by 25%\nPermanent Broken armor effect\nPotion sickness time is doubled");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 10000000;
            item.rare = ItemRarityID.Red;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 = 250;
            player.lifeRegen += 40;
            player.potionDelay = 69;
            player.brokenArmor = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "AncientRingOfMara");
            recipe.AddIngredient(mod, "MarianFragment");
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
