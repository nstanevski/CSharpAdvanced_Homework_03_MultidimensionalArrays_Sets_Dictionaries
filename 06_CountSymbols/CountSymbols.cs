using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Write a program that reads some text from the console and counts the occurrences 
 * of each character in it. Print the results in alphabetical (lexicographical) order.
 */

class CountSymbols
{
    static void Main()
    {
        char[] inputArr = Console.ReadLine().ToCharArray();
        Dictionary<char, int> counter = new Dictionary<char, int>();
        foreach (char inputChar in inputArr)
        {
            if (counter.ContainsKey(inputChar))
                counter[inputChar]++;
            else
                counter.Add(inputChar, 1);
        }

        char[] orderedKeys = counter.Keys.OrderBy(p => p).ToArray();
        foreach (char key in orderedKeys)
            Console.WriteLine("{0}: {1} time(s)", key, counter[key]);
    }
}
