using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.Model.Transaction;

namespace CoffeeMachine.Operations
{
    public static class DenominationExtensions
    {
        public static Dictionary<string, int> GetChange(this IEnumerable<Denomination> options, decimal change)
        {
            var changeToGive = new Dictionary<string, int>();
            if (change == 0)
            {
                return changeToGive;
            }

            var availableSet = options.Where(a => a.CanDispense).OrderByDescending(z => z.Value).SkipWhile(a => a.Value > change);    
            do
            {
                var highestValueItem = availableSet.FirstOrDefault();
                if (highestValueItem == null)
                {
                    break;
                }
                if (changeToGive.ContainsKey(highestValueItem.Name))
                {
                    changeToGive[highestValueItem.Name]++;
                }
                else
                {
                    changeToGive.Add(highestValueItem.Name, 1);
                }
                change -= highestValueItem.Value;
                if (highestValueItem.Value > change)
                {
                    availableSet = options.Where(a => a.CanDispense).OrderByDescending(z => z.Value).SkipWhile(a => a.Value > change);
                }
            } while (change > 0 && availableSet.Any());

            if (change > 0)
            {
                var smallestChangeToGive = options.Where(a => a.CanDispense).OrderBy(z => z.Value).FirstOrDefault();
                if (smallestChangeToGive != null)
                {
                    if (changeToGive.ContainsKey(smallestChangeToGive.Name))
                    {
                        changeToGive[smallestChangeToGive.Name]++;
                    }
                    else
                    {
                        changeToGive.Add(smallestChangeToGive.Name, 1);
                    }
                }
            }
            return changeToGive;
        }
    }
}