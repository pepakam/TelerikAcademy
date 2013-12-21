/*Write a program that calculates the greatest common divisor (GCD) 
of given two numbers. Use the Euclidean algorithm (find it in Internet).*/

using System;

class TheGreatestCommonDivisor
{
    static void Main()
    {
        Console.Write(@"Enter ""a"" : ");
        int a = int.Parse(Console.ReadLine());
        Console.Write(@"Enter ""b"" : ");
        int b = int.Parse(Console.ReadLine());
        int c;
        while (a % b != 0)
        {
            c = a % b;
            a = b;
            b = c;
        }
        Console.WriteLine("GCD is {0}", b);
    }
}