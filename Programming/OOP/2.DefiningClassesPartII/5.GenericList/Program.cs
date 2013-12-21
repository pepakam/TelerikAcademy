using System;

class Program
{
    static void Main()
    {
        GenericList<int> listTesting = new GenericList<int>(1);
        listTesting.AddElement(2);
        listTesting.AddElement(3);
        listTesting.AddElement(4);
        listTesting.AddElement(5);
        listTesting.AddElement(6);
        listTesting.AddElement(-1000);

        Console.WriteLine(listTesting);
        listTesting.RemoveElement(5);
        Console.WriteLine(listTesting);
        listTesting.InsertElement(0,25);
        Console.WriteLine(listTesting);
        Console.WriteLine(listTesting.FindElement(25));
        Console.WriteLine(listTesting.Max());
        Console.WriteLine(listTesting.Min());
        listTesting.ClearList();
        Console.WriteLine(listTesting);
    }
}
