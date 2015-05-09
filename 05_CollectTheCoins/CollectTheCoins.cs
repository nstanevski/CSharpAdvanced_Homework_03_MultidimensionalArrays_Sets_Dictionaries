using System;
using System.Collections.Generic;
using System.Linq;

/*
 * You receive the layout of a board from the console. Assume it will always have 4 rows
 * which you'll get as strings, each on a separate line. Each character in the strings 
 * will represent a cell on the board. Note that the strings may be of different length.
 * You are the player and start at the top-left corner (that would be position [0, 0] on the board). 
 * On the fifth line of input you'll receive a string with movement commands which tell you
 * where to go next, it will contain only these four characters – '>' (move right), 
 * '<' (move left), '^' (move up) and 'v' (move down). 
 * You need to keep track of two types of events – collecting coins (represented by the symbol '$',
 * of course) and hitting the walls of the board (when the player tries to move off the board
 * to invalid coordinates). When all moves are over, print the amount of money collected 
 * and the number of walls hit.
 */

class CollectTheCoins
{
    private static bool CoinFound(List<char>[] board, int rowInd, int colInd)
    {
        List<char> row = board[rowInd];
        return row[colInd] == '$' ? true : false;
    }

    static void Main()
    {
        //init board
        List<char>[] board = new List<char>[4];
        for (int i = 0; i < 4; i++)
        {
            List<char> line = Console.ReadLine().Trim().ToCharArray().ToList();
            board[i] = line;
        }
        char[] directions = Console.ReadLine().Trim().ToCharArray();
        int currRow = 0, currCol = 0;
        int numCoins = 0, numWalls = 0;

        //walking
        foreach (char dir in directions)
        {
            switch (dir)
            {
                case '^':
                    if (currRow == 0)
                    {
                        numWalls++;
                    }
                    else
                    {
                        if (board[currRow - 1].Count - 1 < currCol)
                        {
                            numWalls++;
                        }
                        else
                        {
                            currRow--;
                            if (CoinFound(board, currRow, currCol))
                                numCoins++;
                        }
                    }
                    break;

                case 'V':
                    if (currRow == 3)
                    {
                        numWalls++;
                    }
                    else
                    {
                        if (board[currRow + 1].Count - 1 < currCol)
                        {
                            numWalls++;
                        }else{
                            currRow++;
                            if (CoinFound(board, currRow, currCol))
                                numCoins++;

                        }
                        
                    }
                    break;

                case '>':
                    List<char> row = board[currRow];
                    if(currCol == row.Count - 1){
                        numWalls++;
                    }else
                    {
                        currCol++;
                        if (CoinFound(board, currRow, currCol))
                            numCoins++;
                    }
                    break;

                case '<':
                    row = board[currRow];
                    if(currCol == 0){
                        numWalls++;
                    }else
                    {
                        currCol--;
                        if (CoinFound(board, currRow, currCol))
                            numCoins++;
                    }
                    break;
            }
        }
        Console.WriteLine("Coins collected: {0}\nWalls hit: {1}", numCoins, numWalls);
    }
}