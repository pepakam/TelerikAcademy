//Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. If an invalid number or non-number text is entered, the method should throw an exception. Using this method write a program that enters 10 numbers:
//            a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class TenNumbers
{
    public static int ReadNumber(int start, int end)
    {
        Console.Write("Please, type number: ");
        int n = int.Parse(Console.ReadLine());
        if (!(start < n && n < end))
        {
            throw new ArgumentOutOfRangeException();
        }
        return n;
    }

    static void Main()
    {
        int min = 1;
        int max = 100;
        for (int i = 0; i < 10; i++)
        {
            min = ReadNumber(min, max);
            

        }
    }
}