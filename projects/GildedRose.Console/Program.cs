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
                                              new ImprovedItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new ImprovedItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new ImprovedItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new ImprovedItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new ImprovedItem
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
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
            if (item.Name == "Sulfuras, Hand of Ragnaros") return;

            if (item.Name == "Aged Brie")
            {
                IncreaseQualityFor(item);
                item.DecreaseSellIn();
                if (item.SellIn < 0) IncreaseQualityFor(item);
                return;
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                IncreaseQualityFor(item);
                if (item.SellIn < 11) IncreaseQualityFor(item);
                if (item.SellIn < 6) IncreaseQualityFor(item);
                item.DecreaseSellIn();
                if (item.SellIn < 0) DropQualityFor(item);
                return;
            }

            DecreaseQualityFor(item);
            item.DecreaseSellIn();
            if (item.SellIn < 0) DecreaseQualityFor(item);
        }

        private void DropQualityFor(ImprovedItem item)
        {
            item.Quality = 0;
        }

        private void IncreaseQualityFor(ImprovedItem item)
        {
            if (item.Quality < 50) item.Quality++;
        }

        private void DecreaseQualityFor(ImprovedItem item)
        {
            if (item.Quality > 0) item.Quality--;
        }
    }
}
