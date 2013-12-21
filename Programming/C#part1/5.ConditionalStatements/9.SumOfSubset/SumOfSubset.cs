//We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.

using System;
using System.Collections.Generic;

class SumOfSubset
{
    static void Main()
    {
        int[] numbers = { 3, -2, 1, 1, 8 };
        List<int> set = new List<int>();
        int length = numbers.Length;       
        int counter = 0;       
        for (int i = 1; i < 32; i++)
        {
            int sum = 0;
            int whichNumber = 0;
            int seqNumber = 0;
            int j;
             for (j = 0; j < 5; j++)
            {
                whichNumber = ((i >> j) & 1); // shows which sequence number is having a part of the Subset. Returns 0 or 1
                seqNumber= whichNumber * numbers[j];
                sum += seqNumber;
            }
             if (sum == 0)
             {

                 counter++;
             }
             for (int k = 0; k <= j; k++)
             {
                 int whichNumberNew = ((i >> j - k) & 1);

                 if (sum == 0 && whichNumberNew == 1)
                 {
                     set.Add(numbers[j - k]);
                     
                 }

             }

        }
        Console.WriteLine("{0} subset sums = 0", counter);

        Console.Write(set[0]);

        for (int i = 1; i < set.Count; i++)
        {
            string s;
            if (set[i] >= 0)
            {
                s = "+";
            }
            else
            {
                s = "";
            }

            Console.Write(s + set[i]);
        }
        Console.WriteLine("=0");
    }
}
