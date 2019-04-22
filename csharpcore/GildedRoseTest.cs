using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void GivenAnItem_CheckThatNameDoesNotChange()
        {
            Item item = new Item
            {
                Name = "foo",
                SellIn = 100,
                Quality = 40
            };

            RunForItem(item);
            
            Assert.Equal("foo", item.Name);
        }

        [Fact]
        public void GivenNormalItem_CheckThatSellInDateDecrease()
        {
            Item item = new Item
            {
                Name = "foo",
                SellIn = 100,
                Quality = 40
            };

            RunForItem(item);
            
            Assert.Equal(99, item.SellIn);
        }
        
        [Fact]
        public void GivenNormalItem_CheckThatQualityDecreaseByOneBeforeExpire()
        {
            Item item = new Item
            {
                Name = "foo",
                SellIn = 100,
                Quality = 40
            };

            RunForItem(item);
            
            Assert.Equal(39, item.Quality);
        }
        
        [Fact]
        public void GivenNormalItem_CheckThatQualityDecreaseTwiceAsFastAfterExpire()
        {
            Item item = new Item
            {
                Name = "foo",
                SellIn = 0,
                Quality = 40
            };

            RunForItem(item);
            
            Assert.Equal(38, item.Quality);
        }
        
        [Fact]
        public void GivenNormalItem_CheckThatQualityCantBeLessThanZero()
        {
            Item item = new Item
            {
                Name = "foo",
                SellIn = 100,
                Quality = 0
            };

            RunForItem(item);
            
            Assert.Equal(0, item.Quality);
        }
        
        [Fact]
        public void GivenNormalItem_CheckThatSellInDateCanBeLessThanZero()
        {
            Item item = new Item
            {
                Name = "foo",
                SellIn = 0,
                Quality = 40
            };

            RunForItem(item);
            
            Assert.Equal(-1, item.SellIn);
        }

        [Fact]
        public void GivenAgedBrie_CheckThatQualityIncreaseByOneBeforeSellDate()
        {
            Item item = new Item
            {
                Name = "Aged Brie",
                SellIn = 10,
                Quality = 10
            };

            RunForItem(item);
            
            Assert.Equal(11, item.Quality);
        }
        
        [Fact]
        public void GivenAgedBrie_CheckThatQualityIncreaseByTwoAfterSellDate()
        {
            Item item = new Item
            {
                Name = "Aged Brie",
                SellIn = 0,
                Quality = 10
            };

            RunForItem(item);
            
            Assert.Equal(12, item.Quality);
        }
        
        [Fact]
        public void GivenAgedBrie_CheckThatQualityDoNotIncreaseAbove50()
        {
            Item item = new Item
            {
                Name = "Aged Brie",
                SellIn = 0,
                Quality = 50
            };

            RunForItem(item);
            
            Assert.Equal(50, item.Quality);
            
            item = new Item
            {
                Name = "Aged Brie",
                SellIn = 10,
                Quality = 50
            };

            RunForItem(item);
            
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void GivenLegendaryItem_CheckThatQualityNeverDecrease()
        {
            Item item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 10,
                Quality = 40
            };

            RunForItem(item);
            
            Assert.Equal(40, item.Quality);
            
            item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = -1,
                Quality = 40
            };

            RunForItem(item);
            
            Assert.Equal(40, item.Quality);
        }
        
        [Fact]
        public void GivenLegendaryItem_CheckThatSellInNeverDecrease()
        {
            Item item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 10,
                Quality = 40
            };

            RunForItem(item);
            
            Assert.Equal(10, item.SellIn);
            
            item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = -1,
                Quality = 40
            };

            RunForItem(item);
            
            Assert.Equal(-1, item.SellIn);
        }
        
        [Fact]
        public void GivenLegendaryItem_CheckThatQualityCanBeMoreThan50()
        {
            Item item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 10,
                Quality = 80
            };

            RunForItem(item);
            
            Assert.Equal(80, item.Quality);
        }
        
        private void RunForItem(Item item)
        {
            GildedRose app = new GildedRose(new List<Item> {item});
            app.UpdateQuality();
        }
    }
}