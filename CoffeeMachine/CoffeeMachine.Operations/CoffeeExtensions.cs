using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.Model;

namespace CoffeeMachine.Operations
{
    public static class CoffeeExtensions
    {
        public static bool IsValid(this Coffee coffee, IEnumerable<CoffeeSize> sizes, IEnumerable<CoffeeAddin> addins)
        {
            var extras = coffee.Extras.ToReadOnlyDictionary();
            var validExtras = (from extra in extras.Where(a => a.Value > 0).Select(z => z.Key)
                let match = addins.FirstOrDefault(z => z.Name.Equals(extra))
                where match != null
                let extraCount = extras[extra]
                where extraCount >= match.Minimum
                where !match.Maximum.HasValue || extraCount <= match.Maximum.Value
                select match).Count();
            return validExtras == extras.Values.Sum() &&
                   sizes.Select(z => z.Name).Distinct().Any(a => a.Equals(coffee.Name));
        }
    }
}