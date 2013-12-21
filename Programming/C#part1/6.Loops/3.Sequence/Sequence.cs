//Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;
using System.Linq;

class Sequence
{
    static void Main()
    {
        Console.Write("Please, type how many numbers: ");
        int n = int.Parse(Console.ReadLine());
        int[] number = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Please, type number: ");
           number[i] = int.Parse(Console.ReadLine());
        }
        //First solution
        //Console.WriteLine("Max number is: " +number.Max());
        //Console.WriteLine("Min number is: " + number.Min());


        //Second solution
        int max = number[0], min = number[0];
        for (int i = 1; i < n; i++)
        {
            if (number[i]>max)
            {
                max = number[i];
            }
            if (number[i]<min)
            {
                min=number[i];
            }


        }
        Console.WriteLine("Max number is: " + max);
        Console.WriteLine("Min number is: " + min);
    }
}
