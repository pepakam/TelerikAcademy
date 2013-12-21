//Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console.
using System;

class Ascii
{
    static void Main()
    {
        Console.WriteLine("ASCII TABLE \n");
        char[,] asciiArr = new char[16, 8];
        for (int row = 0; row < 16; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                asciiArr[row, col] = (char)(row + 1 + col * 16);
                string display = " ";
                if (char.IsWhiteSpace(asciiArr[row, col]))
                {

                    switch (asciiArr[row, col])
                    {
                        case '\t':
                            display = "\\t";
                            break;
                        case ' ':
                            display = "space";
                            break;
                        case '\n':
                            display = "\\n";
                            break;
                        case '\r':
                            display = "\\r";
                            break;
                        case '\v':
                            display = "\\v";
                            break;
                        case '\f':
                            display = "\\f";
                            break;
                    }
                }
                else
                {
                    display = asciiArr[row, col].ToString();
                }
                Console.Write("{0,-6}", display);
            }
            Console.WriteLine();
        }
    }
}