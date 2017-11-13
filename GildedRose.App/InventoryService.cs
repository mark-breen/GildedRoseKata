using System.Collections.Generic;
using GildedRose.App.Updates;

namespace GildedRose.App
{
    public class InventoryService
    {
        private readonly Dictionary<string, IUpdateStrategy> _nonStandardUpdateStrategies = new Dictionary<string, IUpdateStrategy>
        {
            { "Aged Brie", new QualityLimitedIncreasingQualityStrategy() },
            { "Backstage passes to a TAFKAL80ETC concert", new TimeLimitedIncreasingQualityStrategy() },
            { "Conjured Mana Cake", new ConjuredItemUpdateStrategy() },
            { "Sulfuras, Hand of Ragnaros", new LegendaryItemStrategy() },
        };

        public InventoryItem UpdateItem(string name, int sellIn, int quality)
        {
            var inventoryItem = new InventoryItem(name, sellIn, quality);

            if (_nonStandardUpdateStrategies.ContainsKey(inventoryItem.Name))
            {
                return _nonStandardUpdateStrategies[inventoryItem.Name].Update(inventoryItem);
            }

            return new StandardItemUpdateStrategy().Update(inventoryItem);
        }
    }

    public class InventoryItem
    {
        public string Name { get; }
        public int SellIn { get; }
        public int Quality { get; }

        public InventoryItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }
    }
}