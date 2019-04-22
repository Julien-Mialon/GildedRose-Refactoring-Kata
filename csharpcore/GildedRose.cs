﻿using System.Collections.Generic;

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
                if (item.IsAgedBrie() || item.IsBackstagePasses())
                {
                    item.IncreaseQualityIfNotMax();

                    if (item.IsBackstagePasses())
                    {
                        if (item.SellIn < 11)
                        {
                            item.IncreaseQualityIfNotMax();
                        }

                        if (item.SellIn < 6)
                        {
                            item.IncreaseQualityIfNotMax();
                        }
                    }
                }
                else
                {
                    if (item.Quality > 0)
                    {
                        if (!item.IsLegendary())
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }

                if (!item.IsLegendary())
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.IsExpired())
                {
                    if (!item.IsAgedBrie())
                    {
                        if (!item.IsBackstagePasses())
                        {
                            if (item.Quality > 0)
                            {
                                if (!item.IsLegendary())
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        item.IncreaseQualityIfNotMax();
                    }
                }
            }
        }
    }
}
