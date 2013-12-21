//Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

using System;
using System.Threading;
using System.Globalization;

class QuadraticEquation
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.WriteLine("Please, type coefficients \"a\",\"b\" and \"c\" of a quadratic equation ax2+bx+c=0: ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        SolveQuadratic(a, b, c);
    }

    private static void SolveQuadratic(double a, double b, double c)
    {
        double val = b * b - 4 * a * c;
        double x1, x2;

        switch (Math.Sign(val))
        {
            case 1:
                x1 = (-b + Math.Sqrt(val)) / (2 * a);
                x2 = (-b - Math.Sqrt(val)) / (2 * a);
                Console.WriteLine("Two real roots: {0:f4} or {1:f4}", x1, x2);
                break;
            case -1:
                Console.WriteLine("There is no real root");
                break;
            default:
                x1 = (-b + Math.Sqrt(val)) / (2 * a);
                Console.WriteLine("One real root: {0:f4}", x1);
                break;
        }
    }
}
