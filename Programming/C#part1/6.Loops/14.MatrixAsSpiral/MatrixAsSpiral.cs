//* Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
//        Example for N = 4

using System;

class MatrixAsSpiral
{
    static void Main()
    {
        Console.Write("Please, type number(n<20): ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int counter = 1;
        int row = 0;
        int col = 0;
        int maxRow = n - 1;
        int maxCol = n - 1;
        do
        {
            for (int i = col; i <= maxCol; i++)
            {
                matrix[row, i] = counter;                               // right
                counter++;
            }
            row++;
            for (int i = row; i <= maxRow; i++)
            {
                matrix[i, maxCol] = counter;                             // down
                counter++;
            }
            maxCol--;
            for (int i = maxCol; i >= col; i--)
            {
                matrix[maxRow, i] = counter;                             //left
                counter++;
            }
            maxRow--;
            for (int i = maxRow; i >= row; i--)
            {
                matrix[i, col] = counter;                                //up
                counter++;
            }
            col++;
        }
        while (counter <= n * n);
        PrintMatrix(matrix);
    }


    private static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }


}