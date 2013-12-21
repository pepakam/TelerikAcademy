//Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.

using System;

class FiveVariables
{
    static void Main()
    {
        ushort val1 = 52130;
        Type type1 = val1.GetType();
        sbyte val2 = -115;
        Type type2 = val2.GetType();
        int val3 = 4825932;
        Type type3 = val3.GetType();
        byte val4 = 97;
        Type type4 = val4.GetType();
        short val5 = -10000;
        Type type5 = val5.GetType();
        Console.WriteLine("{0} is {1}\n", val1, type1);
        Console.WriteLine("{0} is {1}\n", val2, type2);
        Console.WriteLine("{0} is {1}\n", val3, type3);
        Console.WriteLine("{0} is {1}\n", val4, type4);
        Console.WriteLine("{0} is {1}\n", val5, type5);
    }
}
