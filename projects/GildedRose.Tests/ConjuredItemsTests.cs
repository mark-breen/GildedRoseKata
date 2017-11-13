using GildedRose.App;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ConjuredItemsTests
    {
        [TestCase(10, 9, 10, 8)]
        [TestCase(1, 0, 10, 8)]
        [TestCase(0, -1, 10, 6)]
        [TestCase(-1, -2, 10, 6)]
        [TestCase(-10, -11, 10, 6)]
        [TestCase(10, 9, 3, 1)]
        [TestCase(1, 0, 3, 1)]
        [TestCase(0, -1, 3, 0)]
        [TestCase(-1, -2, 3, 0)]
        [TestCase(-10, -11, 3, 0)]
        [TestCase(10, 9, 1, 0)]
        [TestCase(1, 0, 1, 0)]
        [TestCase(0, -1, 1, 0)]
        [TestCase(-1, -2, 1, 0)]
        [TestCase(-10, -11, 1, 0)]
        [TestCase(10, 9, 0, 0)]
        [TestCase(1, 0, 0, 0)]
        [TestCase(0, -1, 0, 0)]
        [TestCase(-1, -2, 0, 0)]
        [TestCase(-10, -11, 0, 0)]
        public void WhenTheItemIsUpdated(int originalSellIn, int expectedSellIn, int originalQuality, int expectedQuality)
        {
            var sut = new InventoryService();

            var inventoryItem = sut.UpdateItem("Conjured Mana Cake", originalSellIn, originalQuality);

            Assert.That(inventoryItem.Name, Is.EqualTo("Conjured Mana Cake"));
            Assert.That(inventoryItem.SellIn, Is.EqualTo(expectedSellIn));
            Assert.That(inventoryItem.Quality, Is.EqualTo(expectedQuality));
        }
    }
}