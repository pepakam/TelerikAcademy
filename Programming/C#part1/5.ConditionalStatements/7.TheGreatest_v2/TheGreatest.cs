//Write a program that finds the greatest of given 5 variables.
using System;

class TheGreatest
{
    static void Main()
    {
        Console.WriteLine("Enter 5 variebles:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());
        double bigger = a;
        if (b > bigger)
        {
            bigger = b;
        }
        if (c > bigger)
        {
            bigger = c;
        }
        if (d > bigger)
        {
            bigger = d;
        }
        if (e > bigger)
        {
            bigger = e;
        }
        Console.WriteLine("The greatest variable is {0}", bigger);
    }
}
