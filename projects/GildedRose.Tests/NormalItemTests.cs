using System;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class NormalItemTests
    {
        [Test]
        public void QualityDecreasesEachDay()
        {
            var initialSellIn = 10;
            var initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality - 1);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityIsNeverNegative()
        {
            var initialSellIn = 10;
            var initialQuality = 0;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        [Test]
        public void QualityDecreasesTwiceAsFastOnceSellByDateHasPassed()
        {
            var initialSellIn = 0;
            var initialQuality = 20;
            var item = CreateItem(initialSellIn, initialQuality);

            UpdateQualityFor(item);

            var expectedItem = CreateItem(initialSellIn - 1, initialQuality - 2);
            AssertThatItemsAreEqual(item, expectedItem);
        }

        public Item CreateItem(int initialSellIn, int initialQuality)
        {
            return new Item { Name = "Normal Item", SellIn = initialSellIn, Quality = initialQuality };
        }

        public void AssertThatItemsAreEqual(Item actualItem, Item expectedItem)
        {
            Assert.That(actualItem.SellIn,
                Is.EqualTo(expectedItem.SellIn),
                String.Format("SellIn for {0}", expectedItem.Name));

            Assert.That(actualItem.Quality,
                Is.EqualTo(expectedItem.Quality),
                String.Format("Quality for {0}", expectedItem.Name));
        }

        public void UpdateQualityFor(Item item)
        {
            new Program(item).UpdateQuality();
        }
    }
}
