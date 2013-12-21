//Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
//The cards should be printed with their English names. Use nested for loops and switch-case.
using System;

class Cards
{
    static void Main()
    {
        string[] rang = new string[13] { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        string[] suit = new string[4] { "Clubs", "Diamonds", "Hearts", "Spades" };
        foreach (string Suit in suit)
        {
            foreach (string Rang in rang)
            {
                Console.WriteLine("{0} of {1}", Rang, Suit);
            }
        }
    }
}
