//Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
using System;

class ExchangeValues
{
    static void Main()
    {
        int first = 5;
        int second = 10;
        Console.WriteLine("before... first variable = {0}, second variable = {1}", first, second);
        int third = first;
        first = second;
        second = third;
        Console.WriteLine("after... first variable = {0}, second variable = {1}", first, second);
    }
}