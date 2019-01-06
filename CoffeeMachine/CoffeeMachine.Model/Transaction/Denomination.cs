namespace CoffeeMachine.Model.Transaction
{
    public class Denomination
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool CanDispense { get; set; }
    }
}