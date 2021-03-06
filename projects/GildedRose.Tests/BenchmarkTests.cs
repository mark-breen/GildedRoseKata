﻿using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using GildedRose.App;
using GildedRose.Console;
using NUnit.Framework;
using TestStack.BDDfy;
// ReSharper disable InconsistentNaming

namespace GildedRose.Tests
{
    [Story]
    public class InitialBenchmark
    {
        private List<Item> _items;
        private ApprovalTestsInventoryServiceClient _approvalTestsInventoryServiceClient;

        [Given]
        public void GivenTheOriginalInventoryData()
        {
            // NOTE: I've removed conjured mana cake, as this is the new feature
            _items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                }
            };
        }

        [When]
        public void WhenTheInventoryIsUpdated()
        {
            _approvalTestsInventoryServiceClient = new ApprovalTestsInventoryServiceClient();

            var sut = new Program(_items, new InventoryService());

            sut.UpdateQuality(_items, _approvalTestsInventoryServiceClient);
        }

        [Then]
        public void ThenTheUpdateIsAsExpected()
        {
            Approvals.Verify(_approvalTestsInventoryServiceClient.GetResult());
        }

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void RunTests()
        {
            this.BDDfy<InitialBenchmark>();
        }
    }

    [Story]
    public class StandardItem_SellInAndQualityReduced
    {
        private List<Item> _items;
        private ApprovalTestsInventoryServiceClient _approvalTestsInventoryServiceClient;

        [Given]
        public void GivenSomeStandardItem()
        {
            _items = new List<Item>
            {
                new Item { Name = "SomeStandardItem", SellIn = 10, Quality = 5 }
            };
        }

        [When]
        public void WhenTheInventoryIsUpdated()
        {
            _approvalTestsInventoryServiceClient = new ApprovalTestsInventoryServiceClient();

            var sut = new Program(_items, new InventoryService());

            sut.UpdateQuality(_items, _approvalTestsInventoryServiceClient);
        }

        [Then]
        public void ThenTheUpdateIsAsExpected()
        {
            Approvals.Verify(_approvalTestsInventoryServiceClient.GetResult());
        }

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void RunTests()
        {
            this.BDDfy<InitialBenchmark>();
        }
    }

    [Story]
    public class StandardItem_QualityReducesTwiceAsFastAfterTheSellByDatae
    {
        private List<Item> _items;
        private ApprovalTestsInventoryServiceClient _approvalTestsInventoryServiceClient;

        [Given]
        public void GivenSomeStandardItem()
        {
            _items = new List<Item>
            {
                new Item { Name = "SomeStandardItem", SellIn = 0, Quality = 4 }
            };
        }

        [When]
        public void WhenTheInventoryIsUpdated()
        {
            _approvalTestsInventoryServiceClient = new ApprovalTestsInventoryServiceClient();

            var sut = new Program(_items, new InventoryService());

            sut.UpdateQuality(_items, _approvalTestsInventoryServiceClient);
        }

        [Then]
        public void ThenTheUpdateIsAsExpected()
        {
            Approvals.Verify(_approvalTestsInventoryServiceClient.GetResult());
        }

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void RunTests()
        {
            this.BDDfy<InitialBenchmark>();
        }
    }



    [Story]
    public class StandardItem_TheQualityOfAnItemIsNeverNegative
    {
        private List<Item> _items;
        private ApprovalTestsInventoryServiceClient _approvalTestsInventoryServiceClient;

        [Given]
        public void GivenSomeStandardItem()
        {
            _items = new List<Item>
            {
                new Item { Name = "SomeStandardItem", SellIn = 10, Quality = 0 }
            };
        }

        [When]
        public void WhenTheInventoryIsUpdated()
        {
            _approvalTestsInventoryServiceClient = new ApprovalTestsInventoryServiceClient();

            var sut = new Program(_items, new InventoryService());

            sut.UpdateQuality(_items, _approvalTestsInventoryServiceClient);
        }

        [Then]
        public void ThenTheUpdateIsAsExpected()
        {
            Approvals.Verify(_approvalTestsInventoryServiceClient.GetResult());
        }

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void RunTests()
        {
            this.BDDfy<InitialBenchmark>();
        }
    }

    [Story]
    public class StandardItem_ApplicationUpdate_SellInAndQualityReduced
    {
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

    [Story]
    public class StandardItem_ApplicationUpdate_QualityReducesTwiceAsFastAfterTheSellByDatae
    {
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
            _originalSellIn = 0;
            _originalQuality = 5;

            _expectedSellIn = -1;
            _expectedQuality = 3;
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

    [TestFixture]
    public class StandardItem_ApplicationUpdate_TheQualityOfAnItemIsNeverNegative
    {
        [TestCase(10, 9)]
        [TestCase(1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -2)]
        [TestCase(-10, -11)]
        public void WhenTheItemIsUpdated(int originalSellIn, int expectedSellIn)
        {
            var sut = new InventoryService();

            var inventoryItem = sut.UpdateItem("SomeStandardItem", originalSellIn, 0);

            Assert.That(inventoryItem.Name, Is.EqualTo("SomeStandardItem"));
            Assert.That(inventoryItem.SellIn, Is.EqualTo(expectedSellIn));
            Assert.That(inventoryItem.Quality, Is.EqualTo(0));
        }
    }

    [TestFixture]
    public class AgedBrie
    {
        [TestCase(10, 9, 10, 11)]
        [TestCase(1, 0, 10, 11)]
        [TestCase(0, -1, 10, 12)]
        [TestCase(-1, -2, 10, 12)]
        [TestCase(-10, -11, 10, 12)]
        [TestCase(10, 9, 49, 50)]
        [TestCase(1, 0, 49, 50)]
        [TestCase(0, -1, 49, 50)]
        [TestCase(-1, -2, 49, 50)]
        [TestCase(-10, -11, 49, 50)]
        [TestCase(10, 9, 50, 50)]
        [TestCase(1, 0, 50, 50)]
        [TestCase(0, -1, 50, 50)]
        [TestCase(-1, -2, 50, 50)]
        [TestCase(-10, -11, 50, 50)]
        public void WhenTheItemIsUpdated(int originalSellIn, int expectedSellIn, int originalQuality, int expectedQuality)
        {
            var sut = new InventoryService();

            var inventoryItem = sut.UpdateItem("Aged Brie", originalSellIn, originalQuality);

            Assert.That(inventoryItem.Name, Is.EqualTo("Aged Brie"));
            Assert.That(inventoryItem.SellIn, Is.EqualTo(expectedSellIn));
            Assert.That(inventoryItem.Quality, Is.EqualTo(expectedQuality));
        }
    }

    [TestFixture]
    public class Sulfuras
    {
        [TestCase(0, 0, 80, 80)]
        public void WhenTheItemIsUpdated(int originalSellIn, int expectedSellIn, int originalQuality, int expectedQuality)
        {
            var sut = new InventoryService();

            var inventoryItem = sut.UpdateItem("Sulfuras, Hand of Ragnaros", originalSellIn, originalQuality);

            Assert.That(inventoryItem.Name, Is.EqualTo("Sulfuras, Hand of Ragnaros"));
            Assert.That(inventoryItem.SellIn, Is.EqualTo(expectedSellIn));
            Assert.That(inventoryItem.Quality, Is.EqualTo(expectedQuality));
        }
    }

    [TestFixture]
    public class BackstagePasses
    {
        [TestCase(20, 19, 10, 11)]
        [TestCase(20, 19, 50, 50)]
        [TestCase(11, 10, 10, 11)]
        [TestCase(10, 9, 10, 12)]
        [TestCase(10, 9, 50, 50)]
        [TestCase(6, 5, 10, 12)]
        [TestCase(5, 4, 10, 13)]
        [TestCase(5, 4, 50, 50)]
        [TestCase(1, 0, 10, 13)]
        [TestCase(1, 0, 50, 50)]
        [TestCase(0, -1, 10, 0)]
        [TestCase(0, -1, 50, 0)]
        public void WhenTheItemIsUpdated(int originalSellIn, int expectedSellIn, int originalQuality, int expectedQuality)
        {
            var sut = new InventoryService();

            var inventoryItem = sut.UpdateItem("Backstage passes to a TAFKAL80ETC concert", originalSellIn, originalQuality);

            Assert.That(inventoryItem.Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"));
            Assert.That(inventoryItem.SellIn, Is.EqualTo(expectedSellIn));
            Assert.That(inventoryItem.Quality, Is.EqualTo(expectedQuality));
        }
    }
}
