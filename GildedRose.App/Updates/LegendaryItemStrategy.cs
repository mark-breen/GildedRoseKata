namespace GildedRose.App.Updates
{
    internal class LegendaryItemStrategy : IUpdateStrategy
    {
        public InventoryItem Update(InventoryItem inventoryItem)
        {
            return inventoryItem;
        }
    }
}