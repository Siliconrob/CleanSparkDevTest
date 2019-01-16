using System.Collections.Generic;
using CoffeeMachine.Model;
using CoffeeMachine.Model.Transaction;

namespace CoffeeMachine.DataAccess
{
    public class MockPersistence : IPersistence
    {
        public IEnumerable<CoffeeAddin> Addins()
        {
            return new List<CoffeeAddin>
            {
                new CoffeeAddin
                {
                    Name = "Cream",
                    Price = .5M,
                    Maximum = 3
                },
                new CoffeeAddin
                {
                    Name = "Sugar",
                    Price = .25M,
                    Maximum = 3
                }
            };
        }

        public IEnumerable<CoffeeSize> Sizes()
        {
            return new List<CoffeeSize>
            {
                new CoffeeSize
                {
                    Name = "Small",
                    Price = 1.75M,
                    Size = 8
                },
                new CoffeeSize
                {
                    Name = "Medium",
                    Price = 2M,
                    Size = 12
                },
                new CoffeeSize
                {
                    Name = "Large",
                    Price = 2.25M,
                    Size = 16
                }
            };
        }

        public IEnumerable<Denomination> ChangeOptions()
        {
            return new List<Denomination>
            {
                new Denomination
                {
                    Name = "Penny",
                    Value = .01M
                },
                new Denomination
                {
                    Name = "Nickel",
                    Value = .05M,
                    CanDispense = true
                },
                new Denomination
                {
                    Name = "Dime",
                    Value = .1M,
                    CanDispense = true
                },
                new Denomination
                {
                    Name = "Quarter",
                    Value = .25M,
                    CanDispense = true
                },
                new Denomination
                {
                    Name = "Half Dollar",
                    Value = .5M
                },
                new Denomination
                {
                    Name = "Dollar Bill",
                    Value = 1,
                    CanDispense = true
                },
                new Denomination
                {
                    Name = "5 Dollar Bill",
                    Value = 5,
                    CanDispense = true
                },
                new Denomination
                {
                    Name = "10 Dollar Bill",
                    Value = 10,
                    CanDispense = true
                },
                new Denomination
                {
                    Name = "20 Dollar Bill",
                    Value = 20,
                    CanDispense = true
                }
            };
        }
    }
}
