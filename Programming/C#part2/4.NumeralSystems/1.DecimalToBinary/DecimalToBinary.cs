// Write a program to convert decimal numbers to their binary representation.

using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        int n = int.Parse(Console.ReadLine());
        DecToByn(n);
    }

    static void DecToByn(int number)
    {
        List<int> remainder = new List<int>();

        while (number > 0)
        {
            remainder.Add(number % 2);
            number /= 2;
        }
        remainder.Reverse();
        foreach (var element in remainder)
        {
            Console.Write(element);
        }
        Console.WriteLine();
    }
}
