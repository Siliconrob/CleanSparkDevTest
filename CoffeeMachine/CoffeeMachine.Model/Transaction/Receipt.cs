using System;
using System.Collections.Generic;

namespace CoffeeMachine.Model.Transaction
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Sold { get; set; }
        public List<Coffee> Cups { get; set; }
        public List<decimal> Payments { get; set; }
        public Dictionary<string, int> ChangeDispensed { get; set; }
    }
}