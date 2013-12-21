// Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

class Max
{
    private static int GetMax(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
    static void Main()
    {
        int[] numbers = new int[3];
        Console.WriteLine("Enter 3 numbers:");
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        int biggest = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            biggest = GetMax(biggest, numbers[i]);
        }
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Max = {0}", biggest);
    }
}
