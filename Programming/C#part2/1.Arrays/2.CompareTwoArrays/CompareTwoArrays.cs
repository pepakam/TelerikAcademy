// Write a program that reads two arrays from the console and compares them element by element.
// When you finish typing numbers, you should choose enter for the second time.
using System;
using System.Collections.Generic;

class CompareTwoArrays
{
    static void Main()
    {
        List<int> array1 = new List<int>();
        List<int> array2 = new List<int>();
        string n;
        Console.WriteLine("Enter first array's elements (only whole numbers).\nWhen you finish typing numbers, you should choose enter for the second time.");
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            array1.Add(int.Parse(n));
        }

        Console.WriteLine(new string('-', 80));
        Console.WriteLine("Enter second array's elements (only whole numbers).\nWhen you finish typing numbers, you should choose enter for the second time.");
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            array2.Add(int.Parse(n));
        }

        bool isEqual = true;

        if (array1.Count != array2.Count)
        {
            isEqual = false;
        }
        else
        {
            for (int i = 0; i < array1.Count; i++)
            {
                if (!array1[i].Equals(array2[i]))
                {
                    isEqual = false;
                    break;
                }
            }
        }

        Console.WriteLine(new string('-', 80));
        string not = isEqual ? string.Empty : "NOT ";
        Console.WriteLine("Two arrays are {0}equal", not);
        Console.WriteLine(new string('-', 80));
    }
}
