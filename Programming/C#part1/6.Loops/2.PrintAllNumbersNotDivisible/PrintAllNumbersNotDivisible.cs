//Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

using System;

class PrintAllNumbersNotDivisible
{
    static void Main()
    {
        Console.Write("Please, type number(n>0): ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            bool cond = (i % 3 == 0 && i % 7 == 0);
            if (!cond)
            {
                Console.WriteLine(i);
            }
        }
    }
}
