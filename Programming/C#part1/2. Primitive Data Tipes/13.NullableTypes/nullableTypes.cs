//Create a program that assigns null values to an integer and to double variables. Try to print them on the console, try to add some values or the null literal to them and see the result.

using System;

class nullableTypes
{
    static void Main()
    {
        int? var1 = null;
        Console.WriteLine("This is the integer with Null value -> " + var1);
        double? var2 = null;
        Console.WriteLine("This is the real number with Null value -> " + var2);
        int var3 = 5;
        Console.WriteLine("{0} + integer with Null value = {1}", var3, (var1.GetValueOrDefault() + var3));
        double var4 = 12.75;
        Console.WriteLine("{0} + real number with Null value = {1}", var4, (var2.GetValueOrDefault() + var4));
    }
}