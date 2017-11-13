namespace GildedRose.App.Updates
{
    internal class QualityLimitedIncreasingQualityStrategy : IUpdateStrategy
    {
        public InventoryItem Update(InventoryItem inventoryItem)
        {
            var sellIn = inventoryItem.SellIn - 1;

            var qualityIncrease = sellIn < 0
                ? 2
                : 1;

            var quality = inventoryItem.Quality + qualityIncrease;
            if (quality > 50)
            {
                quality = 50;
            }

            return new InventoryItem(inventoryItem.Name, sellIn, quality);
        }
    }
}