using System;

/*
 * Write two programs that fill and print a matrix of size N x N. 
 * Filling a matrix in the regular pattern (top to bottom and left to right) is boring. 
 * Fill the matrix as described in both patterns below
 */

class FillTheMatrix
{
    private static void transposeMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        for (int i = 0; i < size; i++)
            for (int j = i; j < size; j++)
            {
                int tmp = matrix[j, i];
                matrix[j, i] = matrix[i, j];
                matrix[i, j] = tmp;
            }
    }

    private static void ReverseEvenRows(int[,] matrix)
    {
        int len = matrix.GetLength(0);
        for (int i = 0; i < len; i++)
            if (i % 2 == 1)
            {
                for (int j = 0; j < len/2 ; j++)
                {
                    int tmp = matrix[i, j];
                    matrix[i, j] = matrix[i, len- j-1];
                    matrix[i, len-j-1] = tmp;
                }
            }
    }


    private static void PrintSquareMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
                Console.Write("\t{0}", matrix[i, j]);
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        //init matrix
        int[,] matrix = new int[size, size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                matrix[i, j] = i * size + j + 1;
        
        //transpose in-place
        transposeMatrix(matrix);
        PrintSquareMatrix(matrix);

        Console.WriteLine();

        //transpose again to restore the original matrix
        transposeMatrix(matrix);
        ReverseEvenRows(matrix);
        transposeMatrix(matrix);
        PrintSquareMatrix(matrix);
    }
}