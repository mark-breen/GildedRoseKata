using GildedRose.Console.Items;

namespace GildedRose.Console
{
    using System.Collections.Generic;
    using System;

    public class Program
    {
        static IList<Item> Items;
        static void Main()
        {
            AddItemsToInventory();
            UpdateQuality();
            Console.ReadKey();
        }

        private static void AddItemsToInventory()
        {
            Items = new List<Item>
            {
                new NormalItem(name: "+5 Dexterity Vest", sellIn: 10, quality: 20),
                new NormalItem(name: "Elixir of the Mongoose", sellIn: 5, quality: 7),
                new AgedBrie(sellIn: 2, quality: 0),
                new Sulfuras(sellIn: 0, quality: 80),
                new BackstagePasses(sellIn: 15, quality: 20),
                new ConjuredItem(sellIn: 3, quality: 6)
            };
        }

        public static void UpdateQuality()
        {
            foreach (var item in Items)
                UpdateQualityFor(item);
        }

        public static void UpdateQualityFor(Item item)
        {
            if (!(item is ImprovedItem))
                throw new Exception("You must use an ImprovedItem!");

            (item as ImprovedItem).UpdateQuality();
        }
    }
}
