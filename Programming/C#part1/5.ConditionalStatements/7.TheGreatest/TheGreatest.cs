//Write a program that finds the greatest of given 5 variables.

using System;

class TheGreatest
{
    static void Main()
    {
        double[]  v = new double[5];
        Console.WriteLine("Please, type 5 variables: ");
        v[0] = double.Parse(Console.ReadLine());
        v[1] = double.Parse(Console.ReadLine());
        v[2] = double.Parse(Console.ReadLine());
        v[3] = double.Parse(Console.ReadLine());
        v[4] = double.Parse(Console.ReadLine());
        double theGreatest;
        Array.Sort(v);
        theGreatest = v[v.Length - 1];
        Console.WriteLine("The greatest variable is " + theGreatest);
    }
}
