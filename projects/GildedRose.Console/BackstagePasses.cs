namespace GildedRose.Console
{
    public class BackstagePasses : ImprovedItem
    {
        public BackstagePasses(int sellIn, int quality) :
            base(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: sellIn, quality: quality) { }

        public override void UpdateQuality()
        {
            IncreaseQuality();
            if (SellIn <= 10) IncreaseQuality();
            if (SellIn <= 5) IncreaseQuality();
            DecreaseSellIn();
            if (IsExpired) DropQuality();
        }
    }
}
