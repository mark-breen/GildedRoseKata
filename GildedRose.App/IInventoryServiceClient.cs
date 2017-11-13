namespace GildedRose.App
{
    public interface IInventoryServiceClient
    {
        void ItemUpdated(string name, int sellIn, int quality);
    }
}