using System;
using System.Collections.Generic;
using System.Linq;

static class IenumerableExt
{
    private static T Sum<T>(this IEnumerable<T> items) where T : IComparable
    {
        dynamic sum = 0;
        
        
        foreach (var item in items)
        {
            sum += item;
        }
        
        return sum;
    }
    private static T Max<T>(this IEnumerable<T> items) where T : IComparable
    {
        dynamic max = items.First();

            foreach (dynamic item in items)
            {
                if (item>max)
                {
                    max = item;
                }
            }
        return max;
    }
    private static T Min<T>(this IEnumerable<T> items) where T : IComparable
    {
        dynamic min = items.First();

        foreach (dynamic item in items)
        {
            if (item < min)
            {
                min = item;
            }
        }
        return min;
    }
    private static T Product<T>(this IEnumerable<T> items) where T : IComparable
    {
        dynamic product = 1;

        foreach (dynamic item in items)
        {
            product *= item;
        }
        return product;
    }
    private static decimal Average<T>(this IEnumerable<T> items) where T : IComparable
    {
        dynamic sum = 0;
        decimal counter = 0m;

        foreach (dynamic item in items)
        {
            sum += item;
            counter++;

        }
        return sum / counter;
    }

    static void Main()
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

       

        Console.WriteLine(numbers.Sum());
        Console.WriteLine(numbers.Max());
        Console.WriteLine(numbers.Min());
        Console.WriteLine(numbers.Product());
        Console.WriteLine(  numbers.Average());
    }

     
}