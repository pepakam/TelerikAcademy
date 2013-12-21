using System;

class ThirdDigit_v2
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        int number = int.Parse(Console.ReadLine());
        double howManyDigits = Math.Floor(Math.Log10(number) + 1); // how many digits has the number
        Console.Write("Please, type which place of digit (from right to left, starting from 1 to {0}): ", howManyDigits);
        int whichDigit = int.Parse(Console.ReadLine());
        Console.Write("Please, type value of digit, which you want to check for: ");
        int valueOfDigit = int.Parse(Console.ReadLine());
        bool isTrue;
        if (CheckDigit(number, whichDigit) == valueOfDigit)
        {
            isTrue = true;
        }
        else
        {
            isTrue = false;
        }
        Console.WriteLine("Third digit is {0} -> {1}", valueOfDigit, isTrue);
    }

    private static int CheckDigit(int number, int placeOfDigit) //returns value of the n digit
    {
        int k = 1;
        for (int i = 2; i <= placeOfDigit; i++)
        {
            k *= 10;
        }
        return (number / k) % 10;   
    }
}
