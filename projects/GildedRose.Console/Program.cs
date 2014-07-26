using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                                          {
                                              new NormalItem(name: "+5 Dexterity Vest", sellIn: 10, quality: 20),
                                              new AgedBrie(sellIn: 2, quality: 0),
                                              new NormalItem(name: "Elixir of the Mongoose", sellIn: 5, quality: 7),
                                              new Sulfuras(sellIn: 0, quality: 80),
                                              new BackstagePasses (sellIn: 15, quality: 20),
                                              new ImprovedItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public Program() { }

        public Program(Item item)
        {
            Items = new List<Item> { item };
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var improvedItem = item as ImprovedItem;
                UpdateQualityFor(improvedItem);
            }
        }

        public void UpdateQualityFor(ImprovedItem item)
        {
            item.UpdateQuality();

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.IncreaseQuality();
                if (item.SellIn <= 10) item.IncreaseQuality();
                if (item.SellIn <= 5) item.IncreaseQuality();
                item.DecreaseSellIn();
                if (item.IsExpired) item.DropQuality();
                return;
            }
        }
    }
}
