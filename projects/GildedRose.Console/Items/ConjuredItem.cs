namespace GildedRose.Console.Items
{
    public class ConjuredItem : NormalItem
    {
        public ConjuredItem(int sellIn, int quality) :
            base("Conjured Mana Cake", sellIn, quality) { }

        public override void DecreaseQuality()
        {
            base.DecreaseQuality();
            base.DecreaseQuality();
        }
    }
}
