using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.Model;

namespace CoffeeMachine.Operations
{
    public static class CoffeeSizeExtensions
    {
        public static PriceResult CupPrice(this IEnumerable<CoffeeSize> sizes, string cupSize)
        {
            var match = (sizes ?? new List<CoffeeSize>()).FirstOrDefault(a => a.Name.Equals(cupSize));
            if (match == null)
            {
                return new PriceResult
                {
                    Message = $"No matching cup available for ${cupSize}"
                };
            }
            if (!match.IsValid())
            {
                return new PriceResult
                {
                    Message = $"${cupSize} is invalid"
                };
            }
            return new PriceResult
            {
                Price = match.Price
            };
        }

        public static bool IsCurrentlyAvailable(this CoffeeSize size, DateTime? timeStamp = null)
        {
            return size.IsValid() && (timeStamp ?? DateTime.UtcNow).ToUniversalTime()
                   .WithinDateRange(size.FirstOffered, size.Discontinued);
        }

        public static bool IsValid(this CoffeeSize size)
        {
            return size != null && DateTimeExtensions.IsDateRangeValid(size.FirstOffered, size.Discontinued);
        }
    }
}