using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class NormalItemTests : GildedRoseTests
    {
        public override Item CreateItem(int sellIn, int quality)
        {
            return new Item { Name = "Normal Item", SellIn = sellIn, Quality = quality };
        }

        [TestCase(20, 19, 10, 9, "quality decreases each day")]
        [TestCase(0, 0, 10, 9, "quality is never negative")]
        [TestCase(20, 18, 0, -1, "quality decreases twice as fast once the sell by date has passed")]
        [TestCase(1, 0, -1, -2, "quality doesn't become negative even after the sell by date has passed")]
        public void QualityIsUpdated(int initialQuality, int expectedQuality, int initialSellIn, int expectedSellIn, string message)
        {
            AssertThatQualityIsUpdated(initialQuality, expectedQuality, initialSellIn, expectedSellIn, message);
        }
    }
}
