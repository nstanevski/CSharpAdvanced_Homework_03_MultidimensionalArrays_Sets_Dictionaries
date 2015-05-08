using System;

/*
 * Write two programs that fill and print a matrix of size N x N. 
 * Filling a matrix in the regular pattern (top to bottom and left to right) is boring. 
 * Fill the matrix as described in both patterns below
 */
class FillTheMatrix
{

    private static int[,] FillMatrixByColumn(int size)
    {
        int[,] result = new int[size, size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                result[j, i] = size * i + j + 1;

        return result;
    }

    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = FillMatrixByColumn(size);
        for (int i = 0; i < size; i++)
        {
            for(int j=0; j<size; j++)
            {
                Console.Write("\t{0}", matrix[i, j]);
            }
            Console.WriteLine();
        }

    }

    
}