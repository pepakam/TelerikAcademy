//Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

using System;

class PointWithinTheCircleAndOutOfTheRectangle
{
    static void Main()
    {
        Console.Write("Please, type \"x\" coordinate: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Please, type \"y\" coordinate: ");
        double y = double.Parse(Console.ReadLine());
        double radius = 3;
        bool condition;
        if (Diagonal(x, y) < radius && OutsideOfTheRectangle(x, y))
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        Console.WriteLine("The point({0},{1}) is within the circle and out of the rectangle -> {2}", x, y, condition);

    }
    private static double Diagonal(double x, double y) //returns length from center of the circe to point
    {
        return Math.Sqrt((x + 1) * (x + 1) + (y + 1) * (y + 1));

    }
    private static bool OutsideOfTheRectangle(double x, double y) //checks point(x,y) if it is out of the rectangle
    {
        double top = 1;
        double left = -1;
        double width = 6;
        double height = 2;
        double xLeft = left;
        double xRight = left + width;
        double yTop = top;
        double yBottom = top - height;
        bool xInside = (xLeft <= x) && (x <= xRight);
        bool yInside = (yTop >= y) && (y >= yBottom);
        bool inside = xInside && yInside;
        return !inside;
    }
}
