// Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System;

class BinaryRepresentationOfShort
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        short n = short.Parse(Console.ReadLine());
        Console.WriteLine(GetBinary(n));
    }
    static string GetBinaryFromPositive(short number)
    {
        string h = string.Empty;

        while (number > 0)
        {
            h = (number % 2) + h;
            number /= 2;
        }
        return h.PadLeft(16, '0');
    }
    static string GetBinaryFromNegative(short number)
    {
        string h = string.Empty;
        number = (short)(Math.Abs(number) - 1);
        int remainder;
        while (number > 0)
        {
            if (number % 2 == 0)
            {
                remainder = 1;
            }
            else
            {
                remainder = 0;
            }
            h = (remainder) + h;
            number /= 2;
        }
        return h.PadLeft(16, '1');
    }
    static string GetBinary(short number)
    {
        if (number>0)
        {
           return GetBinaryFromPositive(number);
        }
        if (number < 0)
        {
           return GetBinaryFromNegative(number);
        }
        else
        {
           return "0000000000000000";
        }
    }
}
