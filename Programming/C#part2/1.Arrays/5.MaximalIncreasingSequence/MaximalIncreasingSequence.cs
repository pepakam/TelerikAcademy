// Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

// it works with few equal sequensies
// it works with no equal sequensies
using System;
using System.Collections.Generic;

class MaximalSequence
{
    static void Main()
    {
        List<double> array = new List<double>();
        int count = 1;
        int maxCount = 1;
        List<int> startingIndex = new List<int>();

        // getting from the console
        Console.WriteLine("Type few numbers.\nWhen you finish typing numbers, choose enter for the second time!");
        string n;
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            array.Add(double.Parse(n));
        }

        // solution
        // it works with few equal sequensies
        // it works with no equal sequensies
        for (int i = 1; i < array.Count; i++)
        {
            if (array[i] - 1 == array[i - 1])
            {
                count++;

                if (count > maxCount)
                {
                    maxCount = count;
                    startingIndex.Clear();
                    startingIndex.Add(i - maxCount + 1);
                }
                else if (count == maxCount)
                {
                    startingIndex.Add(i - maxCount + 1);
                }
            }
            else
            {
                count = 1;
            }
        }

        // printing
        int index = 0;
        Console.WriteLine(new string('-', 50));
        for (int i = 0; i < startingIndex.Count; i++)
        {
            for (int j = startingIndex[index]; j < startingIndex[index] + maxCount; j++)
            {
                Console.Write("{0} ", array[j]);
            }

            index++;
            Console.WriteLine();
        }

        if (count == 1 && count == maxCount)
        {
            Console.WriteLine("There is no equal sequensies!");
        }
    }
}