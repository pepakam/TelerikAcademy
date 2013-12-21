// Write a method that reverses the digits of given decimal number. Example: 256  652

using System;

class ReverseTheDigits
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        decimal number = decimal.Parse(Console.ReadLine());
        Reverse(number);
    }
    static void Reverse(decimal num)
    {
        string number = num.ToString();
        string[] newNumber = new string[number.Length];
        if (num > 0)
        {
            for (int i = 0; i < number.Length; i++)
            {
                newNumber[i] = number[number.Length - 1 - i].ToString();
            }
        }
        else
        {
            newNumber[0] = number[0].ToString();
            for (int i = 1; i < number.Length; i++)
            {
                newNumber[i] = number[number.Length - 1 - i].ToString();
            }
        }
        foreach (var digit in newNumber)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
    }

}
