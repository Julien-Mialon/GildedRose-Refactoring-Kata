namespace csharpcore
{
    public enum ItemType
    {
        Normal,
        AgedBrie,
        Legendary,
        BackstagePasses,
        Conjured
    }

    public static class ItemTypeConstants
    {
        public const string AGED_BRIE_NAME = "Aged Brie";
        public const string LEGENDARY_SULFURAS_NAME = "Sulfuras, Hand of Ragnaros";
        public const string BACKSTAGE_PASSES_PREFIX = "Backstage passes";
        public const string CONJURED_PREFIX = "Conjured";
    }
    
    public static class ItemTypeExtensions
    {
        public static ItemType GetItemType(this string name)
        {
            if (name == ItemTypeConstants.AGED_BRIE_NAME)
            {
                return ItemType.AgedBrie;
            }

            if (name == ItemTypeConstants.LEGENDARY_SULFURAS_NAME)
            {
                return ItemType.Legendary;
            }

            if (name.StartsWith(ItemTypeConstants.BACKSTAGE_PASSES_PREFIX))
            {
                return ItemType.BackstagePasses;
            }

            if (name.StartsWith(ItemTypeConstants.CONJURED_PREFIX))
            {
                return ItemType.Conjured;
            }

            return ItemType.Normal;
        }

        public static bool IsNormalItem(this string name) => name.GetItemType() == ItemType.Normal;
        public static bool IsAgedBrieItem(this string name) => name.GetItemType() == ItemType.AgedBrie;
        public static bool IsLegendaryItem(this string name) => name.GetItemType() == ItemType.Legendary;
        public static bool IsBackstagePassesItem(this string name) => name.GetItemType() == ItemType.BackstagePasses;
        public static bool IsConjuredItem(this string name) => name.GetItemType() == ItemType.Conjured;
    }
}