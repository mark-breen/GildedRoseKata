namespace GildedRose.Console
{
    public abstract class ImprovedItem : Item
    {
        private const int MinimumQuality = 0;
        private const int MaximumQuality = 50;

        protected ImprovedItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void DecreaseSellIn()
        {
            SellIn--;
        }

        public void DropQuality()
        {
            Quality = MinimumQuality;
        }

        public void IncreaseQuality()
        {
            if (Quality < MaximumQuality) Quality++;
        }

        public void DecreaseQuality()
        {
            if (Quality > MinimumQuality) Quality--;
        }

        public bool IsExpired
        {
            get { return SellIn < 0; }
        }

        public abstract void UpdateQuality();
    }
}
