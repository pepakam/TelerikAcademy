//We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
//    Example: n = 5 (00000101), p=3, v=1  13 (00001101)
//    n = 5 (00000101), p=2, v=0  1 (00000001)

using System;

class SetBitValue
{
    static void Main()
    {
        Console.Write("Please, type number (from 0 to 255): ");
        byte n = byte.Parse(Console.ReadLine());
        Console.Write("Please, type value of bit (0 or 1): ");
        byte v = byte.Parse(Console.ReadLine());
        Console.Write("Please, type position of the bit (from 0 to 7): ");
        byte p = byte.Parse(Console.ReadLine());
        byte number;
        switch (v)
        {
            case 0:
                number = SetBitToZero(n, p);
                Console.WriteLine("n = {0} ({1}), p = {2}, v = {3} -> {4} ({5})", n, Convert.ToString(n, 2).PadLeft(8, '0'), p, v, number, Convert.ToString(number, 2).PadLeft(8, '0'));
                break;
            case 1:
                number = SetBitToOne(n, p);
                Console.WriteLine("n = {0} ({1}), p = {2}, v = {3} -> {4} ({5})", n, Convert.ToString(n, 2).PadLeft(8, '0'), p, v, number, Convert.ToString(number, 2).PadLeft(8, '0'));
                break;
            default: Console.WriteLine("This is program fail!");
                break;
        }

    }
    private static byte SetBitToZero(byte n, byte p) //sets bit at the position p to 0
    {
        byte mask = (byte)~(1 << p);
        byte nAndMask = (byte)(n & mask);
        return nAndMask;
    }
    private static byte SetBitToOne(byte n, byte p) //sets bit at the position p to 1
    {
        byte mask = (byte)(1 << p);
        byte nAndMask = (byte)(n | mask);
        return nAndMask;
    }
}
