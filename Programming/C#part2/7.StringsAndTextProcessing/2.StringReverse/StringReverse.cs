//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample"  "elpmas".

using System;

class StringReverse
{
    private static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    static void Main()
    {
        Console.Write("Please, type something: ");
        string str = Console.ReadLine();
        Console.WriteLine(Reverse(str));
        
    }
}
