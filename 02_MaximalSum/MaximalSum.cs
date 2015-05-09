using System;
using System.Linq;

/*
 * Write a program that reads a rectangular integer matrix of size N x M 
 * and finds in it the square 3 x 3 that has maximal sum of its elements. 
 * On the first line, you will receive the rows N and columns M. 
 * On the next N lines you will receive each row with its columns.
 * Print the elements of the 3 x 3 square as a matrix, along with their sum.
 */

class MaximalSum
{
    static void Main()
    {
        //get dimensions:
        int[] dimensions = Console.ReadLine().Trim().Split().Select(p => int.Parse(p)).ToArray();
        int numRows = dimensions[0], numCols = dimensions[1];

        //initialize matrix:
        int[,] matrix = new int[numRows, numCols];
        for (int i = 0; i < numRows; i++)
        {
            int[] row = Console.ReadLine().Trim().Split().Select(p => int.Parse(p)).ToArray();
            for (int j = 0; j < numCols; j++)
            {
                matrix[i, j] = row[j];
            }
        }

        //find 3x3 platform with maximum sum
        int maxSum = int.MinValue, maxSumRow = 0, maxSumCol = 0;
        for (int row = 0; row < numRows - 2; row++)
        {
            for (int col = 0; col < numCols - 2; col++)
            {
                int currentSum = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        currentSum += matrix[row + i, col + j];
                    }
                }
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSumRow = row;
                    maxSumCol = col;
                }
            }
        }

        //print the result
        Console.WriteLine("Sum: {0}", maxSum);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("{0}\t", matrix[maxSumRow + i, maxSumCol + j]);
            }
            Console.WriteLine();
        }
    }
}