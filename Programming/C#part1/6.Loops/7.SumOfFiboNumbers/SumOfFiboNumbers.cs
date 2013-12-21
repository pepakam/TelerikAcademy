/*Write a program that reads a number N and calculates 
the sum of the first N members of the sequence of Fibonacci: 
0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.*/

using System;
using System.Numerics;

class SumOfFiboNumbers
{
    static void Main()
    {
        Console.Write("How many fibo numbers do you want to use: ");
        uint n = uint.Parse(Console.ReadLine());
        BigInteger fibo1 = 0U;
        BigInteger fibo2 = 1U;
        BigInteger fibo3;
        BigInteger sum;
        if (n>1)
        {
            sum = 1;
        }
        else
        {
            sum = 0;
        }
        
        for (int i = 2; i < n; i++)
        {
            fibo3 = fibo1 + fibo2;
            fibo1 = fibo2;
            fibo2 = fibo3;
            sum += fibo3;
        }
        Console.WriteLine("The sum of the first {0} fibonacci numbers is {1}", n, sum);
    }
}
