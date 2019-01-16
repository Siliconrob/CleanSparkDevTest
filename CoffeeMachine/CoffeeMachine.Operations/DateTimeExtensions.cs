using System;

namespace CoffeeMachine.Operations
{
    public static class DateTimeExtensions
    {
        public static bool WithinDateRange(this DateTime timeStamp, DateTime? start, DateTime? end)
        {
            var checkTime = timeStamp.ToUniversalTime();
            if (!IsDateRangeValid(start, end))
            {
                return false;
            }
            if (end.HasValue && end.Value.ToUniversalTime() < checkTime)
            {
                return false;
            }
            return !start.HasValue || start.Value.ToUniversalTime() <= checkTime;
        }

        public static bool IsDateRangeValid(DateTime? start, DateTime? end)
        {
            if (start == null && end == null)
            {
                return true;
            }
            if (start.HasValue && end.HasValue && start.Value.ToUniversalTime() > end.Value.ToUniversalTime())
            {
                return false;
            }
            return true;
        }
    }
}