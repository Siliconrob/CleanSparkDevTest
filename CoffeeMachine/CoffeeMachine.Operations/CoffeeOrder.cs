using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.DataAccess;
using CoffeeMachine.Model;
using CoffeeMachine.Model.Transaction;

namespace CoffeeMachine.Operations
{
    public class CoffeeOrder
    {
        public List<Coffee> Cups { get; }
        public readonly DateTime Initiated;
        public readonly MockPersistence Data;
        public List<decimal> Payments { get; }

        public Coffee Start(string cupSize)
        {
            var match = Data.AvailableSizes(Initiated).FirstOrDefault(a => a.Name.Equals(cupSize));
            if (match == null)
            {
                return null;
            }
            return new Coffee
            {
                Id = Guid.NewGuid(),
                Name = match.Name,
                Extras = new List<string>()
            };
        }

        public CoffeeOrder()
        {
            Initiated = DateTime.UtcNow;
            Data = new MockPersistence(); 
            Cups = new List<Coffee>();
            Payments = new List<decimal>();
        }

        public PriceResult Price()
        {
            var invalidCups = new List<Guid>();
            var invalidCupMessages = new List<string>();
            var orderCost = 0M;
            foreach (var cup in Cups)
            {
                ProvideId(cup);
                var total = new
                {
                    Cup = Data.Sizes().CupPrice(cup.Name),
                    Extras = Data.Addins().ExtraPrice(cup.Extras)
                };
                if (string.IsNullOrEmpty(total.Cup.Message) && string.IsNullOrEmpty(total.Extras.Message))
                {
                    orderCost += total.Cup.Price.GetValueOrDefault() + total.Extras.Price.GetValueOrDefault();
                    continue;
                }
                invalidCups.Add(cup.Id);
                invalidCupMessages.Add($"{total.Cup.Message ?? ""}{total.Extras.Message ?? ""}");
            }
            if (invalidCups.Any())
            {
                //OnRaiseInvalidCups()
                return new PriceResult
                {
                    Message = string.Join(Environment.NewLine, invalidCupMessages)
                };
            }
            return new PriceResult
            {
                Price = orderCost
            };
        }

        private static void ProvideId(Coffee cup)
        {
            if (cup.Id == Guid.Empty)
            {
                cup.Id = Guid.NewGuid();
            }
        }

        public bool CanDispense()
        {
            var orderPrice = Price();
            if (orderPrice == null || !string.IsNullOrEmpty(orderPrice.Message))
            {
                return false;
            }
            return Payments.Sum() >= orderPrice.Price.GetValueOrDefault();
        }

        public Receipt End()
        {
            var dispensed = CanDispense();
            var result = new Receipt
            {
                Id = Guid.NewGuid(),
                Cups = dispensed ? Cups : new List<Coffee>(),
                Payments = Payments,
                Started = Initiated,
                ChangeDispensed = Data.ChangeOptions().GetChange(Payments.Sum() - Price().Price.GetValueOrDefault())
            };
            if (dispensed)
            {
                result.Sold = DateTime.UtcNow;
            }
            return result;
        }
    }
}