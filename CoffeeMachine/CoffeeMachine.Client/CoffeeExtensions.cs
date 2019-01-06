using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CoffeeMachine.Model;
using CoffeeMachine.Operations;

namespace CoffeeMachine.Client
{
    public static class CoffeeExtensions
    {
        public static ListViewItem ToListViewItem(this Coffee cup, CoffeeOrder current)
        {
            var subItems = new List<string>
            {
                cup.Name,
                cup.Extras.Count(s => s.Equals(AddinNames.Cream)).ToString(),
                cup.Extras.Count(s => s.Equals(AddinNames.Sugar)).ToString()
            };
            if (current.Data.IsValid(cup))
            {
                var cost = cup.Price(current);
                var total = cost.Cup.Price.GetValueOrDefault() + cost.Extras.Price.GetValueOrDefault();
                subItems.Add(total.ToString());
            }
            var item = new ListViewItem(subItems.ToArray())
            {
                Tag = cup
            };
            return item;
        }
    }
}