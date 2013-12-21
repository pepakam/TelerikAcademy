//Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
using System;

class Sequence
{
    static void Main()
    {
        int i = 2;
        while (i <= 12)
        {
            if (i % 2 != 0)
            {
                i *= -1;
            }
            Console.Write(i + " ");
            i = Math.Abs(i) + 1;
        }

    }
}
