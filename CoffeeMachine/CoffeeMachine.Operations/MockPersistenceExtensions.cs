using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.DataAccess;
using CoffeeMachine.Model;

namespace CoffeeMachine.Operations
{
    public static class MockPersistenceExtensions
    {
        public static IReadOnlyList<string> AvailableAddIns(this CoffeeOrder order)
        {
            return order.Data.AvailableAddins(order.Initiated).Select(z => z.Name).ToList();
        }

        public static IReadOnlyList<string> AvailableSizes(this CoffeeOrder order)
        {
            return order.Data.AvailableSizes(order.Initiated).Select(z => z.Name).ToList();
        }

        public static bool IsValid(this CoffeeOrder order)
        {
            return (order.Cups ?? new List<Coffee>()).All(a => a.IsValid(order.Sizes(), order.Addins()));
        }

        public static bool IsValid(this MockPersistence persistence, Coffee coffee, DateTime? filter = null)
        {
            return coffee.IsValid(persistence.AvailableSizes(filter), persistence.AvailableAddins(filter));
        }

        public static IEnumerable<CoffeeAddin> Addins(this CoffeeOrder order)
        {
            return order.Data.AvailableAddins(order.Initiated);
        }

        public static IEnumerable<CoffeeSize> Sizes(this CoffeeOrder order)
        {
            return order.Data.AvailableSizes(order.Initiated);
        }
    }
}