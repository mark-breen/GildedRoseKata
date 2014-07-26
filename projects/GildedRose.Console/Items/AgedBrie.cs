namespace GildedRose.Console.Items
{
    public class AgedBrie : ImprovedItem
    {
        public AgedBrie(int sellIn, int quality) :
            base("Aged Brie", sellIn, quality) { }

        public override void UpdateQuality()
        {
            IncreaseQuality();
            DecreaseSellIn();
            if (IsExpired) IncreaseQuality();
        }
    }
}
