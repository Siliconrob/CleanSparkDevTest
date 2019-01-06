using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeMachine.Model;
using CoffeeMachine.Model.Transaction;
using CoffeeMachine.Operations;

namespace CoffeeMachine.Client
{
    public static class ReceiptExtensions
    {
        public static string ReceiptText(this CoffeeOrder order)
        {
            var current = order.End();
            if (current == null)
            {
                return "Invalid receipt.  Please contact support";
            }
            var message = new StringBuilder();
            message.AppendLine($"Id: {current.Id}");
            message.AppendLine($"Start: {current.Started}");
            if (current.Sold.HasValue)
            {
                message.AppendLine($"Dispensed: {current.Sold}");
            }
            foreach (var cup in current.Cups ?? new List<Coffee>())
            {
                var extras = cup.Extras.ToReadOnlyDictionary();
                var extraText = string.Join(" ", extras.Select(z => $"{z.Value} - {z.Key}"));
                message.AppendLine($"Coffee {cup.Name} {extraText} {cup.Paid(order):F}");
            }
            var total = order.Price();
            if (total.Price.HasValue)
            {
                message.AppendLine($"Coffee Total: {total.Price.GetValueOrDefault():F}");
            }
            foreach (var payment in current.Payments ?? new List<decimal>())
            {
                message.AppendLine($"Paid {payment:F}");
            }
            message.AppendLine($"Change:");
            foreach (var change in current.ChangeDispensed)
            {
                if (change.Value > 0)
                {
                    message.AppendLine($"{change.Value} - {change.Key}");
                }
            }
            return message.ToString();
        }
    }
}