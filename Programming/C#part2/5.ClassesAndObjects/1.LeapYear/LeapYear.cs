// Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.
using System;

class LeapYear
{
    static void Main()
    {
        int year = DateTime.Now.Year;
        Console.WriteLine("{0} is leap year -> {1}", year, DateTime.IsLeapYear(year));
    }
}
