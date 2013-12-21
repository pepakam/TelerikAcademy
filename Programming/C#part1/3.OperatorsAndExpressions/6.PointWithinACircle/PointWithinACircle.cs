//Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

using System;

class PointWithinACircle
{
    static void Main()
    {
        Console.Write("Please, type x coordinate: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Please, type y coordinate: ");
        double y = double.Parse(Console.ReadLine());
        int radius = 5;
        bool isWithin = radius >= Diagonal(x, y);
        Console.WriteLine("The point({0},{1}) is within a circle(0,5) -> {2}", x, y, isWithin);
    }
    private static double Diagonal(double x, double y) //returns length from 0,0 coordinates to point
    {
        double d = Math.Sqrt(x * x + y * y);
        return d;
    }
}
