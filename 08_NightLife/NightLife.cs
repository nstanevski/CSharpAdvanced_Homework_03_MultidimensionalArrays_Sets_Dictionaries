using System;
using System.Collections.Generic;
using System.Linq;

/*
 * There will be an arbitrary number of lines until you receive the string "END". 
 * Each line will contain data in format: "city;venue;performer". If either city, venue
 * or performer don't exist yet in the database, add them. If either the city and/or venue 
 * already exist, update their info.
 * Cities should remain in the order in which they were added, venues should be sorted 
 * alphabetically and performers should be unique (per venue) and also sorted alphabetically.
 * Print the data by listing the cities and for each city its venues 
 * (on a new line starting with "->") and performers (separated by comma and space).
 */

class NightLife
{
    static void Main()
    {
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> program =
            new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        String inputLine = Console.ReadLine().Trim();

        while (!inputLine.Equals("END"))
        {
            string[] items = inputLine.Split(';');
            string city = items[0];
            string venue = items[1];
            string performer = items[2];

            if (!program.ContainsKey(city))
            {
                SortedDictionary<string, SortedSet<string>> cityProgram =
                    new SortedDictionary<string, SortedSet<string>>();
                program[city] = cityProgram;
            }

            if (!program[city].ContainsKey(venue))
            {
                SortedSet<string> cityVenueProgram = new SortedSet<string>();
                program[city][venue] = cityVenueProgram;
            }

            program[city][venue].Add(performer);

            inputLine = Console.ReadLine().Trim();
        }

        //print results
        foreach (string city in program.Keys) 
        {
            Console.WriteLine(city);
            SortedDictionary<string, SortedSet<string>> cityVenues = program[city];
            foreach (string venue in cityVenues.Keys)
            {
                SortedSet<string> performers = cityVenues[venue];
                string performersStr = string.Join(", ", performers);
                Console.WriteLine("->{0}: {1}", venue, performersStr);
            }
        }
    }
}