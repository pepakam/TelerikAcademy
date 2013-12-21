//Write a program to calculate the Nth Catalan number by given N.
using System;

class CatalanNumbers
{
    static void Main()
    {
        bool successParse;
        int n;
        decimal catalanNumber;
        decimal factorial2N = 1;
        decimal factorialNPlus1 = 1;
        do
        {
            Console.Write(@"Enter ""N"": ");
            successParse = int.TryParse(Console.ReadLine(), out n);
        } while (!successParse);


        for (int i = n + 1; i <= 2 * n; i++)
        {
            factorial2N *= i;

        }

        for (int i = 1; i <= n + 1; i++)
        {
            factorialNPlus1 *= i;
        }
        catalanNumber =factorial2N / factorialNPlus1;
        Console.WriteLine("The {0}-th element is: {1}", n, catalanNumber);
    }
}
