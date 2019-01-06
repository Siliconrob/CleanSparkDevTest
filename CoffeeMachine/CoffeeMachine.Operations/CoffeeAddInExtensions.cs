using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.Model;

namespace CoffeeMachine.Operations
{
    public static class CoffeeAddInExtensions
    {
        public static PriceResult ExtraPrice(this IEnumerable<CoffeeAddin> addins, IEnumerable<string> extras)
        {
            var extraDict = extras.ToReadOnlyDictionary();
            var pricingIssues = new List<string>();
            decimal? price = null;
            foreach (var extra in extraDict)
            {
                var match = addins.FirstOrDefault(a => a.Name.Equals(extra.Key));
                if (match == null)
                {
                    pricingIssues.Add($"No matching extra available for ${extra.Key}");
                    continue;
                }
                if (!match.IsValidRange(extra.Value))
                {
                    pricingIssues.Add($"${extra.Key} is invalid");
                }
                price += match.Price * extra.Value;
            }

            if (pricingIssues.Any())
            {
                return new PriceResult
                {
                    Message = string.Join(Environment.NewLine, pricingIssues)
                };
            }
            return new PriceResult
            {
                Price = price
            };
        }


        public static bool IsCurrentlyAvailable(this CoffeeAddin addIn, DateTime? timeStamp = null)
        {
            return addIn.IsValidAddin() && (timeStamp ?? DateTime.UtcNow).ToUniversalTime()
                   .WithinDateRange(addIn.FirstOffered, addIn.Discontinued);
        }

        public static bool IsValidAddin(this CoffeeAddin addIn)
        {
            if (addIn == null)
            {
                return false;
            }
            if (addIn.Minimum < 0)
            {
                return false;
            }
            if (addIn.Maximum.HasValue && addIn.Maximum.Value < 0)
            {
                return false;
            }
            if (addIn.Maximum.HasValue && addIn.Minimum > addIn.Maximum.Value)
            {
                return false;
            }
            return DateTimeExtensions.IsDateRangeValid(addIn.FirstOffered, addIn.Discontinued);
        }

        public static bool IsValidRange(this CoffeeAddin addIn, int extraCount)
        {
            return addIn.IsValidAddin() && extraCount >= addIn.Minimum &&
                   (!addIn.Maximum.HasValue || extraCount <= addIn.Maximum.Value);
        }
    }
}