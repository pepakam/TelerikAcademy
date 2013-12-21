// Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
// Use the method from the previous exercise.

using System;

class FirstElement
{
    static void Main()
    {
        int[] array = new int[10];
        Console.WriteLine("Please, type 10 numbers: ");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        // print
        Console.WriteLine(new string('-', 50));
        int index = IndexOfTheFirstElement(array);
       
        if (index > (-1))
        {
            Console.WriteLine("The index of the first element that is bigger than its neighbors is {0}", index);
        }
        else
        {
            Console.WriteLine("There is NO element that is bigger than its neighbors");
        }
    }
    static int IndexOfTheFirstElement(int[] arr)
    {
        int val = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (IsBiggerFromNeighbors(arr, i))
            {
                val = i;
                break;
            }
        }
        return val;
    }
    static bool IsBiggerFromNeighbors(int[] arr, int index)
    {
        bool isBigger = false;
        if (index == 0 && arr[index] > arr[index + 1])
        {
            isBigger = true;
        }
        else if (index == arr.Length - 1 && arr[index] > arr[index - 1])
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
