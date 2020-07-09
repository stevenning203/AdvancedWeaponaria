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
    public class MaraTreasureBag : ModItem
    {
        public override int BossBagNPC => mod.NPCType("Mara");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("<right> to open");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Cyan;
            item.expert = true;
        }

        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(ItemID.PlatinumCoin, 10);
            player.QuickSpawnItem(ItemID.SuperHealingPotion, Main.rand.Next(5, 11));
            player.QuickSpawnItem(ItemID.SuperManaPotion, Main.rand.Next(5, 11));
            player.QuickSpawnItem(mod.ItemType("Zenithite"), Main.rand.Next(365, 1000));
            player.QuickSpawnItem(mod.ItemType("AncientRingOfMara"));
            player.QuickSpawnItem(ItemID.FallenStar, 100);
            player.QuickSpawnItem(mod.ItemType("MarianFragment"));
            int maraBossBagTest = Main.rand.Next(100);
            if (maraBossBagTest < 50)
            {
                player.QuickSpawnItem(mod.ItemType("Azimuth"));
            }
        }
    }
}
