// Write a program that reads an integer number and calculates and prints its square root. If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally
using System;


class SquareRoot
{
    public static double Sqrt(uint number)
    {
        return Math.Sqrt(number);
    }
    static void Main()
    {
        try
        {
            Console.Write("Please, type number: ");
            uint n = uint.Parse(Console.ReadLine());
            Console.WriteLine(Sqrt(n));
        }
        catch (FormatException)
        {
            Console.Error.WriteLine("Invalid number");
        }
        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("Invalid number");
        }
        catch (OverflowException)
        {
            Console.Error.WriteLine("Invalid number");
        }         
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
