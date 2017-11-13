using System.Collections.Generic;
using GildedRose.App;
using GildedRose.Console;
using NUnit.Framework;
using TestStack.BDDfy;
// ReSharper disable InconsistentNaming

namespace GildedRose.Tests.ApplicationTests
{

    [Story]
    public class StandardItem_SellInAndQualityReduced
    {
        private List<Item> _items;
        private ApprovalTestsInventoryServiceClient _approvalTestsInventoryServiceClient;

        private string _name;
        private int _originalSellIn;
        private int _originalQuality;

        private int _expectedSellIn;
        private int _expectedQuality;
        private InventoryItem _inventoryItem;

        [Given]
        public void GivenSomeStandardItem()
        {
            _name = "SomeStandardItem";
            _originalSellIn = 10;
            _originalQuality = 5;

            _expectedSellIn = 9;
            _expectedQuality = 4;
        }

        [When]
        public void WhenTheItemIsUpdated()
        {
            var sut = new InventoryService();
            _inventoryItem = sut.UpdateItem(_name, _originalSellIn, _originalQuality);
        }

        [Then]
        public void ThenTheNameIsUnchanged()
        {
            Assert.That(_inventoryItem.Name, Is.EqualTo(_name));
        }

        [AndThen]
        public void AndThenTheSellInIsAsExpected()
        {
            Assert.That(_inventoryItem.SellIn, Is.EqualTo(_expectedSellIn));
        }

        [AndThen]
        public void AndThenTheQualityIsAsExpected()
        {
            Assert.That(_inventoryItem.Quality, Is.EqualTo(_expectedQuality));
        }

        [Test]
        public void RunTests()
        {
            this.BDDfy<InitialBenchmark>();
        }
    }
}