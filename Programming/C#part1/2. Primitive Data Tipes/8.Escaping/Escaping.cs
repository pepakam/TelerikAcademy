/*Declare two string variables and assign them with following value:
 The "use" of quotation causes difficulties.
 Do the above in two different ways: with and without using quoted strings.*/

using System;

class Escaping
{
    static void Main()
    {
        string phrase1 = "The \"use\" of quotation causes difficulties.";
        string phrase2 = @"The ""use"" of quotation causes difficulties.";
        Console.WriteLine(phrase1 + "\n" + phrase2);
    }
}
