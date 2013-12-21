//Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement.

using System;

class ModifyVariable
{
    static void Main()
    {
        Console.Write("Please, type int, double or string variable: ");

        string strVar = Console.ReadLine();
        double doubleVar;
        object modifyed;

        switch (double.TryParse(strVar, out doubleVar))
        {case true:
                modifyed = double.Parse(strVar) + 1;
                break;
            default:
                modifyed = strVar + "*";
                break;
        }
        Console.WriteLine(modifyed);
    }
}
