using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace hololive.Items
{
    public class Carrot : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Example Item");
            // Tooltip.SetDefault("This is a simple modded item.");
        }

        public override void SetDefaults()
        {
            Item.width = 32;  // アイテムの幅
            Item.height = 32; // アイテムの高さ
            Item.value = Item.sellPrice(silver: 50); // アイテムの価格
            Item.rare = ItemRarityID.Blue; // アイテムの希少度
            Item.maxStack = 999; // スタック可能な最大数
            Item.healLife = 10;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.consumable = true;
        }
	}
}
