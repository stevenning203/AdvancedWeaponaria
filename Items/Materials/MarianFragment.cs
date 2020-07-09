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
    public class MarianFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marian Fragment");
            Tooltip.SetDefault("A piece of the moon..\nDon't worry, this one doesn't spawn Mara.");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.maxStack = 5;
            item.rare = ItemRarityID.Red;
        }

    }
}
