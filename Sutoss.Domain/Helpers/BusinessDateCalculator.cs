using System;
using System.Collections.Generic;

namespace Sutoss.Domain.Services.Domain.Helpers
{
    public class BusinessDateCalculator
    {
        public static int DifferenceBetweenDates(DateTime from, DateTime to, List<DateTime> Holidays)
        {
            int counter = 0;
            while (from.Date != to.Date)
            {
                from = AddBusinessDays(from, Holidays, 1);
                counter++;
            }
            return counter;
        }
        public static DateTime AddBusinessDays(DateTime from, List<DateTime> Holidays, int quantity)
        {
            if (quantity < 0)
            {
                throw new InvalidOperationException("Quantity must be greater than 0");
            }
            if (quantity == 0)
            {
                return from;
            }
            else
            {
                if (Holidays == null && Holidays.Count == 0)
                {
                    switch (from.AddDays(1).DayOfWeek)
                    {
                        case DayOfWeek.Saturday:
                            return AddBusinessDays(from.AddDays(1), Holidays, quantity);
                        case DayOfWeek.Sunday:
                            return AddBusinessDays(from.AddDays(1), Holidays, quantity);
                        default:
                            quantity--;
                            return AddBusinessDays(from.AddDays(1), Holidays, quantity);
                    }
                }
                else
                {
                    if (Holidays.Contains(from.AddDays(1)))
                    {
                        return AddBusinessDays(from.AddDays(1), Holidays, quantity);
                    }
                    else
                    {
                        switch (from.AddDays(1).DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                return AddBusinessDays(from.AddDays(1), Holidays, quantity);
                            case DayOfWeek.Sunday:
                                return AddBusinessDays(from.AddDays(1), Holidays, quantity);
                            default:
                                quantity--;
                                return AddBusinessDays(from.AddDays(1), Holidays, quantity);

                        }
                    }
                }
            }
            throw new InvalidOperationException("You could not add days");
        }
    }
}
