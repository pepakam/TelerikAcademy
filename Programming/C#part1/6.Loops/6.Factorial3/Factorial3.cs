//Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN

using System;

class Factorial3
{
    static void Main()
    {
        Console.Write(@"Enter ""N"": ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write(@"Enter ""X"": ");
        int x = int.Parse(Console.ReadLine());
        int k = 1;
        long factorial = 1L;
        double S = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= k;
            S += factorial / Math.Pow(x, i);
            k++;
        }
        Console.WriteLine("Sum = {0}", S);
    }
}