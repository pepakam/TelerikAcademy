//Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;

class Fibonacci
{
    static void Main()
    {
        checked
        {
            decimal firstFibo = 0m;
            decimal secondFibo = 1m;
            decimal fibo = firstFibo + secondFibo;
            Console.Write("{0}, {1}", firstFibo, secondFibo);
            for (int i = 2; i < 100; i++)
            {
                fibo = firstFibo + secondFibo;
                firstFibo = secondFibo;
                secondFibo = fibo;

                Console.Write(", {0}", fibo);
            }
            Console.WriteLine();
        }
    }
}
