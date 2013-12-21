//Write program that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.

using System;

class NameOfDigit
{
    static void Main()
    {
        Console.Write("Please, type a digit(0-9): ");
        int digit = int.Parse(Console.ReadLine());
        string nameOfDigit;
        switch (digit)
        {
            case 0: 
                nameOfDigit="Zero";
                break;
            case 1:
                nameOfDigit = "One";
                break;
            case 2:
                nameOfDigit = "Two";
                break;
            case 3:
                nameOfDigit = "Three";
                break;
            case 4:
                nameOfDigit = "Four";
                break;
            case 5:
                nameOfDigit = "Five";
                break;
            case 6:
                nameOfDigit = "Six";
                break;
            case 7:
                nameOfDigit = "Seven";
                break;
            case 8:
                nameOfDigit = "Eight";
                break;
            case 9:
                nameOfDigit = "Nine";
                break;
            default:
                nameOfDigit = "This number is not a digit!";
                break;     
        }
        Console.WriteLine(nameOfDigit);
    }
}
