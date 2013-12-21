// Write methods that calculate the surface of a triangle by given:
// Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

class SurfaceOfATriangle
{
    static double TriangleSurface(double a, double h)
    {
        return ((a * h) / 2);
    }
    static double TriangleSurface(double a, double b, double c)
    {
        double p = ((a + b + c) / 2);
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    static double TriangleSurface(double a, double b, int alfa)
    {
        double pi = Math.PI;
        double sin = Math.Sin((alfa * pi) / 180);
        return ((a * b * sin) / 2);
    }
    static void Main()
    {
        Console.WriteLine("Choose from 1 to 3.");
        int choice = int.Parse(Console.ReadLine());
        double valueOne;
        double valueTwo;
        double valueThree;
        int angle;
        double surface;
        if (choice == 1)
        {
            Console.Write("Enter side: ");
            valueOne = double.Parse(Console.ReadLine());
            Console.Write("Enter altitude: ");
            valueTwo = double.Parse(Console.ReadLine());
            surface = TriangleSurface(valueOne, valueTwo);
            Console.WriteLine("The surface is: {0}", surface);
        }
        else if (choice == 2)
        {
            Console.Write("Enter side: ");
            valueOne = double.Parse(Console.ReadLine());
            Console.Write("Enter side: ");
            valueTwo = double.Parse(Console.ReadLine());
            Console.Write("Enter side: ");
            valueThree = double.Parse(Console.ReadLine());
            surface = TriangleSurface(valueOne, valueTwo, valueThree);
            Console.WriteLine("The surface is: {0}", surface);
        }
        else if (choice == 3)
        {
            Console.Write("Enter side: ");
            valueOne = double.Parse(Console.ReadLine());
            Console.Write("Enter side: ");
            valueTwo = double.Parse(Console.ReadLine());
            Console.Write("Enter angle: ");
            angle = int.Parse(Console.ReadLine());
            surface = TriangleSurface(valueOne, valueTwo, angle);
            Console.WriteLine("The surface is: {0}", surface);
        }
        else
        {
            Console.WriteLine("Invalid Choice !!!");
        }
    }

}
