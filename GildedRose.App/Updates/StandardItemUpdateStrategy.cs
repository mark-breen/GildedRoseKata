﻿namespace GildedRose.App.Updates
{
    internal class StandardItemUpdateStrategy : IUpdateStrategy
    {
        public InventoryItem Update(InventoryItem inventoryItem)
        {
            var sellIn = inventoryItem.SellIn - 1;

            var qualityDegradation = sellIn < 0
                ? 2
                : 1;

            var quality = inventoryItem.Quality - qualityDegradation;
            if (quality < 0)
            {
                quality = 0;
            }

            return new InventoryItem(inventoryItem.Name, sellIn, quality);
        }
    }
}