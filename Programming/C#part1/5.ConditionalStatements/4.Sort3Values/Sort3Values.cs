//Sort 3 real values in descending order using nested if statements.

using System;

class Sort3Values
{
    static void Main()
    {
        Console.WriteLine("Please, type 3 real values: ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double first, second, third;
        if (a > b && b < c)
        {
            if (c > a)
            {
                first = c;
                second = a;
                third = b;

            }
            else
            {
                first = a;
                second = c;
                third = b;
            }
        }
        else if (a < b && b > c)
        {
            if (c > a)
            {
                first = b;
                second = c;
                third = a;
            }
            else
            {
                first = b;
                second = a;
                third = c;
            }
        }
        else
        {
            if (a > b && b > c)
            {
                first = a;
                second = b;
                third = c;
            }
            else
            {
                first = c;
                second = b;
                third = a;
            }
        }
        Console.WriteLine(first + "," + second + "," + third);
    }
}
