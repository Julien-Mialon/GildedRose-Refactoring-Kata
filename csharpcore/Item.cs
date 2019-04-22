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

        public static void IncreaseQualityIfNotMax(this Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        public static void DecreaseQualityIfNotMin(this Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}
