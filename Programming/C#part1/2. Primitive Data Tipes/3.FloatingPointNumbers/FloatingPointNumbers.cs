//Write a program that safely compares floating-point numbers with precision of 0.000001. Examples:(5.3 ; 6.01) → false;  (5.00000001 ; 5.00000003) → true
using System;

class FloatingPointNumbers
{
    static void Main()
    {
        float val1 = 5.3f;
        float val2 = 6.01f;
        float val3 = 5.00000001f;
        float val4 = 5.00000003f;
        Console.WriteLine("{0} ; {1} → {2}", val1, val2, val1 == val2);
        Console.WriteLine("{0} ; {1} → {2}", val3, val4, val3 == val4);
    }
}
