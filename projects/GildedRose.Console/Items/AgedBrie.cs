namespace GildedRose.Console.Items
{
    public class AgedBrie : ImprovedItem
    {
        public AgedBrie(int sellIn, int quality) :
            base(name: "Aged Brie", sellIn: sellIn, quality: quality) { }

        public override void UpdateQuality()
        {
            IncreaseQuality();
            DecreaseSellIn();
            if (IsExpired) IncreaseQuality();
        }
    }
}
