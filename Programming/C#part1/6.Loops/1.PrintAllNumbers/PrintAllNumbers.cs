//Write a program that prints all the numbers from 1 to N.

using System;

    class PrintAllNumbers
    {
        static void Main()
        {
            Console.Write("Please, type number(n>0): ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
