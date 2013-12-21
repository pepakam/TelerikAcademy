//Write a program that finds the biggest of three integers using nested if statements.
using System;

class TheBiggestNumber
{
    static void Main()
    {
        int[] numbers = new int[3];
        Console.Write("Please, type 3 numbers: ");
        numbers[0] = int.Parse(Console.ReadLine());
        numbers[1] = int.Parse(Console.ReadLine());
        numbers[2] = int.Parse(Console.ReadLine());
        int theBiggest;
        if (numbers[0] > numbers[1])
        {
            if (numbers[0] > numbers[2])
            {
                theBiggest = numbers[0];
            }
            else
            {
                theBiggest = numbers[2];
            }
        }
        else
        {
            if (numbers[1] > numbers[2])
            {
                theBiggest = numbers[1];
            }
            else
            {
                theBiggest = numbers[2];
            }
        }
        Console.WriteLine("The biggest number is " + theBiggest);
    }
}