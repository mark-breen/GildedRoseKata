namespace GildedRose.Console.Items
{
    public class ConjuredItem : ImprovedItem
    {
        public ConjuredItem(int sellIn, int quality) :
            base("Conjured Mana Cake", sellIn, quality) { }

        public override void UpdateQuality()
        {
            DecreaseQuality();
            DecreaseSellIn();
            if (IsExpired) DecreaseQuality();
        }

        private new void DecreaseQuality()
        {
            base.DecreaseQuality();
            base.DecreaseQuality();
        }
    }
}
