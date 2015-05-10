using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

//https://judge.softuni.bg/Contests/Practice/Index/84#1

class StringMatrixRotation
{
    private static List<List<char>> rotateText90(List<List<char>> text)
    {
        List<List<char>> res = new List<List<char>>();
        //convert list to array of chars
        char[,] chArr = new char[text.Count, text[0].Count];
        for (int i = 0; i < text.Count; i++)
            for (int j = 0; j < text[0].Count; j++)
                chArr[i, j] = text[i][j];

        //rotate the array
        char[,] chArrRotated = new char[text[0].Count, text.Count];
        for (int i = 0; i < text.Count; i++)
            for (int j = 0; j < text[0].Count; j++)
                chArrRotated[j, text.Count-i - 1]= chArr[i,j];

        //convert rotated array back to list
        for(int i=0; i<chArrRotated.GetLength(0); i++){
            List<char> lineList = new List<char>();
            for (int j = 0; j < chArrRotated.GetLength(1); j++)
                lineList.Add(chArrRotated[i, j]);
            res.Add(lineList);    
        }
        return res;
    }

    static void Main()
    {
        //extract rotation value
        string line = Console.ReadLine();
        int rotation = int.Parse(Regex.Match(line, @"\d+").Value);
        List<List<char>> text = new List<List<char>>();
        rotation %= 360;
        line = Console.ReadLine();
        int maxLineLen = 0;
        while(!line.Equals("END")){
            maxLineLen = Math.Max(maxLineLen, line.Length);
            List<char> lineList = line.ToCharArray().ToList();
            text.Add(lineList);
            line = Console.ReadLine();
        }

        //pad shorter strings with spaces:
        foreach (List<char> lineList in text)
            while (lineList.Count < maxLineLen)
                lineList.Add(' ');

        for (int i = 0; i < rotation / 90; i++)
            text = rotateText90(text);

        foreach(List <char> l in text){
            foreach (char ch in l)
                Console.Write(ch);
            Console.WriteLine();
        }   
    }
}