using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class SulfurasTests : GildedRoseTests
    {
        public override Item CreateItem(int sellIn, int quality)
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality };
        }

        [TestCase(20, 20, 10, 10, "quality and sell in always stay the same")]
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
