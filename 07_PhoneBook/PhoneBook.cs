using System;
using System.Collections.Generic;
using System.Linq;

class PhoneBook
{
    static void Main()
    {
        string line = Console.ReadLine().Trim();

        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        //fill the phonebook
        while (!line.Equals("search"))
        {
            string[] items = line.Split('-');

            if (phonebook.ContainsKey(items[0]))
                phonebook.Remove(items[0]);
            phonebook.Add(items[0], items[1]);

            line = Console.ReadLine().Trim();
        }

        //print search results:
        line = Console.ReadLine().Trim();
        while (line.Length > 0)
        {
            if (phonebook.ContainsKey(line))
                Console.WriteLine("{0} -> {1}", line, phonebook[line]);
            else
                Console.WriteLine("Contact {0} does not exist.", line);

            line = Console.ReadLine().Trim();
        }
    }
}