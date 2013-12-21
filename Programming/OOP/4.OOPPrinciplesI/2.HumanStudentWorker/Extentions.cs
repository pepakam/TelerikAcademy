using System;
using System.Collections.Generic;
using System.Text;

static class IEnumerableExtentions
{
    public static void Print(this IEnumerable<object> list)
    {
        foreach (var o in list)
        {
            Console.WriteLine(o);
            Console.WriteLine();
        }
    }

    public static StringBuilder TrimEnd(this StringBuilder input)
    {
        while (Char.IsWhiteSpace(input[input.Length-1]))
        {
            input.Remove(input.Length - 1, 1);
        }
        return input;
    }
}
