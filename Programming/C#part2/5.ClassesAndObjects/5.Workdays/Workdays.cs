// Write a method that calculates the number of workdays between today and given date, passed as parameter. Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

using System;

class WorkDays
{

    static DateTime[] holidays = { new DateTime(2013, 3, 5), new DateTime(2013, 4, 4), new DateTime(2013, 5, 5), new DateTime(2013, 6, 6), new DateTime(2013, 7, 7) };

    static int FilterHolidays(DateTime start, DateTime end, int result)
    {
        foreach (DateTime holiday in holidays)
            if (start <= holiday && holiday <= end &&
                !(holiday.DayOfWeek == DayOfWeek.Saturday || holiday.DayOfWeek == DayOfWeek.Sunday))
                result--;

        return result;
    }
    static void TrimPeriod(DateTime start, DateTime end)
    {
        //if the period starts with the weekend
        if (start.DayOfWeek == DayOfWeek.Saturday) start = start.AddDays(2);
        if (start.DayOfWeek == DayOfWeek.Sunday) start = start.AddDays(1);

        // Trim if it ends with a weekend
        if (end.DayOfWeek == DayOfWeek.Saturday) end = end.AddDays(-1);
        if (end.DayOfWeek == DayOfWeek.Sunday) end = end.AddDays(-2);
    }
    static int GetWorkDays(DateTime start, DateTime end)
    {
        if (end < start) return GetWorkDays(end, start); // Swap if end is before start
        TrimPeriod(start, end);
        int offset = (int)(end - start).TotalDays + 1; // Find days between
        int result = offset / 7 * 5 + offset % 7; // Split in weeks with five working days and add remaining
        return FilterHolidays(start, end, Math.Max(result, 0)); // If start and end were in the same weekend
    }


    static void Main()
    {
        Console.WriteLine(GetWorkDays(new DateTime(2013, 1, 1), DateTime.Today));
    }
}
