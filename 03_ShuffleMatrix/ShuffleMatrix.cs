using System;

/*
 *Write a program which reads a string matrix from the console and performs certain operations
 *with its elements. User input is provided like in the problem above – first you read
 *the dimensions and then the data. Remember, you are not required to do this step first, 
 *you may add this functionality later.  
 * Your program should then receive commands in format: "swap x1 y1 x2 y2" where x1, x2, y1, y2
 * are coordinates in the matrix. In order for a command to be valid, it should start with the 
 * "swap" keyword along with four valid coordinates (no more, no less). You should swap 
 * the values at the given coordinates (cell [x1, y1] with cell [x2, y2]) and print 
 * the matrix at each step (thus you'll be able to check if the operation was performed correctly). 
 * If the command is not valid (doesn't contain the keyword "swap", has fewer or more coordinates
 * entered or the given coordinates do not exist), print "Invalid input!" and move 
 * on to the next command. Your program should finish when the string "END" is entered.
 */

class ShuffleMatrix
{
    private static int numRows = 0;
    private static int numCols = 0;
    private static string[,] matrix;

    private static bool validCommand(string[] cmdItems)
    {
        if (cmdItems.Length != 5 || !cmdItems[0].Equals("SWAP"))
            return false;
        int rowFrom = int.Parse(cmdItems[1]);
        int colFrom = int.Parse(cmdItems[2]);
        int rowTo = int.Parse(cmdItems[3]);
        int colTo = int.Parse(cmdItems[4]);

        if (!(rowFrom >= 0 && rowFrom < numRows))
            return false;
        if (!(rowTo >= 0 && rowTo < numRows))
            return false;
        if (!(colFrom >= 0 && colFrom < numCols))
            return false;
        if (!(colTo >= 0 && colTo < numCols))
            return false;

        return true;
    }

    private static void SwapValues(int rowFrom, int colFrom, int rowTo, int colTo)
    {
        string buffer = matrix[rowFrom, colFrom];
        matrix[rowFrom, colFrom] = matrix[rowTo, colTo];
        matrix[rowTo, colTo] = buffer;
    }

    private static void PrintMatrix()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0}\t", matrix[i, j]);
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

        //process commands
        string command = Console.ReadLine().ToUpper();
        while (command != "END")
        {
            string[] cmdItems = command.Split();
            if (!validCommand(cmdItems))
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                int rowFrom = int.Parse(cmdItems[1]);
                int colFrom = int.Parse(cmdItems[2]);
                int rowTo = int.Parse(cmdItems[3]);
                int colTo = int.Parse(cmdItems[4]);
                SwapValues(rowFrom, colFrom, rowTo, colTo);
                PrintMatrix();
            }

            command = Console.ReadLine().ToUpper();
        }
    }  
}