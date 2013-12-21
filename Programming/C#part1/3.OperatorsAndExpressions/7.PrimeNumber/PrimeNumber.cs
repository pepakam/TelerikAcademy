//Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

using System;

class PrimeNumber
{
    static void Main()
    {
        Console.Write("Please, type number from 1 to 100: ");
        uint n = uint.Parse(Console.ReadLine());
        bool isPrime = true;
        for (int devider = 2; devider <= Math.Sqrt(n); devider++)
        {
            if (n % devider == 0)
            {
                isPrime = false;
                break;
            }
        }
        Console.WriteLine("{0} is prime number -> {1}", n, isPrime);
    }
}