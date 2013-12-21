//Create console application that prints your first and last name.

using System;

class FirstLastName
{
    static void Main()
    {
        Console.Write("Please, enter your first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Please, enter your last name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Your name is: {0} {1}", firstName, lastName);
        
    }
}
