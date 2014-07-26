using GildedRose.Console;
using GildedRose.Console.Items;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class NormalItemTests : GildedRoseTests
    {
        public override ImprovedItem CreateItem(int sellIn, int quality)
        {
            return new NormalItem(name: "Normal Item", sellIn: sellIn, quality: quality);
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

    [TestFixture]
    class ConjuredItemTests : GildedRoseTests
    {
        public override ImprovedItem CreateItem(int sellIn, int quality)
        {
            return new ConjuredItem(sellIn: sellIn, quality: quality);
        }

        [TestCase(20, 18, 10, 9, "quality decreases each day")]
        [TestCase(1, 0, 10, 9, "quality is never negative")]
        [TestCase(20, 16, -1, -2, "quality decreases twice as fast once the sell by date has passed")]
        [TestCase(1, 0, -1, -2, "quality doesn't become negative even after the sell by date has passed")]
        public void QualityIsUpdated(int initialQuality, int expectedQuality, int initialSellIn, int expectedSellIn, string message)
        {
            AssertThatQualityIsUpdated(initialQuality, expectedQuality, initialSellIn, expectedSellIn, message);
        }
    }

    [TestFixture]
    class AgedBrieTests : GildedRoseTests
    {
        public override ImprovedItem CreateItem(int sellIn, int quality)
        {
            return new AgedBrie(sellIn: sellIn, quality: quality);
        }

        [TestCase(20, 21, 10, 9, "quality increases each day")]
        [TestCase(10, 12, -1, -2, "quality increases twice as fast after the sell by date has passed")]
        [TestCase(50, 50, 10, 9, "quality is never more than 50")]
        [TestCase(50, 50, -1, -2, "quality is never more than 50 even after the sell by date has passed")]
        public void QualityIsUpdated(int initialQuality, int expectedQuality, int initialSellIn, int expectedSellIn, string message)
        {
            AssertThatQualityIsUpdated(initialQuality, expectedQuality, initialSellIn, expectedSellIn, message);
        }
    }

    [TestFixture]
    class SulfurasTests : GildedRoseTests
    {
        public override ImprovedItem CreateItem(int sellIn, int quality)
        {
            return new Sulfuras(sellIn: sellIn, quality: quality);
        }

        [TestCase(20, 20, 10, 10, "quality and sell in always stay the same")]
        public void QualityIsUpdated(int initialQuality, int expectedQuality, int initialSellIn, int expectedSellIn, string message)
        {
            AssertThatQualityIsUpdated(initialQuality, expectedQuality, initialSellIn, expectedSellIn, message);
        }
    }

    [TestFixture]
    class BackstagePassesTests : GildedRoseTests
    {
        public override ImprovedItem CreateItem(int sellIn, int quality)
        {
            return new BackstagePasses(sellIn: sellIn, quality: quality);
        }

        [TestCase(20, 21, 11, 10, "quality increases normally more than 10 days before the concert")]
        [TestCase(20, 22, 10, 9, "quality increases twice as fast 10 days before the concert")]
        [TestCase(20, 22, 6, 5, "quality increases twice as fast more than 5 days before the concert")]
        [TestCase(20, 23, 5, 4, "quality increases three times as fast 5 days before the concert")]
        [TestCase(20, 0, 0, -1, "quality drops to 0 after the concert")]
        public void QualityIsUpdated(int initialQuality, int expectedQuality, int initialSellIn, int expectedSellIn, string message)
        {
            AssertThatQualityIsUpdated(initialQuality, expectedQuality, initialSellIn, expectedSellIn, message);
        }
    }

    abstract class GildedRoseTests
    {
        public abstract ImprovedItem CreateItem(int sellIn, int quality);

        public void AssertThatQualityIsUpdated(int initialQuality, int expectedQuality,
            int initialSellIn, int expectedSellIn, string message)
        {
            var item = CreateItem(initialSellIn, initialQuality);

            Inventory.UpdateQualityFor(item);

            var expectedItem = CreateItem(expectedSellIn, expectedQuality);
            Assert.That(item, Is.EqualTo(expectedItem), message.ToUpper());
        }
    }
}
