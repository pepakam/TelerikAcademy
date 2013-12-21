//Which of the following values can be assigned to a variable of type float and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?

using System;

class FloatVsDouble
{
    static void Main()
    {
        double val1 = 34.567839023;
        Type type1 = val1.GetType();
        float val2 = 12.345f;
        Type type2 = val2.GetType();
        double val3 = 8923.1234857;
        Type type3 = val3.GetType();
        float val4 = 3456.091f;
        Type type4 = val4.GetType();
        Console.WriteLine("{0} is {1}\n", val1, type1);
        Console.WriteLine("{0} is {1}\n", val2, type2);
        Console.WriteLine("{0} is {1}\n", val3, type3);
        Console.WriteLine("{0} is {1}\n", val4, type4);
    }
}