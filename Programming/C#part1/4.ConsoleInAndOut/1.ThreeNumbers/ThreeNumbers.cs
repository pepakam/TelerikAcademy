//Write a program that reads 3 integer numbers from the console and prints their sum.

using System;

class ThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Please, type 3 numbers: ");
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());
        int number3 = int.Parse(Console.ReadLine());
        int sum = number1 + number2 + number3;
        Console.WriteLine("{0}+{1}+{2} = {3}", number1, number2, number3, sum);
    }
}
