namespace GildedRose.App.Updates
{
    internal class TimeLimitedIncreasingQualityStrategy : IUpdateStrategy
    {
        public InventoryItem Update(InventoryItem inventoryItem)
        {
            var sellIn = inventoryItem.SellIn - 1;

            var qualityIncrease = 1;
            if (sellIn < 5)
            {
                qualityIncrease = 3;
            }
            else if(sellIn < 10)
            {
                qualityIncrease = 2;
            }

            var quality = inventoryItem.Quality + qualityIncrease;
            if (quality > 50)
            {
                quality = 50;
            }

            if (sellIn < 0)
            {
                quality = 0;
            }

            return new InventoryItem(inventoryItem.Name, sellIn, quality);
        }
    }
}