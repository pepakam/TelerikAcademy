//Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

using System;

class ThirdBit
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        int n = int.Parse(Console.ReadLine()); // number
        Console.Write("Please, type position of the bit: ");
        int whichBit = int.Parse(Console.ReadLine());// position of bit
        //int whichBit = 3; 

        Console.WriteLine("Bit {0} of the number {1} is {2} ", whichBit, Convert.ToString(n, 2).PadLeft(32, '0'), 
            CheckBit(n, whichBit));
    }
    private static int CheckBit(int n, int p) //returns bit of number "n" at a position "p" (1 or 0)
    {
        int mask = 1 << p;
        int nAndMask = n & mask;
        return nAndMask >> p;
    }
}