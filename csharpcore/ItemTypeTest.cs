using Xunit;

namespace csharpcore
{
    public class ItemTypeTest
    {
        [Theory]
        [InlineData("foo", ItemType.Normal)]
        [InlineData("Aged Brie", ItemType.AgedBrie)]
        [InlineData("Sulfuras, Hand of Ragnaros", ItemType.Legendary)]
        [InlineData("Backstage passes 1", ItemType.BackstagePasses)]
        [InlineData("Backstage passes 2", ItemType.BackstagePasses)]
        [InlineData("Conjured item 1", ItemType.Conjured)]
        [InlineData("Conjured item 2", ItemType.Conjured)]
        public void GivenAName_CheckThatCorrectTypeIsFound(string name, ItemType expectedType)
        {
            Assert.Equal(name.GetItemType(), expectedType);
        }
    }
}