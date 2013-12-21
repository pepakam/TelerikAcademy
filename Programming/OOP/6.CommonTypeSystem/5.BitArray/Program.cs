using System;

class Program
{
    static void Main()
    {
        
        BitArray64 number = new BitArray64(125);
        BitArray64 number2 = new BitArray64(125);
        BitArray64 number3 = new BitArray64(15);
             
        foreach (var item in number)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();

       
        Console.Write(new string('-', 35));
        Console.Write("TEST");
        Console.WriteLine(new string('-',35));
        // TEST
        Console.WriteLine(number.Equals(number3));
        Console.WriteLine(number.GetHashCode());
        Console.WriteLine(number==number2);
        Console.WriteLine(number != number2);

    }
}
