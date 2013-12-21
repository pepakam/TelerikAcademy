//Declare a character variable and assign it with the symbol that has Unicode code 72. Hint: first use the Windows Calculator to find the hexadecimal representation of 72.
using System;

class UnicodeCode
{
    static void Main()
    {
        char char72 = '\u0048';
        Console.WriteLine("Hexadecimal: {0:X} → Char: {1} ", (int)char72, char72);
    }
}