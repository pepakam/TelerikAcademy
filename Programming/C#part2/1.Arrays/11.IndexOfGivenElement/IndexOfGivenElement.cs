// Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class IndexOfGivenElement
{
    static void Main()
    {
        List<int> array = new List<int>();

        // getting from the console
        Console.Write("Type element = ");
        int element = int.Parse(Console.ReadLine());
        Console.WriteLine("Type few numbers.\nWhen you finish typing numbers, choose enter for the second time!");
        string n;
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            array.Add(int.Parse(n));
        }

        // solution
        array.Sort();

        int i = array.Count / 2;
        int start = 0;
        int end = array.Count;
        bool found = false;
        while (start + 1 != end)
        {
            if (element == array[i])
            {
                found = true;
                Console.Write("Element[{0}] = {1} in sorted array ", i, element); // printing index of first found element
                Console.Write("{");
                break;
            }
            else if (element > array[i])
            {
                start = i;
            }
            else if (element < array[i])
            {
                end = i;
            }

            i = start + ((end - start) / 2);
        }

        // printing
        if (!found)
        {
            Console.Write("There is no element {0} in array ", element);
            Console.Write("{");
        }

        for (int j = 0; j < array.Count - 1; j++)
        {
            Console.Write("{0},", array[j]);
        }

        Console.Write("{0}", array[array.Count - 1]);
        Console.WriteLine("}");
    }
}
