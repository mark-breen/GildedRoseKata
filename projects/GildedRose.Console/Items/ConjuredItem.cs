namespace GildedRose.Console.Items
{
    public class ConjuredItem : ImprovedItem
    {
        public ConjuredItem(int sellIn, int quality) :
            base("Conjured Mana Cake", sellIn, quality) { }

        public override void UpdateQuality()
        {
        }
    }
}
