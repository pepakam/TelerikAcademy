//Write a program to print the numbers 1, 101 and 1001.

using System;

class PrintNumbers
{
    static void Main()
    {
        int number = 1;
        int k = 100;
        do
        {
            Console.WriteLine(number);
            number += k;
            k *= 9;
        } while (number<=1001);
    }
}
