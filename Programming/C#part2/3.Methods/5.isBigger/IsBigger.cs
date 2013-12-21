// Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

using System;

class IsBigger
{
    static void Main()
    { 
        Console.Write("Please, type position of the element: ");
        int position = int.Parse(Console.ReadLine());
        int index = position - 1;
        int[] array = new int[10];
        Console.WriteLine("Please, type 10 numbers: ");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(new string('-', 50));
        Console.WriteLine("The element at position {0} is bigger the it,s neighbors => {1}", position, IsBiggerFromNeighbors(array, index));
    }
    static bool IsBiggerFromNeighbors(int[] arr, int index)
    {
        bool isBigger = false;
        if (index == 0 && arr[index] > arr[index + 1])
        {
            isBigger = true;
        }
        else if (index == arr.Length-1 && arr[index] > arr[index - 1])
        {
            isBigger = true;
        }
        else if ((index > 0 && index < arr.Length - 1) && arr[index] > arr[index + 1] && arr[index] > arr[index - 1])
        {
            isBigger = true;
        }
        else
        {
            isBigger = false;
        }
        return isBigger;
    }

}