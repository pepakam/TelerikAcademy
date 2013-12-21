//* Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

using System;

class ExchangesBitsCycle
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        uint n = uint.Parse(Console.ReadLine());
        //uint n = 1267887986U;
        Console.Write("Please, type starting bit's position \"p\" (from 0 to 30) of the first set: ");
        byte p = byte.Parse(Console.ReadLine());
        //byte p = 3;
        Console.Write("Please, type starting bit's position \"q\" (from {0} to 31) of the second set: ", (p+1));
        byte q = byte.Parse(Console.ReadLine());
        //byte q = 24;
        Console.Write("Please, type how many bits do you want to swap (from 1 to {0}): ", Math.Min((32-q),(q-p)));
        byte k = byte.Parse(Console.ReadLine());
        //byte k = 3; // how many bits do you want to exchange
        int lastP = p + k - 1;
        uint number = n;

        while (p <= lastP)
        {
            number = Exchange2Bits(number, p, q);
            p++;
            q++;
        }
        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0') + " -> ");
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
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
