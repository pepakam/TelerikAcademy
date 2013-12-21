//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

using System;

class ExchangeBits
{
    static void Main()
    {
        uint n = 1267887986U;
        uint Exchange3Whith24 = Exchange2Bits(n, 3, 24); // Exchange bit 3 whith bit 24
        uint Exchange4Whith25 = Exchange2Bits(Exchange3Whith24, 4, 25); // Exchange bit 4 whith bit 25
        uint Exchange5Whith26 = Exchange2Bits(Exchange4Whith25, 5, 26); // Exchange bit 5 whith bit 26
        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(Exchange5Whith26, 2).PadLeft(32, '0'));
    }
    private static uint Exchange2Bits(uint n, byte Position1, byte Position2) // exchanges 2 bits of a number
    {
        uint bit1, bit2;
        uint mask;
        uint result, result2;
        bit1 = (uint)((n & (1 << Position1)) >> Position1);
        if (bit1 == 0)
        {
            mask = (uint)~(1 << Position2);
            result = n & mask;
        }
        else
        {
            mask = (uint)(1 << Position2);
            result = n | mask;
        }
        bit2 = (uint)((n & (1 << Position2)) >> Position2);
        if (bit2 == 0)
        {
            mask = (uint)~(1 << Position1);
            result2 = result & mask;
        }
        else
        {
            mask = (uint)(1 << Position1);
            result2 = result | mask;
        }
        return result2;
    }
}
