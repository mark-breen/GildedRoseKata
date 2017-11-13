using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.App;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class ApprovalTestsInventoryServiceClient : IInventoryServiceClient
    {
        private readonly List<Item> _results = new List<Item>();

        public void ItemUpdated(string name, int sellIn, int quality)
        {
            _results.Add(new Item { Name = name, SellIn = sellIn, Quality = quality});
        }

        public string GetResult()
        {
            var orderedEnumerable = _results.OrderBy(x => x.Name);

            var result = new StringBuilder();

            foreach (var item in orderedEnumerable)
            {
                result.AppendLine($"Name: '{item.Name}'; SellIn: '{item.SellIn}'; Quality: '{item.Quality}'");
            }

            return result.ToString();
        }
    }
}