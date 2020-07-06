using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace MoreWeaponaria.Items.Materials
{
    public class PieceOfTheMoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Piece of the Moon... Or is it a star?");
            Tooltip.SetDefault("Summon Mara, the Star Lord");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.maxStack = 20;
            item.rare = ItemRarityID.Red;
            item.useAnimation = 45;
            item.useTime = 120;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
        }
        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position, 0);
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Mara"));
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("Mara"));
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddIngredient(ItemID.FallenStar, 50);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
