using System;

class SequenceInMatrix
{
    private static int numRows = 0;
    private static int numCols = 0;
    private static string[,] matrix;

    private static int countEquals(int rowIndex, int colIndex)
    {
        string val = matrix[rowIndex, colIndex];
        int n = colIndex; int m = 0;
        int seqSize = 1, maxSize=1;

        //check for equal neighbours in the same row
        while(n<matrix.GetLength(1)-1 && val.Equals(matrix[rowIndex, n+1])){
            n++;
            seqSize++;
        }
        if (seqSize > maxSize)
            maxSize = seqSize;

        //check for equal neighbours in the same col
        seqSize = 1; n = rowIndex;
        while (n < matrix.GetLength(0) - 1 && val.Equals(matrix[n+1, colIndex]))
        {
            n++;
            seqSize++;
        }
        if (seqSize > maxSize)
            maxSize = seqSize;

        //check for equal neighbours in the same main diagonal
        seqSize = 1; n = colIndex; m = rowIndex;
        while (n < matrix.GetLength(1) - 1 && m<matrix.GetLength(0)-1 
            && val.Equals(matrix[m + 1, n + 1]))
        {
            n++; m++;
            seqSize++;
        }
        if (seqSize > maxSize)
            maxSize = seqSize;

        //check for equal neighbours in the same secondary diagonal
        seqSize = 1; n = colIndex; m = rowIndex;
        while (n > 0 && m < matrix.GetLength(0) - 1
            && val.Equals(matrix[m + 1, n - 1]))
        {
            n--; m++;
            seqSize++;
        }
        if (seqSize > maxSize)
            maxSize = seqSize;

        return maxSize;
    }

    private static void PrintSequence(int maxLen, int maxRowInd, int maxColInd)
    {
        for (int i = 0; i < maxLen; i++)
        {
            Console.Write(matrix[maxRowInd, maxColInd]);
            if(i<maxLen-1)
                Console.Write(", ");
        }
        Console.WriteLine();
    }
        
    static void Main()
    {
        //read dimensions, initialize matrix
        numRows = int.Parse(Console.ReadLine().Trim());
        numCols = int.Parse(Console.ReadLine().Trim());
        matrix = new string[numRows, numCols];
        for (int rowIndex = 0; rowIndex < numRows; rowIndex++)
            for (int colIndex = 0; colIndex < numCols; colIndex++)
                matrix[rowIndex, colIndex] = Console.ReadLine().Trim();

        //process
        int maxLen = 1, maxRowInd = 0, maxColInd = 0;

        for (int rowIndex = 0; rowIndex < numRows; rowIndex++){
            for (int colIndex = 0; colIndex < numCols; colIndex++)
            {
                int numEquals = countEquals(rowIndex, colIndex);
                if (numEquals > maxLen)
                {
                    maxLen = numEquals;
                    maxRowInd = rowIndex;
                    maxColInd = colIndex;
                }
            }
        }
        PrintSequence(maxLen, maxRowInd, maxColInd);
    }
}