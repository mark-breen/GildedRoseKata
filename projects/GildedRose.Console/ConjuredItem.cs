namespace GildedRose.Console
{
    public class ConjuredItem : ImprovedItem
    {
        public ConjuredItem(int sellIn, int quality) :
            base(name: "Conjured Mana Cake", sellIn: sellIn, quality: quality) { }

        public override void UpdateQuality()
        {
        }
    }
}
