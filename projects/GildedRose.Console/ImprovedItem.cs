namespace GildedRose.Console
{
    public class ImprovedItem : Item
    {
        public void DecreaseSellIn()
        {
            SellIn--;
        }

        public void DropQuality()
        {
            Quality = 0;
        }
    }
}
