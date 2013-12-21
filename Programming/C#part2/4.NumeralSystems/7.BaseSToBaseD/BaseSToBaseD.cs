using System;

class BaseSToBaseD
{
    // GetChar(10) -> A
    static char GetChar(int i)
    {
        if (i >= 10) return (char)('A' + i - 10);
        else return (char)('0' + i);
    }
    // GetNumber(1234,3) -> 4
    static int GetNumber(string s, int i)
    {
        if (s[i] >= 'A') return s[i] - 'A' + 10;
        else return s[i] - '0';
    }
    //step 1
    static string Base10ToBaseX(int d, int x)
    {
        string h = string.Empty;
        for (; d != 0; d /= x) h = GetChar(d % x) + h;
        return h;

    }
    // step 2
    static int BaseXToBase10(string h, int x)
    {
        int d = 0;
        for (int i = h.Length - 1, p = 1; i >= 0; i--, p *= x)
            d += GetNumber(h, i) * p;
        return d;    
    }
    static string BaseXToBaseY(string n, int x, int y)
    {
        return Base10ToBaseX(BaseXToBase10(n, x), y);
    }
    static void Main()
    {
        Console.Write("Please enter the numeral system FROM: ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Please, type number: ");
        string number = Console.ReadLine();
        Console.Write("Please enter the numeral system TO: ");
        int d = int.Parse(Console.ReadLine());
        Console.WriteLine(BaseXToBaseY(number, s, d));
    }
}
