// Write a program that finds the sequence of maximal sum in given array. Example:
//    {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
//    Can you do it with only one loop (with single scan through the elements of the array)?

using System;
using System.Collections.Generic;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        List<int> seq = new List<int>();

        // getting from the console
        Console.WriteLine("Type few numbers.\nWhen you finish typing numbers, choose enter for the second time!");
        string n;
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            seq.Add(int.Parse(n));
        }

        // solution
        int maxSum = seq[0];
        int sum = seq[0];

        int begin = 0;
        int beginTemp = 0;
        int end = 0;

        for (int i = 1; i < seq.Count; i++)
        {
            if (sum < 0)
            {
                sum = seq[i];
                beginTemp = i;
            }
            else
            {
                sum += seq[i];
            }

            if (sum > maxSum)
            {
                maxSum = sum;

                begin = beginTemp;
                end = i;
            }
        }

        // printing
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("The maximal sum is {0}", maxSum);
        Console.WriteLine("The maximum subarray is:");
        for (int i = begin; i <= end; i++)
        {
            Console.WriteLine(seq[i]);
        }          
    }
}
