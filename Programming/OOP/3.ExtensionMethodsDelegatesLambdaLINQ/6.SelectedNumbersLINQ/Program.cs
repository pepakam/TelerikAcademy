using System;
using System.Linq;

namespace _6.SelectedNumbersLINQ
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[100];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }
            var selectedNumbers =
                from n in numbers
                where n % 7 == 0 || n % 3 == 0
                select n;

            foreach (int selectedNumber in selectedNumbers)
            {
                Console.WriteLine(selectedNumber);
            }
            
        }
    }
}
