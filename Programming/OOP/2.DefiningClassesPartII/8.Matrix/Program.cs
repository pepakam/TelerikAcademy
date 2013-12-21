using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Matrix<int> matrix = new Matrix<int>(15,15);
        Matrix<int> matrix2 = new Matrix<int>(15,15);

        Console.WriteLine(matrix.Cols);

        matrix[0, 0] = 150;
        matrix2[0, 0] = 2;
        Console.WriteLine( (matrix + matrix2));

    }
}
