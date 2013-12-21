using System;

class SurfaceTest
{
    static void Main()
    {
        Shape[] shapes = new Shape[]
        {
            new Rectangle(5,7),
            new Triangle(3,3),
            new Circle(5)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine( "The surface of the {0} is {1:0.00}", shape.GetType(), shape.CalculateSurface());
        }
    }
}