//Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1  false.
using System;

class BitAtPositionP
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Please, type position of the bit: ");
        int p = int.Parse(Console.ReadLine()); 
        bool is1 = (CheckBit(v, p) == 1); // checks if bit at position p is 1
        Console.WriteLine("v = {0}, p = {1} -> {2}", Convert.ToString(v, 2).PadLeft(32, '0'), p, is1);
    }
    private static int CheckBit(int n, int p) //returns bit of number "n" at a position "p" (1 or 0)
    {
        int mask = 1 << p;
        int nAndMask = n & mask;
        return nAndMask >> p;
    }
}
