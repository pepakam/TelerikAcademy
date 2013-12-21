// Write a program that finds in given array of integers a sequence of given sum S (if present). Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
using System;
using System.Collections.Generic;

class SequenceOfGivenSum
{
    static void Main()
    {
        List<int> array = new List<int>();
        Console.Write("Please, type sum S = ");
        int s = int.Parse(Console.ReadLine());

        // getting from the console
        Console.WriteLine("Type few numbers.\nWhen you finish typing numbers, choose enter for the second time!");
        string n;
        while (!string.IsNullOrEmpty(n = Console.ReadLine()))
        {
            array.Add(int.Parse(n));
        }

        // solution
        int sum = 0;
        int startIndex = 0;
        int endIndex = 0;
        for (int i = 0; i < array.Count; i++)
        {
            sum = array[i];
            startIndex = i;
            for (int j = i + 1; j < array.Count; j++)
            {
                sum += array[j];

                if (sum > s)
                {
                    break;
                }

                if (sum == s)
                {
                    endIndex = j;
                    break;
                }
            }

            if (sum == s)
            {
                break;
            }
        }

        // printing
        // it prints the first sequence with given sum
        Console.WriteLine(new string('-', 50));

        if (endIndex == 0)
        {
            Console.WriteLine("There is no sequense with the sum S={0}", s);
        }
        else
        {
            Console.Write("The sequence with the sum = {0} is ", s);
            Console.Write("{");
            for (int i = startIndex; i <= endIndex - 1; i++)
            {
                Console.Write("{0},", array[i]);
            }

            Console.Write(array[endIndex]);
            Console.WriteLine("}");
        }
    }
}