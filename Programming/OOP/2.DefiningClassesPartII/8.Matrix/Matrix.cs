using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Matrix<T> where T : IComparable
{
    public readonly int Cols;
    public readonly int Rows;
    private readonly T[,] matrix;

    public Matrix(int cols, int rows)
    {
        this.Cols = cols;
        this.Rows = rows;
        this.matrix = new T[cols, rows];
    }

    public T this[int rowPos, int colPos]
    {
        get
        {
            if (rowPos < 0 || colPos < 0 || rowPos >= this.Cols)
            {
                throw new IndexOutOfRangeException("Out of the matrix");
            }
            return this.matrix[rowPos, colPos];
        }
        set
        {
            if (rowPos < 0 || colPos < 0 || rowPos >= this.Cols)
            {
                throw new IndexOutOfRangeException("Out of the matrix");
            }
            this.matrix[rowPos, colPos] = value;
        }
    }

    public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);
        if (firstMatrix.Cols == secondMatrix.Cols && firstMatrix.Rows == secondMatrix.Rows)
        {
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Rows; j++)
                {
                    dynamic temp1 = firstMatrix[i, j];
                    dynamic temp2 = secondMatrix[i, j];
                    finalMatrix[i, j] = temp1 + temp2;
                }
            }
        }
        else
        {
            throw new ArgumentException("Wrong sizes");
        }

        return finalMatrix;
    }

    public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);
        if (firstMatrix.Cols == secondMatrix.Cols && firstMatrix.Rows == secondMatrix.Rows)
        {
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Rows; j++)
                {
                    dynamic temp1 = firstMatrix[i, j];
                    dynamic temp2 = secondMatrix[i, j];
                    finalMatrix[i, j] = temp1 - temp2;
                }
            }
        }
        else
        {
            throw new ArgumentException("Wrong sizes");
        }

        return finalMatrix;
    }

    public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        if (firstMatrix.Cols != secondMatrix.Rows)
        {
            throw new ArithmeticException("Wrong sizes");
        }
        Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);
        for (int i = 0; i < finalMatrix.Rows; i++)
        {
            for (int j = 0; j < finalMatrix.Cols; j++)
            {
                for (int multiCol = 0; multiCol < firstMatrix.Cols; multiCol++)
                {
                    for (int k = 0; k < firstMatrix.Cols; k++)
                    {
                        dynamic temp1 = firstMatrix[i, j];
                        dynamic temp2 = secondMatrix[i, j];
                        finalMatrix[i, j] += temp1 * temp2;
                    }
                }
            }
        }
        return finalMatrix;
    }

    public static bool operator true(Matrix<T> matrix)
    {
        if (matrix == null || matrix.Rows == 0 || matrix.Cols == 0)
        {
            return false;
        }

        for (int row = 0; row < matrix.Rows; row++)
        {
            for (int col = 0; col < matrix.Cols; col++)
            {
                if (!matrix[row, col].Equals(default(T)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool operator false(Matrix<T> matrix)
    {
        if (matrix == null || matrix.Rows == 0 || matrix.Cols == 0)
        {
            return true;
        }

        for (int row = 0; row < matrix.Rows; row++)
        {
            for (int col = 0; col < matrix.Cols; col++)
            {
                if (!matrix[row, col].Equals(default(T)))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder endText = new StringBuilder();
        for (int i = 0; i < this.Rows; i++)
        {
            for (int j = 0; j < this.Cols; j++)
            {
                endText.AppendFormat("{0,5}", this[i, j]);
            }
            endText.AppendLine();
        }
        return endText.ToString();
    }
}
