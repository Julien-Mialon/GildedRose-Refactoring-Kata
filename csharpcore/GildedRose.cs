using System;
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
                    UpdateQualityForAgedBrie(item);
                }
                else if (item.IsBackstagePasses())
                {
                    UpdateQualityForBackstagePasses(item);
                }
                else if (item.IsConjured())
                {
                    UpdateQualityForConjuredItem(item);
                }
                else
                {
                    UpdateQualityForNormalItem(item);
                }
            }

            void UpdateQualityForAgedBrie(Item item)
            {
                item.IncreaseQualityIfNotMax();
                if (item.IsExpired())
                {
                    item.IncreaseQualityIfNotMax();
                }
            }

            void UpdateQualityForBackstagePasses(Item item)
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

            void UpdateQualityForConjuredItem(Item item)
            {
                item.DecreaseQualityIfNotMin();
                item.DecreaseQualityIfNotMin();
                if (item.IsExpired())
                {
                    item.DecreaseQualityIfNotMin();
                    item.DecreaseQualityIfNotMin();
                }
            }

            void UpdateQualityForNormalItem(Item item)
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