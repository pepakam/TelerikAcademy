//Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 
//When you finish typing numbers, you should choose enter for the second time.
using System;
using System.Collections.Generic;

class SumOfNumbers
{
    static void Main()
    {
        Console.WriteLine("Please, type numbers.(When you finish typing numbers, you should choose enter for the second time.):\n");
        List<int> numbers = new List<int>();
        int sum = 0;
        string n;
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            numbers.Add(int.Parse(n));
            //sum += numbers[numbers.Count - 1];  variant 1
        }
        Console.Write("The sum of " + numbers[0]);
        sum = numbers[0]; //variant 2
  
        for (int i = 1; i < numbers.Count; i++)
        {
            Console.Write("+" + numbers[i]);
            sum += numbers[i]; //variant 2
        }

        Console.WriteLine(" = " + sum);
    }
}
