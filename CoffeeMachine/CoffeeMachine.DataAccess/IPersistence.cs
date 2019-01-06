using System.Collections.Generic;
using CoffeeMachine.Model;
using CoffeeMachine.Model.Transaction;

namespace CoffeeMachine.DataAccess
{
    public interface IPersistence
    {
        IEnumerable<CoffeeAddin> Addins();
        IEnumerable<CoffeeSize> Sizes();
        IEnumerable<Denomination> ChangeOptions();
    }
}