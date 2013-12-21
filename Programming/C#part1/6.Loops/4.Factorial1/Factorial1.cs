//Write a program that calculates N!/K! for given N and K (1<K<N).
using System;


class Factorial1
{
    static void Main()
    {
        Console.Write(@"Enter ""K"" (K>1): ");
        int k = Convert.ToInt32(Console.ReadLine());
        Console.Write(@"Enter ""N"" (N>K): ");
        int n = Convert.ToInt32(Console.ReadLine());
        decimal factorial1 = 1;
        decimal factorial2 = 1;
        while (true)
        {
            if (n == 1)
            {
                break; 
            }
            factorial1 *=n;
            n--;
            
        }
        while (true)
        {
            if (k == 1)
            {
                break;
            }
            factorial2 *= k;
            k--;

        }
        Console.WriteLine("N!/K!={0}", factorial1 / factorial2);
    }
}
