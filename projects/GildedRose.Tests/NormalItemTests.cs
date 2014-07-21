using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class NormalItemTests : GildedRoseTests
    {
        public override Item CreateItem(int initialSellIn, int initialQuality)
        {
            return new Item { Name = "Normal Item", SellIn = initialSellIn, Quality = initialQuality };
        }

        [Test]
        public void QualityDecreasesEachDay()
        {
            const int initialSellIn = 10;
            const int initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality - 1);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityIsNeverNegative()
        {
            const int initialSellIn = 10;
            const int initialQuality = 0;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, 0);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityDecreasesTwiceAsFastOnceSellByDateHasPassed()
        {
            const int initialSellIn = 0;
            const int initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality - 2);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityDoesNotBecomeNegativeEvenAfterTheSellByDateHasPassed()
        {
            const int initialSellIn = -1;
            const int initialQuality = 1;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, 0);
            AssertThatItemsAreEqual(item, expectedItem);
        }
    }
}
