//You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. Example:
//        string = "43 68 9 23 318"  result = 461

using System;

class CalculateSum
{
    static void Main()
    {
        CalcSum("43 68 9 23 318");
    }

    private static void CalcSum(string values)
    {
        int sum = 0;
        string[] numbers = values.Split(' ');
        foreach (var item in numbers)
        {
            sum += int.Parse(item);
        }
        Console.WriteLine(sum);
    }
}
