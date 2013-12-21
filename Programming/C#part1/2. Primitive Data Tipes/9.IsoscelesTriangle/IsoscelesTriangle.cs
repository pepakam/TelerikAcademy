//Write a program that prints an isosceles triangle of 9 copyright symbols ©. Use Windows Character Map to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly.

using System;

class IsoscelesTriangle
{
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        int cols = rows * 2 - 1;
        int firstPosition = rows;
        int lastPosition = rows;
        //Console.OutputEncoding = System.Text.Encoding.UTF8;
        char symbol = '\u00A9';
        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= cols; j++)
            {
                if (j >= firstPosition && j <= lastPosition)
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine();
            firstPosition--;
            lastPosition++;
        }
    }
}

