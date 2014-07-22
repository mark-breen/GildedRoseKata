using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    internal class BackstagePassesTests : GildedRoseTests
    {
        public override Item CreateItem(int sellIn, int quality)
        {
            return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
        }

        [TestCase(20, 21, 11, 10, "quality increases normally more than 10 days before the concert")]
        [TestCase(20, 22, 10, 9, "quality increases twice as fast 10 days before the concert")]
        [TestCase(20, 22, 6, 5, "quality increases twice as fast more than 5 days before the concert")]
        [TestCase(20, 23, 5, 4, "quality increases three times as fast 5 days before the concert")]
        [TestCase(20, 0, 0, -1, "quality drops to 0 after the concert")]
        public void QualityIsUpdated(int initialQuality, int expectedQuality,
            int initialSellIn, int expectedSellIn, string message)
        {
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(expectedSellIn, expectedQuality);
            AssertThatItemsAreEqual(item, expectedItem, message);
        }
    }
}
