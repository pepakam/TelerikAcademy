// Write a program to convert decimal numbers to their hexadecimal representation.


using System;
using System.Collections.Generic;

class DecimaToHexadecimal
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        int n = int.Parse(Console.ReadLine());
        DecToHex(n);
    }

    static void DecToHex(int number)
    {
        List<char> remainder = new List<char>();

        while (number > 0)
        {
            int rem = number % 16;
            char charRem;
            switch (rem)
            {
                case 10: charRem = 'A';
                    break;
                case 11: charRem = 'B';
                    break;
                case 12: charRem = 'C';
                    break;
                case 13: charRem = 'D';
                    break;
                case 14: charRem = 'E';
                    break;
                case 15: charRem = 'F';
                    break;
                default: charRem = (char)(rem+48);
                    break;
            }
            remainder.Add(charRem);
            number /= 16;
        }
        remainder.Reverse();
        foreach (var element in remainder)
        {
            Console.Write(element);
        }
        Console.WriteLine();
    }
}
