// Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

class BinaryToHexadecimal
{
    static void Main()
    {
        Console.Write("Please, type binary number: ");
        string binaryNumber = Console.ReadLine();
        Console.WriteLine(BinToHex(binaryNumber));
    }
    static string BinToHex(string binary)
    {
        string hex = string.Empty;
        int reminder = binary.Length % 4;
        if (reminder != 0)
        {
            binary = binary.PadLeft((binary.Length / 4 + 1) * 4, '0');
        }
        for (int i = 0; i < binary.Length; i += 4)
        {
            string binaryPart = binary.Substring(i, 4);
            hex += string.Format("{0:X}", Convert.ToByte(binaryPart, 2));
        }
        return hex;
    }
}
