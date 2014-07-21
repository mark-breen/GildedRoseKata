using System;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    abstract class GildedRoseTests
    {
        public abstract Item CreateItem(int sellIn, int quality);

        public void UpdateQualityFor(Item item)
        {
            new Program(item).UpdateQuality();
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
    }
}
