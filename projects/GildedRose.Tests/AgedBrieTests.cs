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

        [Test]
        public void QualityIncreasesEachDay()
        {
            const int initialSellIn = 10;
            const int initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality + 1);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityIncreasesTwiceAsFastAfterTheSellByDateHasPassed()
        {
            const int initialSellIn = -1;
            const int initialQuality = 10;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality + 2);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityIsNeverMoreThan50()
        {
            const int initialSellIn = 10;
            const int initialQuality = 50;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, 50);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityIsNeverMoreThan50EvenAfterTheSellByDateHasPassed()
        {
            const int initialSellIn = -1;
            const int initialQuality = 50;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, 50);
            AssertThatItemsAreEqual(item, expectedItem);
        }
    }
}
