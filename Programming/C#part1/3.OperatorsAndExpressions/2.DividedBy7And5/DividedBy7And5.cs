//Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

using System;

class DividedBy7And5
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        int n = int.Parse(Console.ReadLine());
        if (n % 7 == 0 && n % 5 == 0)
        {
            Console.WriteLine(n+" can be divided by 7 and 5");
        }
        else
        {
            Console.WriteLine(n + " can not be divided by 7 and 5");
        }
    }
}
