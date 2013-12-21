// Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.

using System;

class Name
{
    static void WhatIsYourName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!", name);
    }
    static void Main()
    {
        WhatIsYourName();
    }
}
