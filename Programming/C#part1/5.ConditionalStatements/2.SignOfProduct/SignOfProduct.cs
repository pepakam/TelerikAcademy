//Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

using System;

class SignOfProduct
{
    static void Main()
    {
        double[] number = new double[3];
        Console.Write("Please, type first number: ");
        number[0] = double.Parse(Console.ReadLine());
        Console.Write("Please, type second number: ");
        number[1] = double.Parse(Console.ReadLine());
        Console.Write("Please, type third number: ");
        number[2] = double.Parse(Console.ReadLine());

        int countMinuses = 0;

        if (number[0] < 0)
        {
            countMinuses++;
        }
        if (number[1] < 0)
        {
            countMinuses++;
        }
        if (number[2] < 0)
        {
            countMinuses++;
        }

        if (number[0] == 0 || number[1] == 0 || number[2] == 0)
        {
            Console.WriteLine("The product of the three real numbers is zero");
        }
        else if (countMinuses % 2 == 0)
        {
            Console.WriteLine("+");
        }
        else
        {
            Console.WriteLine("-");
        }
    }
}
