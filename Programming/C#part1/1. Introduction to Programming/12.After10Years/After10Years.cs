//* Write a program to read your age from the console and print how old you will be after 10 years.
using System;

class After10Years
{
    static void Main()
    {   int howManyYears = 10;
        Console.Write("Please type your age: ");
        int age = int.Parse(Console.ReadLine());
        int date = DateTime.Now.Year;
        Console.WriteLine("After {0} years (in {1}), you will be {2} years old.", howManyYears, date + howManyYears, age + howManyYears);

    }
}