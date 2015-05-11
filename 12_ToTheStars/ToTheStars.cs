using System;
using System.Collections.Generic;

//https://judge.softuni.bg/Contests/Practice/Index/31#2

class ToTheStars
{
    private static Dictionary<string, double[]> starProperties = new Dictionary<string, double[]>();

    private static string GetLocation(double[] spaceShipCoord)
    {
        foreach (string starName in starProperties.Keys)
        {
            double[] starCoord = starProperties[starName];
            if(spaceShipCoord[0] >= starCoord[0] - 1 && spaceShipCoord[0] <= starCoord[0] + 1
                && spaceShipCoord[1] >= starCoord[1] - 1 && spaceShipCoord[1] <= starCoord[1] + 1)
            {
                return starName.ToLower();
            }
        }
        return "space";
    }

    static void Main()
    {

        //initialize dictionary of stars:
        string[] items;
        //Dictionary<string, double[]> starProperties = new Dictionary<string, double[]>();
        for (double i = 0; i < 3; i++)
        {
            items = Console.ReadLine().Split();
            double[]starCoords = {double.Parse(items[1]), double.Parse(items[2])};
            starProperties.Add(items[0],starCoords);
        }
        items = Console.ReadLine().Split();
        double[] spaceShipCoords = { double.Parse(items[0]), double.Parse(items[1]) };
        double numTurns = double.Parse(Console.ReadLine());

        for (double i = 0; i <= numTurns; i++)
        {
            string location = GetLocation(spaceShipCoords);
            Console.WriteLine(location);
            spaceShipCoords[1]++;
        }
    }
}