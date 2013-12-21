//Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
//The cards should be printed with their English names. Use nested for loops and switch-case.

using System;

class Cards
{
    static void Main()
    {
        string[] rang = new string[13] { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        string[] suit = new string[4] { "Clubs", "Diamonds", "Hearts", "Spades" };
        for (int i = 0; i < suit.Length; i++)
        {
            for (int j = 0; j < rang.Length; j++)
            {
                Console.WriteLine(rang[j] + " of " + suit[i]);
            }
        }


    }
}
