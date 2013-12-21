using System;
using System.Text;

class SubBuilderTest
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("Някой");

        StringBuilder subBuilder = sb.SubBuilder(1,3);

        Console.WriteLine(subBuilder);
    }
}
