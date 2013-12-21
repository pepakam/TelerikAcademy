// Write a program that finds the most frequent number in an array. Example:
//    {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

using System;
using System.Collections.Generic;

class MostFrequentNumber
{
    static void Main()
    {
        List<int> array = new List<int>();

        // getting from the console
        Console.WriteLine("Type few numbers(from 0 to 9).\nWhen you finish typing numbers, choose enter for the second time!");
        string n;
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            array.Add(int.Parse(n));
        }

        // solution
        int count = 0;
        int maxCount = 0;
        int number = -1;
        for (int i = 0; i <= 9; i++)
        {
            count = 0;
            for (int j = 0; j < array.Count; j++)
            {
                if (array[j] == i)
                {
                    count++;
                }
            }

            if (count > maxCount)
            {
                maxCount = count;
                number = i;
            }
        }

        if (maxCount > 1)
        {
            Console.WriteLine("The most frequent number in an array is {0} ({1} times)", number, maxCount);
        }
        else
        {
            Console.WriteLine("There is no recurrent number!");
        }
    }
}
