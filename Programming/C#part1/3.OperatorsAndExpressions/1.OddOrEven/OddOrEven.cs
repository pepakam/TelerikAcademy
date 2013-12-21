//Write an expression that checks if given integer is odd or even.

using System;

class OddOrEven
{
    static void Main()
    {
        Console.Write("Type Number: ");
        int n = int.Parse(Console.ReadLine());

        string evenOrOdd = "";
        if (n%2==0)
        {
            evenOrOdd = "even";
        }
        else
        {
            evenOrOdd = "odd";
        }
        Console.WriteLine("{0} is {1}", n, evenOrOdd);
    }
}
