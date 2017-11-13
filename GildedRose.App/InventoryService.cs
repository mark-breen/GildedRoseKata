namespace GildedRose.App
{
    public class InventoryService
    {
        public InventoryItem UpdateItem(string name, int sellIn, int quality)
        {
            var inventoryItem = new InventoryItem(name, sellIn, quality);

            if (inventoryItem.Name != "Aged Brie" && inventoryItem.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (inventoryItem.Quality > 0)
                {
                    if (inventoryItem.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        inventoryItem.Quality = inventoryItem.Quality - 1;
                    }
                }
            }
            else
            {
                if (inventoryItem.Quality < 50)
                {
                    inventoryItem.Quality = inventoryItem.Quality + 1;

                    if (inventoryItem.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (inventoryItem.SellIn < 11)
                        {
                            if (inventoryItem.Quality < 50)
                            {
                                inventoryItem.Quality = inventoryItem.Quality + 1;
                            }
                        }

                        if (inventoryItem.SellIn < 6)
                        {
                            if (inventoryItem.Quality < 50)
                            {
                                inventoryItem.Quality = inventoryItem.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (inventoryItem.Name != "Sulfuras, Hand of Ragnaros")
            {
                inventoryItem.SellIn = inventoryItem.SellIn - 1;
            }

            if (inventoryItem.SellIn < 0)
            {
                if (inventoryItem.Name != "Aged Brie")
                {
                    if (inventoryItem.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (inventoryItem.Quality > 0)
                        {
                            if (inventoryItem.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                inventoryItem.Quality = inventoryItem.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        inventoryItem.Quality = inventoryItem.Quality - inventoryItem.Quality;
                    }
                }
                else
                {
                    if (inventoryItem.Quality < 50)
                    {
                        inventoryItem.Quality = inventoryItem.Quality + 1;
                    }
                }
            }

            return inventoryItem;
        }
    }

    public class InventoryItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public InventoryItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }
    }
}