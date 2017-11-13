namespace GildedRose.App.Updates
{
    internal interface IUpdateStrategy
    {
        InventoryItem Update(InventoryItem inventoryItem);
    }

    internal class StandardItemUpdateStrategy : IUpdateStrategy
    {
        public InventoryItem Update(InventoryItem inventoryItem)
        {
            var sellIn = inventoryItem.SellIn - 1;

            var qualityDegradation = sellIn < 0
                ? 2
                : 1;

            var quality = inventoryItem.Quality;
            if (quality > 0)
            {
                quality = quality - qualityDegradation;
            }

            return new InventoryItem(inventoryItem.Name, sellIn, quality);
        }
    }
}