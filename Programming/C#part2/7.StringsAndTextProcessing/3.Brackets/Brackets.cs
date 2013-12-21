//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

using System;
using System.Collections.Generic;

class Brackets
{
    static void Main()
    {
        string expression1 = "((a+b)/5-d)";
        string expression2 = ")(a+b))";
        if (CorrectBrackets(expression1)) Console.WriteLine("The expression {0} is correct!", expression1); else Console.WriteLine("The expression {0} is incorrect!", expression1);
        if (CorrectBrackets(expression2)) Console.WriteLine("The expression {0} is correct!", expression2); else Console.WriteLine("The expression {0} is incorrect!", expression2);
    }

    private static bool CorrectBrackets(string expression)
    {
        Stack<char> brackets = new Stack<char>();
        bool isCorrect = true;
        for (int i = 0; i < expression.Length; i++)
        {
            char ch = expression[i];
            if (ch == '(') brackets.Push(ch);           
            else if (ch == ')' && brackets.Count > 0) brackets.Pop();
            else if (brackets.Count == 0) isCorrect = false;
        }

        if (brackets.Count > 0) isCorrect = false;

        return isCorrect;

    }

}
