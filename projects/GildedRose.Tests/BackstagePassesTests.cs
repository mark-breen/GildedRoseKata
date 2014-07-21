using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class BackstagePassesTests : GildedRoseTests
    {
        public override Item CreateItem(int sellIn, int quality)
        {
            return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
        }

        [Test]
        public void QualityIncreasesNormallyMoreThanTenDaysBeforeConcert()
        {
            const int initialSellIn = 11;
            const int initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality + 1);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityIncreasesTwiceAsFastTenDaysBeforeConcert()
        {
            const int initialSellIn = 10;
            const int initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality + 2);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityIncreasesTwiceAsFastMoreThanFiveDaysBeforeConcert()
        {
            const int initialSellIn = 6;
            const int initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality + 2);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityIncreasesThriceAsFastFiveDaysBeforeConcert()
        {
            const int initialSellIn = 5;
            const int initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality + 3);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityDropsToZeroAfterConcert()
        {
            const int initialSellIn = 0;
            const int initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, 0);
            AssertThatItemsAreEqual(item, expectedItem);
        }
    }
}
