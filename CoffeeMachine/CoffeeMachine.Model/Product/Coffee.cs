using System;
using System.Collections.Generic;

namespace CoffeeMachine.Model
{
    public class Coffee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Extras { get; set; }
    }
}
