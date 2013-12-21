using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i;
        }

        var selectedNums = numbers.Where(x => x % 7 == 0 || x % 3 == 0);
        foreach (int number in selectedNums)
        {
            Console.WriteLine( number);
        }

    }
}
