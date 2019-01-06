using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine.Model.Product
{
    public static class CoffeeSizeExtensions
    {
        private static SortedDictionary<int, CoffeeSize> SizeLookup(this IEnumerable<CoffeeSize> Options)
        {
            Options = Options ?? new List<CoffeeSize>();
            var coffeeSizes = Options as CoffeeSize[] ?? Options.ToArray();
            if (!coffeeSizes.Any())
            {
                return null;
            }
            var sizeLookup = new SortedDictionary<int, CoffeeSize>();
            foreach (var option in coffeeSizes.GroupBy(a => a.Size))
            {
                if (sizeLookup.ContainsKey(option.Key))
                {
                    continue;
                }
                sizeLookup.Add(option.Key, option.Last());
            }
            return sizeLookup;
        }

        public static CoffeeSize NextLarger(this CoffeeSize input, IEnumerable<CoffeeSize> Options)
        {
            var lookupTable = Options.SizeLookup();
            if (lookupTable == null)
            {
                return null;
            }
            var nextLarger = lookupTable.Keys.ToList().IndexOf(input.Size) + 1;
            return nextLarger > lookupTable.Keys.Count ? null : lookupTable.ElementAt(nextLarger).Value;
        }

        public static CoffeeSize NextSmaller(this CoffeeSize input, IEnumerable<CoffeeSize> Options)
        {
            var lookupTable = Options.SizeLookup();
            if (lookupTable == null)
            {
                return null;
            }
            var nextSmaller = lookupTable.Keys.ToList().IndexOf(input.Size) - 1;
            return nextSmaller < 0 ? null : lookupTable.ElementAt(nextSmaller).Value;
        }
    }
}