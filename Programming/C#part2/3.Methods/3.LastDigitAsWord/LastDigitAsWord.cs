// Write a method that returns the last digit of given integer as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".

using System;

class LastDigitAsWord
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Last digit is {0}", LastDigitAsEnglishWord(n));
    }
    private static string LastDigitAsEnglishWord(int number)
    {
        int lastDigit = number % 10;
        string digitAsWord = string.Empty;
        switch (lastDigit)
        {
            case 1: digitAsWord = "one";
                break;
            case 2: digitAsWord = "two";
                break;
            case 3: digitAsWord = "three";
                break;
            case 4: digitAsWord = "four";
                break;
            case 5: digitAsWord = "five";
                break;
            case 6: digitAsWord = "six";
                break;
            case 7: digitAsWord = "seven";
                break;
            case 8: digitAsWord = "eight";
                break;
            case 9: digitAsWord = "nine";
                break;
            default: digitAsWord = "zero";
                break;
        }
        return digitAsWord;
    }
}
