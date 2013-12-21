// Write a program to convert binary numbers to their decimal representation.

using System;

class BynaryToDecimal
{
    static void Main()
    {
        Console.Write("Please, type binary number (32 digits): ");
        string binary = Console.ReadLine();
        Console.WriteLine(BinToDec(binary));
    }
    static int BinToDec(string binary)
    {
        int sum = 0;
        for (int i = binary.Length - 1; i >= 0; i--)
        {            
            if (binary[i]=='1')
            {
                sum += (int)Math.Pow(2,(binary.Length - 1-i));
            }
        }
        return sum;
    }
}
