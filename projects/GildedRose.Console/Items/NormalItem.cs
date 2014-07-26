namespace GildedRose.Console.Items
{
    public class NormalItem : ImprovedItem
    {
        public NormalItem(string name, int sellIn, int quality) :
            base(name, sellIn, quality) { }

        public override void UpdateQuality()
        {
            DecreaseQuality();
            DecreaseSellIn();
            if (IsExpired) DecreaseQuality();
        }
    }
}
