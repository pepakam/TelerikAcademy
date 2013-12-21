// Write a program that compares two char arrays lexicographically (letter by letter).

using System;
using System.Collections.Generic;

class CompareTwoCharArrays 
{
    static void Main()
    {
        List<char> array1 = new List<char>();
        List<char> array2 = new List<char>();
        string n;
        Console.WriteLine("Enter first array's elements (only chars).\nWhen you finish typing chars, you should choose enter for the second time.");
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            array1.Add(char.Parse(n));
        }

        Console.WriteLine(new string('-', 80));
        Console.WriteLine("Enter second array's elements (only chars).\n When you finish typing chars, you should choose enter for the second time.");
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            array2.Add(char.Parse(n));
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
