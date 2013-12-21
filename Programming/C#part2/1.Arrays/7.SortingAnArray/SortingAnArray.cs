// Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortingAnArray
{
    static void Main()
    {
        List<int> unsorted = new List<int>();

        // getting from the console
        Console.WriteLine("Type few numbers.\nWhen you finish typing numbers, choose enter for the second time!");
        string n;
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            unsorted.Add(int.Parse(n));
        }

        // solution
        unsorted.Sort();

        // printing
        Console.WriteLine(new string('-', 50));
        Console.Write("Sorted numbers: ");
        for (int i = 0; i < unsorted.Count; i++)
        {
            Console.Write("{0} ", unsorted[i]);
        }

        Console.WriteLine();
    }
}
