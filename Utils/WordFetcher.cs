/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System.Collections.Generic;

namespace _312554Hangman.Utils
{
    /// <summary>
    /// Reads text files and returns a list of each line as a string.
    /// </summary>
    public static class WordFetcher
    {
        public static List<string> FetchWords(string difficulty){
            System.IO.StreamReader reader = new System.IO.StreamReader("Words/" + difficulty + ".txt");
            List<string> result = new List<string>();

            while (!reader.EndOfStream)
                result.Add(reader.ReadLine());

            return result;
        }
    }
}