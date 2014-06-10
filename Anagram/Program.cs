using System;
using System.Collections.Generic;
using System.IO;

/* A simple program to generate possible anagrams given a list of words.
 * The program reads a file of words with one word per line,
 * creates a hash table with sorted letters of the word as key.
 * Every word with the same sorted letters, i.e. anagrams, 
 * will be stored under the same key.
 */
class Anagrams
{
    // sort letters. e.g. "bfcad" will return "abcdf"
    static string SortLetters(string s)
    {
        char[] a = s.ToCharArray();
        Array.Sort(a);
        return new string(a);
    }

    static void Main()
    {
        // read input list of words
        StreamReader sr = new StreamReader("wordlist.txt");
        Dictionary<string, string> dict = new Dictionary<string, string>();

        string line;
        while ((line = sr.ReadLine()) != null)
        {
            // sort letters of each word that will make the keys
            string key = SortLetters(line);
            string value;

            // append anagrams according to key
            if (dict.TryGetValue(key, out value))
                dict[key] = value + " " + line;
            else
                dict.Add(key, line);
        }

        //StreamWriter sw = new StreamWriter("tmp.txt");
        // display output
        foreach (KeyValuePair<string, string> kv in dict)
        {
            Console.WriteLine(kv.Value);
            //sw.WriteLine(kv.Value);
        }
    }
}
