// Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.

using System;
using System.Collections.Generic;

class IndexOfLetters
{
    static void Main()
    {
        char[] alphabet = new char[26];

        for (int i = 0; i < alphabet.Length; i++)
        {
            int shift = 65;
            alphabet[i] = Convert.ToChar(i + shift);
        }

        Console.Write("Please, type a word with capital letters: ");
        string word = Console.ReadLine();

        // getting char from word
        char letter;
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("The indexes are");
        for (int i = 0; i < word.Length; i++)
        {
            letter = word[i];
            int myIndex = Array.BinarySearch(alphabet, letter);

            Console.Write("{0} ", myIndex);
        }

        Console.WriteLine();
    }
}
