//Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

using System;

class DivisionBy5
{
    static void Main()
    {
        Console.WriteLine("Please, type 2 positive numbers: ");
        uint n1 = uint.Parse(Console.ReadLine());
        uint n2 = uint.Parse(Console.ReadLine());
        uint p = 0;
        for (uint i =n1; i <= n2; i++)
        {
            if (i % 5 == 0)
            {
                p++;
            }
        }
        Console.WriteLine("p({0},{1}) = {2}", n1, n2, p);
    }
}
