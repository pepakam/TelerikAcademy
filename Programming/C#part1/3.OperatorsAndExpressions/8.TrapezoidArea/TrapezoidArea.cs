//Write an expression that calculates trapezoid's area by given sides a and b and height h.

using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.Write("Please, type side a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Please, type side b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Please, type height: ");
        double h = double.Parse(Console.ReadLine());
        
        Console.WriteLine("The trapezoid's area is {0}", Trapezoid_Area(a, b, h));
    }

    private static double Trapezoid_Area(double a, double b, double h)
    {
        return (a + b) * h / 2;
    }
}