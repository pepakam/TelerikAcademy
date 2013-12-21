//Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

using System;

class ExchangeValues
{
    static void Main()
    {
        Console.Write("Please, type first number: ");
        int first = int.Parse(Console.ReadLine());
        Console.Write("Please, type second number: ");
        int second = int.Parse(Console.ReadLine());
        int third = first;
        if (first > second)
        {
            first = second;
            second = third;
        }
        Console.WriteLine("First = {0}; Second = {1}", first, second);
    }
}
