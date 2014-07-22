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
            AssertThatItemsAreEqual(actualItem, expectedItem, "");
        }


        public void AssertThatItemsAreEqual(Item actualItem, Item expectedItem, string message)
        {
            message = message.ToUpper();
            Assert.That(actualItem.SellIn,
                Is.EqualTo(expectedItem.SellIn),
                String.Format("\n{0}\nSellIn for {1}", message, expectedItem.Name));

            Assert.That(actualItem.Quality,
                Is.EqualTo(expectedItem.Quality),
                String.Format("\n{0}\nQuality for {1}", message, expectedItem.Name));
        }
    }
}
