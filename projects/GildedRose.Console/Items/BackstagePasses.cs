﻿namespace GildedRose.Console.Items
{
    public class BackstagePasses : ImprovedItem
    {
        public BackstagePasses(int sellIn, int quality) :
            base("Backstage passes to a TAFKAL80ETC concert", sellIn, quality) { }

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
