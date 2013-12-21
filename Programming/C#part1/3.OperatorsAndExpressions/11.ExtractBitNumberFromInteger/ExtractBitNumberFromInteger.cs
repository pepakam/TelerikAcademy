//Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.

using System;

class ExtractBitNumberFromInteger
{
    static void Main()
    {
        Console.WindowWidth = 100;
        Console.Write("Please, type integer: ");
        int i = int.Parse(Console.ReadLine());
        Console.Write("Please, type position of bit number: ");
        int b = int.Parse(Console.ReadLine());
        Console.WindowWidth = 100;
        Console.WriteLine("i = {0}; b = {1} -> value = {2}", Convert.ToString(i, 2).PadLeft(32, '0'), b,
            Convert.ToString(SetBitToZero(i, b), 2).PadLeft(32, '0'));
    }
    private static int SetBitToZero(int n, int p) //sets the bit at position p to 0
    {
        int mask = ~(1 << p);
        return n & mask; //returns converted number "n" with bit at position "p" = 0;
    }
}
