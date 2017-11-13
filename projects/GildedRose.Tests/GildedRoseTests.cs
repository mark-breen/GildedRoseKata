using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using GildedRose.App;
using GildedRose.Console;
using NUnit.Framework;
using TestStack.BDDfy;

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
}
