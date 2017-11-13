﻿using System.Collections.Generic;
using GildedRose.App.Updates;

namespace GildedRose.App
{
    public class InventoryService
    {
        private readonly HashSet<string> _nonRefactoredItems = new HashSet<string>
        {
        };

        private readonly Dictionary<string, IUpdateStrategy> _nonStandardUpdateStrategies = new Dictionary<string, IUpdateStrategy>
        {
            { "Aged Brie", new QualityLimitedIncreasingQualityStrategy() },
            { "Backstage passes to a TAFKAL80ETC concert", new TimeLimitedIncreasingQualityStrategy() },
            { "Sulfuras, Hand of Ragnaros", new LegendaryItemStrategy() },
        };

        public InventoryItem UpdateItem(string name, int sellIn, int quality)
        {
            var inventoryItem = new InventoryItem(name, sellIn, quality);

            if (_nonRefactoredItems.Contains(inventoryItem.Name))
            {
                return LegacyUpdateMethod(inventoryItem);
            }

            if (_nonStandardUpdateStrategies.ContainsKey(inventoryItem.Name))
            {
                return _nonStandardUpdateStrategies[inventoryItem.Name].Update(inventoryItem);
            }

            return new StandardItemUpdateStrategy().Update(inventoryItem);
        }

        private static InventoryItem LegacyUpdateMethod(InventoryItem inventoryItem)
        {
            if (inventoryItem.Name != "Aged Brie" && inventoryItem.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (inventoryItem.Quality > 0)
                {
                    if (inventoryItem.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        inventoryItem.Quality = inventoryItem.Quality - 1;
                    }
                }
            }
            else
            {
                if (inventoryItem.Quality < 50)
                {
                    inventoryItem.Quality = inventoryItem.Quality + 1;

                    if (inventoryItem.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (inventoryItem.SellIn < 11)
                        {
                            if (inventoryItem.Quality < 50)
                            {
                                inventoryItem.Quality = inventoryItem.Quality + 1;
                            }
                        }

                        if (inventoryItem.SellIn < 6)
                        {
                            if (inventoryItem.Quality < 50)
                            {
                                inventoryItem.Quality = inventoryItem.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (inventoryItem.Name != "Sulfuras, Hand of Ragnaros")
            {
                inventoryItem.SellIn = inventoryItem.SellIn - 1;
            }

            if (inventoryItem.SellIn < 0)
            {
                if (inventoryItem.Name != "Aged Brie")
                {
                    if (inventoryItem.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (inventoryItem.Quality > 0)
                        {
                            if (inventoryItem.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                inventoryItem.Quality = inventoryItem.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        inventoryItem.Quality = inventoryItem.Quality - inventoryItem.Quality;
                    }
                }
                else
                {
                    if (inventoryItem.Quality < 50)
                    {
                        inventoryItem.Quality = inventoryItem.Quality + 1;
                    }
                }
            }

            return inventoryItem;
        }
    }

    public class InventoryItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public InventoryItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }
    }
}