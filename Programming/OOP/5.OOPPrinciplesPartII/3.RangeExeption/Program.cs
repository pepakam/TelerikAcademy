using System;

class Program
{
    static void Main()
    {
        try
        {
            int start = 1;
            int end = 100;
            int number = 101;

            if (!(start < number && number < end))
            {
                throw new InvalidRangeException<int>(start, end);
            }
        }
        catch (InvalidRangeException<int> exception)
        {
            Console.WriteLine(exception.Message);
            Console.WriteLine("The range is from {0} to {1}", exception.Start, exception.End);

        }
        Console.WriteLine(new string('*',70));

        try
        {
            DateTime start = new DateTime(1980, 1, 1);
            DateTime end = new DateTime(2013, 12, 31);

            DateTime today = new DateTime(2013, 10, 29);

            if (start < today && today < end)
            {
                throw new InvalidRangeException<DateTime>(start, end);
            }
        }
        catch (InvalidRangeException<DateTime> exception)
        {
            Console.WriteLine(exception.Message);
            Console.WriteLine("The range is from {0:d} to {1:d}", exception.Start, exception.End);
        }
        Console.WriteLine(new string('*', 70));
    }
}
