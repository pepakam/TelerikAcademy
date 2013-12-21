// Write a program that generates and prints to the console 10 random values in the range [100, 200].
using System;

class RandomValues
{
    static void Main()
    {
        Random random = new Random();        
        for (int i = 0; i < 10; i++)
        {
            int randomNumber = random.Next(100, 201);
            Console.WriteLine(randomNumber);
        }
    }
}
