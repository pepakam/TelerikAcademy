// Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

class HexadecimalToBinary
{
    static void Main()
    {
        Console.Write("Please, type hexadecimal number: ");
        string hex = Console.ReadLine();
        Console.WriteLine(HexToBin(hex));
    }
    static string HexToBin(string hexadecimal)
    {
        string binary = string.Empty;
        string binaryPart = string.Empty;
        for (int i = 0; i < hexadecimal.Length; i++)
        {           
            switch (hexadecimal[i])
            {
                case '0': binaryPart = "0000";
                    break;
                case '1': binaryPart = "0001";
                    break;
                case '2': binaryPart = "0010";
                    break;
                case '3': binaryPart = "0011";
                    break;
                case '4': binaryPart = "0100";
                    break;
                case '5': binaryPart = "0101";
                    break;
                case '6': binaryPart = "0110";
                    break;
                case '7': binaryPart = "0111";
                    break;
                case '8': binaryPart = "1000";
                    break;
                case '9': binaryPart = "1001";
                    break;
                case 'A': binaryPart = "1010";
                    break;
                case 'B': binaryPart = "1011";
                    break;
                case 'C': binaryPart = "1100";
                    break;
                case 'D': binaryPart = "1101";
                    break;
                case 'E': binaryPart = "1110";
                    break;
                case 'F': binaryPart = "1111";
                    break;
                default: binaryPart = "0000";
                    break;
            }
             binary += binaryPart;
        }
        return binary;
    }
}
