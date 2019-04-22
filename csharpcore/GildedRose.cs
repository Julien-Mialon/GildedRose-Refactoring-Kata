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
        }

        private static void UpdateQualityForAgedBrie(Item item)
        {
            if (item.IsExpired())
            {
                item.IncreaseQualityBy(2);
            }
            else
            {
                item.IncreaseQualityBy(1);
            }
        }

        private static void UpdateQualityForBackstagePasses(Item item)
        {
            if (item.IsExpired())
            {
                item.Quality = 0;
            }
            else if (item.SellIn < 5)
            {
                item.IncreaseQualityBy(3);
            }
            else if (item.SellIn < 10)
            {
                item.IncreaseQualityBy(2);
            }
            else
            {
                item.IncreaseQualityBy(1);
            }
        }

        private static void UpdateQualityForConjuredItem(Item item)
        {
            if (item.IsExpired())
            {
                item.DecreaseQualityBy(4);
            }
            else
            {
                item.DecreaseQualityBy(2);
            }
        }

        private static void UpdateQualityForNormalItem(Item item)
        {
            if (item.IsExpired())
            {
                item.DecreaseQualityBy(2);
            }
            else
            {
                item.DecreaseQualityBy(1);
            }
        }
    }
}