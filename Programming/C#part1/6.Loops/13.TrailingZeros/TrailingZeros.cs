/* Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
	N = 10  N! = 3628800  2
	N = 20  N! = 2432902008176640000  4
	Does your program work for N = 50 000?
	Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!*/

using System;
using System.Numerics;

class TrailingZeros
{
    static void Main()
    {
        Console.Write(@"Enter number""N"": ");
        int n = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;
        int devider = 5;
        decimal sum=0;
        string zero;
        
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            sum += n / devider;
            devider *= 5;
        }
        Console.WriteLine("{0}! = {1}", n, factorial);
        if (sum !=1)
        {
            zero = "zeros";
        }
        else
        {
            zero = "zero";
        }
        Console.WriteLine("There is {0} traling {1} at the and of the {2}!", sum, zero, n);
    }
}
