// Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.

using System;

class HowManyTimes
{
    static void Main()
    {
        Console.Write("Please, type number: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[10];
        Console.WriteLine("Please, type 10 integer numbers:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        int count = HowMany(array, n);
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Number {0} apears {1} times.", n, count);
    }
    static int HowMany(int[] arr, int givenNumber)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (givenNumber == arr[i])
            {
                count++;
            }
        }
        return count;
    }
}