// Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.
using System;
using System.Collections.Generic;

class MaximalSum
{
    static void Main()
    {
        Console.Write("Please, type number of elements N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please, type how many elements will sum K =  ");
        int k = int.Parse(Console.ReadLine());
        double[] arr = new double[n];
        double[] maxSumSeq = new double[k];
        List<int> startingIndex = new List<int>();

        // getting from the console
        Console.WriteLine("Please, type numbers: ");
        for (int i = 0; i < n; i++)
        {
            arr[i] = double.Parse(Console.ReadLine());
        }

        // solution
        // it works with too equal sums. Example:{1,2,3,1,3,2,}->{2,3}, {3,2} if N=6, K=2.
        double sum = 0;
        double maxSum = 0;
        for (int i = 0; i < n - k + 1; i++)
        {
            sum = arr[i];
            for (int j = i + 1; j < i + k; j++)
            {
                sum += arr[j];
            }

            if (sum > maxSum)
            {
                maxSum = sum;
                startingIndex.Clear();
                startingIndex.Add(i);
            }
            else if (sum == maxSum)
            {
                startingIndex.Add(i);
            }
        }

        // printing
        int index = 0;
        string quantity;
        if (startingIndex.Count > 1)
        {
            quantity = "sums are";
        }
        else
        {
            quantity = "sum is";
        }

        Console.WriteLine(new string('-', 50));
        Console.WriteLine("The best {0}:", quantity);
        for (int i = 0; i < startingIndex.Count; i++)
        {
            for (int j = startingIndex[index]; j < startingIndex[index] + k; j++)
            {
                Console.Write("{0} ", arr[j]);
            }

            index++;
            Console.WriteLine();
        }
    }
}
