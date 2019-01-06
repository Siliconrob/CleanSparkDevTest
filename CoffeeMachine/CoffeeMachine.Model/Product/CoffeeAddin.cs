using System;

namespace CoffeeMachine.Model
{
    public class CoffeeAddin
    {
        public string Name { get; set; }
        public int Minimum { get; set; }
        public int? Maximum { get; set; }
        public decimal Price { get; set; }
        public DateTime? FirstOffered { get; set; }
        public DateTime? Discontinued { get; set; }
    }
}