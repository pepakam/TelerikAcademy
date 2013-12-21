//Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

using System;

class ThirdDigit
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        int n = int.Parse(Console.ReadLine());
        bool isSeven;
        if ((n / 100) % 10 == 7)
        {
            isSeven = true;
        }
        else
        {
            isSeven = false;
        }
        Console.WriteLine("Third digit is 7 -> " + isSeven);
    }
}
