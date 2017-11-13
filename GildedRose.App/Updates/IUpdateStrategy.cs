namespace GildedRose.App.Updates
{
    internal interface IUpdateStrategy
    {
        InventoryItem Update(InventoryItem inventoryItem);
    }
}