//Write an expression that calculates rectangle’s area by given width and height.

using System;

class RectanglesArea
{
    static void Main()
    {
        Console.Write("Please, type rectangle’s width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Please, type rectangle’s height: ");
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine("Rectangle’s area is " + RectArea(width, height));
    }

    private static double RectArea(double a, double b)
    {
        return a * b;
    }
}
