//Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

using System;

class GreaterNumber
{
    static void Main()
    {
        Console.WriteLine("Please, type 2 numbers: ");
        int n1= int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine("The greater number is {0}", Math.Max(n1,n2));
    }
}
