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

        public static void IncreaseQualityBy(this Item item, int count)
        {
            item.Quality += count;
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }

        public static void DecreaseQualityBy(this Item item, int count)
        {
            item.Quality -= count;
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}