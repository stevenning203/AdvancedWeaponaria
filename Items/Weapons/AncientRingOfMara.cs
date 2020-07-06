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
    public class AncientRingOfMara : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Ring of Mara");
            Tooltip.SetDefault("Increases your max number of minions by 5\nIncreases maximum mana by 100");
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
            player.maxMinions += 5;
            player.statManaMax2 += 100;
        }
    }
}
