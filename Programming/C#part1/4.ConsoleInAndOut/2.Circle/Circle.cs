//Write a program that reads the radius r of a circle and prints its perimeter and area.

using System;
using System.Globalization;
using System.Threading;

class Circle
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture =
          CultureInfo.InvariantCulture;

        Console.Write("Please, type circle's radius: ");
        double r = double.Parse(Console.ReadLine());
        double p = Perimeter(r);
        double a = Area(r);
        Console.WriteLine("The circle with radius {0:f2} cm, has Perimeter = {1:f2} cm and Area = {2:f2} cm", r, p, a);
    }
    public static double Perimeter(double r, double pi = 3.14159265)
    {
        return 2 * pi * r;
    }
    public static double Area(double r, double pi = 3.14159265)
    {

        return pi * r * r;
    }
}
