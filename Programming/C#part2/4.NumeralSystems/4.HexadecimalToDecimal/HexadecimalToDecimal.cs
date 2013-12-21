//Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class HexadecimalToDecimal
{
    static void Main()
    {
        Console.Write("Please, type hexadecimal number: ");
        string hex = Console.ReadLine();
        Console.WriteLine(HexToDec(hex));
    }
    static int HexToDec(string hexadecimal)
    {
        int sum = 0;
        for (int i = hexadecimal.Length - 1; i >= 0; i--)
        {
            int rem;
            switch (hexadecimal[i])
            {
                case 'A': rem = 10;
                    break;
                case 'B': rem = 11;
                    break;
                case 'C': rem = 12;
                    break;
                case 'D': rem = 13;
                    break;
                case 'E': rem = 14;
                    break;
                case 'F': rem = 15;
                    break;
                default: rem = hexadecimal[i]-48;
                    break;
            }
            sum += rem * (int)Math.Pow(16, (hexadecimal.Length - 1 - i));

        }
        return sum;
    }
}