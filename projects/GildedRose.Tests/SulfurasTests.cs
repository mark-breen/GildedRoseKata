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

        [Test]
        public void QualityAndSellInAlwaysStayTheSame()
        {
            const int initialSellIn = 10;
            const int initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn, initialQuality);
            AssertThatItemsAreEqual(item, expectedItem);
        }
    }
}
