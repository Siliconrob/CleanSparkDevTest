using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.DataAccess;
using CoffeeMachine.Model;
using CoffeeMachine.Model.Transaction;

namespace CoffeeMachine.Operations
{
    public static class PersistenceExtensions
    {
        public static IEnumerable<Denomination> AvailableDenominations(this IPersistence dataSource)
        {
            return dataSource.ChangeOptions().Where(a => a.CanDispense);
        }

        public static IEnumerable<CoffeeAddin> AvailableAddins(this IPersistence dataSource, DateTime? timeStamp = null)
        {
            return dataSource.Addins().Where(z => z.IsCurrentlyAvailable(timeStamp));
        }
        public static IEnumerable<CoffeeSize> AvailableSizes(this IPersistence dataSource, DateTime? timeStamp = null)
        {
            return dataSource.Sizes().Where(z => z.IsCurrentlyAvailable(timeStamp));
        }
    }
}