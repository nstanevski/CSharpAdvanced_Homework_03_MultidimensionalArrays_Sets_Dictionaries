using System;
using System.Linq;
using System.Collections.Generic;

/*
 * https://judge.softuni.bg/Contests/Practice/Index/84#0
 */

class PlusRemove
{
    private static List<List<char>> text = new List<List<char>>();

    private static bool checkForPlus(int rowIndex, int colIndex)
    {
        char ch = text[rowIndex][colIndex];
        char ch2 = text[rowIndex][colIndex+1];
        char ch3 = text[rowIndex][colIndex+2];

        if (!(text[rowIndex - 1].Count > colIndex + 1))
            return false;
        if (!(text[rowIndex + 1].Count > colIndex + 1))
            return false;

        char ch4 = text[rowIndex-1][colIndex + 1];
        char ch5 = text[rowIndex + 1][colIndex + 1];

        if (Char.ToUpper(ch).Equals(Char.ToUpper(ch2)) && Char.ToUpper(ch).Equals(Char.ToUpper(ch3)) &&
            Char.ToUpper(ch).Equals(Char.ToUpper(ch4)) && Char.ToUpper(ch).Equals(Char.ToUpper(ch5))
        )
            return true;

        return false;
    }
    static void Main()
    {
        
        string line = Console.ReadLine();

        while (!line.Equals("END"))
        {
            List<char> lineChars = line.ToList<char>();
            text.Add(lineChars);
            line = Console.ReadLine();
        }
        //process each row
        bool isPlusShape = false;

        HashSet<KeyValuePair<int, int>> plusCoordsSet = new HashSet<KeyValuePair<int, int>>();

        for (int rowIndex = 1; rowIndex < text.Count - 1; rowIndex++)
        {
            for (int colIndex = 0; colIndex < text[rowIndex].Count - 2; colIndex++)
            {
                isPlusShape = checkForPlus(rowIndex, colIndex);
                if (isPlusShape) 
                {
                    plusCoordsSet.Add(new KeyValuePair<int,int>(rowIndex, colIndex));
                    plusCoordsSet.Add(new KeyValuePair<int,int>(rowIndex, colIndex+1));
                    plusCoordsSet.Add(new KeyValuePair<int,int>(rowIndex, colIndex+2));
                    plusCoordsSet.Add(new KeyValuePair<int,int>(rowIndex-1, colIndex+1));
                    plusCoordsSet.Add(new KeyValuePair<int,int>(rowIndex+1, colIndex+1));
                }
            }
        }

        for (int rowInd = 0; rowInd < text.Count; rowInd++)
        {
            for (int colInd = 0; colInd < text[rowInd].Count; colInd++)
            {
                KeyValuePair<int, int> current = new KeyValuePair<int, int>(rowInd, colInd);
                if (!plusCoordsSet.Contains(current))
                {
                    Console.Write(text[rowInd][colInd]);
                }
            }
            Console.WriteLine();
        }
    }
}