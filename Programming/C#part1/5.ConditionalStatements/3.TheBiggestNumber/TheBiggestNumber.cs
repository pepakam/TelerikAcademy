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
        Array.Sort(numbers);
        Console.WriteLine("The biggest number is " + numbers[numbers.Length-1]);

    }
}
