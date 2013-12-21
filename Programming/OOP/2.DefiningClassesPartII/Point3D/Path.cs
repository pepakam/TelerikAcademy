using System.Collections.Generic;

public class Path
{
    public  readonly  List<Point3D> Points= new List<Point3D>();

    public void AddPoint(Point3D point)
    {
        this.Points.Add(point);
    }

    public void ClearPath()
    {
        this.Points.Clear();
    }
}