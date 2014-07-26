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
                UpdateQualityFor(item);
        }

        public void UpdateQualityFor(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                IncreaseQualityFor(item);
                DecreaseSellInFor(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                IncreaseQualityFor(item);
                if (item.SellIn < 11) IncreaseQualityFor(item);
                if (item.SellIn < 6) IncreaseQualityFor(item);
                DecreaseSellInFor(item);
            }
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
            }
            else
            {
                DecreaseQualityFor(item);
                DecreaseSellInFor(item);
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            DecreaseQualityFor(item);
                        }
                    }
                    else
                    {
                        DropQualityFor(item);
                    }
                }
                else
                {
                    IncreaseQualityFor(item);
                }
            }
        }

        private void DecreaseSellInFor(Item item)
        {
            item.SellIn--;
        }

        private void DropQualityFor(Item item)
        {
            item.Quality = 0;
        }

        private void IncreaseQualityFor(Item item)
        {
            if (item.Quality < 50) item.Quality++;
        }

        private void DecreaseQualityFor(Item item)
        {
            if (item.Quality > 0) item.Quality--;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
