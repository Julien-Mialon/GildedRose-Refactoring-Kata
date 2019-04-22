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
        
        private void RunForItem(Item item)
        {
            GildedRose app = new GildedRose(new List<Item> {item});
            app.UpdateQuality();
        }
    }
}