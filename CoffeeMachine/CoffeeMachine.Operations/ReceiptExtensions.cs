using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeMachine.Model;

namespace CoffeeMachine.Operations
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
            var cups = current.Cups ?? new List<Coffee>();
            if (current.Sold.HasValue && cups.Any())
            {
                message.AppendLine($"Dispensed: {current.Sold}");
            }
            else
            {
                message.AppendLine($"No coffee dispensed");
            }
            foreach (var cup in cups)
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
            var totalPaid = (current.Payments ?? new List<decimal>()).Sum();
            {
                message.AppendLine($"Payments Total: {totalPaid:F}");
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