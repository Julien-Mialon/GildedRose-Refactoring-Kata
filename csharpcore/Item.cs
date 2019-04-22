namespace csharpcore
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }

    public static class ItemExtensions
    {
        public static bool IsExpired(this Item item)
        {
            return item.SellIn < 0;
        }

        public static bool IsNotMaxQuality(this Item item)
        {
            return item.Quality < 50;
        }

        public static void IncreaseQualityIfNotMax(this Item item)
        {
            if (item.IsNotMaxQuality())
            {
                item.Quality++;
            }
        }
    }
}
