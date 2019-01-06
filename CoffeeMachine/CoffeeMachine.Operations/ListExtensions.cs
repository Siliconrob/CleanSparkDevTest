using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CoffeeMachine.Operations
{
    public static class ListExtensions
    {
        public static IReadOnlyDictionary<string, int> ToReadOnlyDictionary(this IEnumerable<string> items)
        {
            var dict = (items ?? new List<string>()).GroupBy(a => a)
                .ToDictionary(grouping => grouping.Key, grouping => grouping.Count());
            return new ReadOnlyDictionary<string, int>(dict);
        }
    }
}