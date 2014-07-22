using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class AgedBrieTests : GildedRoseTests
    {
        public override Item CreateItem(int sellIn, int quality)
        {
            return new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
        }

        [TestCase(20, 21, 10, 9, "quality increases each day")]
        [TestCase(10, 12, -1, -2, "quality increases twice as fast after the sell by date has passed")]
        [TestCase(50, 50, 10, 9, "quality is never more than 50")]
        [TestCase(50, 50, -1, -2, "quality is never more than 50 even after the sell by date has passed")]
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
