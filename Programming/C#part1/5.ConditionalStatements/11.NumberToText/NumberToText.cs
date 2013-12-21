/* Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	0  "Zero"
	273  "Two hundred seventy three"
	400  "Four hundred"
	501  "Five hundred and one"
	711  "Seven hundred and eleven"*/

using System;

class NumberToText
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int n = int.Parse(Console.ReadLine());
        string[] ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", 
     "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        string asText;
        if (n == 0)
        {
            Console.WriteLine("Zero");
        }
        else if (n >= 1 && n <= 19)
        {
            asText = ones[n];
            Console.WriteLine(asText);
        }
        else if (n >= 20 && n <= 99)
        {
            asText = tens[n / 10 - 2] + " " + ones[(n % 10)];
            Console.WriteLine(asText);
        }
        else if (n >= 100 && n <= 199)
        {
            if (n % 100 / 10 > 1)
            {
                asText = "One Hundred " + tens[n % 100 / 10 - 2] + " " + ones[(n % 10)];
                Console.WriteLine(asText);
            }
            else if (n % 100 / 10 < 2 && n % 100 % 10 > 0)
            {
                asText = "One Hundred and " + ones[(n % 100)];
                Console.WriteLine(asText);
            }
            else
            {
                asText = "One Hundred";
                Console.WriteLine(asText);
            }
        }
        else if (n >= 200 && n <= 999)
        {
            if (n % 100 / 10 > 1)
            {
                asText = ones[n / 100] + " Hundreds " + tens[n % 100 / 10 - 2] + " " + ones[(n % 10)];
                Console.WriteLine(asText);
            }
            else if (n % 100 / 10 < 2 && n % 100 % 10 > 0)
            {
                asText = ones[n / 100] + " Hundreds and " + ones[(n % 100)];
                Console.WriteLine(asText);
            }
            else
            {
                asText = ones[n / 100] + " Hundreds";
                Console.WriteLine(asText);
            }
        }
        else
        {
            Console.WriteLine("The number is out of range!");
        }

    }
}