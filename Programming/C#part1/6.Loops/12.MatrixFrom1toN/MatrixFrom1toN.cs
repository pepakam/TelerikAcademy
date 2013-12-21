//Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:
//    N = 3			N = 4

using System;

class MatrixFrom1toN
{
    static void Main()
    {
        Console.Write("Please, type number(n<20): ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
       
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int val = row+1;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = val;
                val++;
                
            }  
            
        }
        PrintMatrix(matrix);
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,3}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
