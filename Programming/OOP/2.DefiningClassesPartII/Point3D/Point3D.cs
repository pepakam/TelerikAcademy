using System.Text;

public struct Point3D
{
    private static readonly Point3D zero = new Point3D(0, 0, 0);

    public static Point3D Zero
    {
        get { return zero; }
    }
           

    public Point3D(int x, int y, int z):this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public override string ToString()
    {
        StringBuilder endText = new StringBuilder();
        endText.AppendFormat("X = {0}" ,this.X.ToString());
        endText.AppendFormat("Y = {0}", this.Y.ToString());
        endText.AppendFormat("Z = {0}", this.Z.ToString());
        return endText.ToString();
    }
}