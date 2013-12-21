//Declare an integer variable and assign it with the value 254 in hexadecimal format. Use Windows Calculator to find its hexadecimal representation.

using System;

class Hexadecimal
{
    static void Main()
    {
        int number = 0xFE;
        Console.WriteLine("decimal format: {0} → hexadecimal format: {0:X}", number);
    }
}
