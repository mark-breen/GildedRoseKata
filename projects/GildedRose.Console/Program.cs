using System.Collections.Generic;
using GildedRose.App;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> Items;
        private InventoryService _inventoryService;

        public Program(IList<Item> items, InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            Items = items;
        }

        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var items = new List<Item>
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
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var inventoryService = new InventoryService();
            var app = new Program(items, inventoryService);

            app.UpdateQuality(items, new NullInventoryServiceClient());

            System.Console.ReadKey();

        }

        public void UpdateQuality(List<Item> items, IInventoryServiceClient nullInventoryServiceClient)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                var updatedItem = _inventoryService.UpdateItem(item.Name, item.SellIn, item.Quality);
                nullInventoryServiceClient.ItemUpdated(updatedItem.Name, updatedItem.SellIn, updatedItem.Quality);
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

    public class NullInventoryServiceClient : IInventoryServiceClient
    {
        public void ItemUpdated(string name, int sellIn, int quality)
        {
            // Do nothing
        }
    }
}
