using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

//PROBLEM NOT FINISHED

class ActivityTracker
{
    static void Main()
    {
        SortedDictionary<int, Dictionary<string, double>> activities =
            new SortedDictionary<int, Dictionary<string, double>>();
        int numLines = int.Parse(Console.ReadLine());
        for (int n = 0; n < numLines; n++)
        {
            string[] items = Console.ReadLine().Split();
            string dateStr = items[0];
            string name = items[1];
            double distance = double.Parse(items[2]);

            int[] dateItems = dateStr.Split('/').Select(p=>int.Parse(p)).ToArray();
            int monthNum = dateItems[1];
            
                  
            if (!activities.ContainsKey(monthNum))
            {
                Dictionary<string, double> monthDict = 
                    new Dictionary <string, double>();
                activities[monthNum] = monthDict;
            }
            if (!activities[monthNum].ContainsKey(name))
            {
                activities[monthNum][name] = distance;
            }
            else
            {
                activities[monthNum][name] += distance;
            }
            
        }

        Console.WriteLine("End");

    }
}