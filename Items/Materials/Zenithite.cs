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
    public class Zenithite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zenithite");
            Tooltip.SetDefault("A mysterious ore... looks oddly like the Zenith sword?");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.rare = ItemRarityID.Red;
            item.value = Item.buyPrice(gold: 1);
            item.maxStack = 999;
        }
    }
}
