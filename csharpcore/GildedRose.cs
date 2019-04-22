using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                if (item.IsLegendary())
                {
                    continue;
                }

                
                item.SellIn--;
                
                if (item.IsAgedBrie())
                {
                    item.IncreaseQualityIfNotMax();
                    if (item.IsExpired())
                    {
                        item.IncreaseQualityIfNotMax();
                    }
                }
                else if (item.IsBackstagePasses())
                {
                    if (item.IsExpired())
                    {
                        item.Quality = 0;
                    }
                    else
                    {
                        item.IncreaseQualityIfNotMax();

                        if (item.SellIn < 10)
                        {
                            item.IncreaseQualityIfNotMax();
                        }

                        if (item.SellIn < 5)
                        {
                            item.IncreaseQualityIfNotMax();
                        }
                    }
                }
                else
                {
                    item.DecreaseQualityIfNotMin();
                    if (item.IsExpired())
                    {
                        item.DecreaseQualityIfNotMin();
                    }
                }
            }
        }
    }
}