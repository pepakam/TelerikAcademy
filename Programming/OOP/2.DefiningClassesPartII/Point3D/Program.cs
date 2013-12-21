using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("# Testing distance");

        Console.WriteLine("Distance: {0}", Distance.Calc(new Point3D(1, 2, 13), Point3D.Zero));

        Console.WriteLine("# Testing path");
        Point3D firstPoint = new Point3D(1,2,3);
        Point3D secondPoint = new Point3D(2,4,2);
        Point3D thirdPoint = new Point3D(3,4,5);
        Path firstPath = new Path();
        firstPath.AddPoint(firstPoint);
        firstPath.AddPoint(secondPoint);
        firstPath.AddPoint(thirdPoint);
        PathStorage.Write(firstPath);
        List<Path> pathList = PathStorage.Read();
        foreach (var path in pathList)
        {
            Console.WriteLine("-----Path Start-------");
            foreach (var pointers in path.Points)
            {
                Console.WriteLine("{0}", pointers);
            }

            Console.WriteLine("-----Path End-------");
        }


        //Point3D point = new Point3D(1,2,3);
        //Console.WriteLine("The coordinates of the point are: ({0},{1},{2})", point.X, point.Y, point.Z);
    }
}
