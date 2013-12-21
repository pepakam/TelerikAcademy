//Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

using System;

class SumWithAccuracy
{
    static void Main()
    {
        float sum = 1.0F;
        for (float i = 2; 1 / i >= 0.001; i++)
        {
            if (i % 2 == 0)
            {
                sum += 1 / i;
            }
            else
            {
                sum -= 1 / i;
            }
        }
        Console.WriteLine("{0:F3}", sum);
    }
}
