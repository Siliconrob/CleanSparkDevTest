using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.Model;

namespace CoffeeMachine.Operations
{
    public static class CoffeeExtensions
    {
        public static CompoundPriceResult Price(this Coffee cup, CoffeeOrder order)
        {
            return new CompoundPriceResult
            {
                Cup = order.Data.Sizes().CupPrice(cup.Name),
                Extras = order.Data.Addins().ExtraPrice(cup.Extras)
            };
        }

        public static bool IsValid(this Coffee coffee, IEnumerable<CoffeeSize> sizes, IEnumerable<CoffeeAddin> addins)
        {
            var extras = coffee.Extras.ToReadOnlyDictionary();
            var sizeOptions = (sizes ?? new List<CoffeeSize>()).Select(a => a.Name);
            if (!sizeOptions.Contains(coffee.Name))
            {
                return false;
            }
            foreach (var extra in extras)
            {
                var match = (addins ?? new List<CoffeeAddin>()).FirstOrDefault(a => a.Name.Equals(extra.Key));
                if (match == null)
                {
                    return false;
                }
                if (extra.Value < match.Minimum || match.Maximum.HasValue && match.Maximum < extra.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class CompoundPriceResult
    {
        public PriceResult Cup { get; set; }
        public PriceResult Extras { get; set; }
    }
}