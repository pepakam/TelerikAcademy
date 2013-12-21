//Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

using System;

class Factorial2
{
    static void Main()
    {
        Console.Write(@"Enter ""N"" (N>1): ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write(@"Enter ""K"" (K>N): ");
        int k = Convert.ToInt32(Console.ReadLine());
        int p = k - n;
        decimal factorial1 = 1;
        decimal factorial2 = 1;
        decimal factorial3 = 1;
        while (n>=1)
        {
            factorial1 *= n;
            n--;
        }
        while (k >= 1)
        {
            factorial2 *= k;
            k--;
        }
        while (p >= 1)
        {
            factorial3 *= p;
            p--;
        }
        Console.WriteLine("N!*K!/(K-N)!={0}", (factorial1 * factorial2) / (factorial3));
    }
}
