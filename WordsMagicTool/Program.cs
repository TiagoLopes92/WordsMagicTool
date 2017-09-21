using System;
using System.Collections.Generic;

namespace WordsMagicTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************");
            Console.WriteLine("*    Words Magic Tool!   *");
            Console.WriteLine("**************************");

            var dictionary = DataLoader.Load("wordlist.txt");

            while (true)
            {
                var search = new Search();

                search.Letters = UserInput.GetLettersToSearch();
                search.WordDimensions = UserInput.GetWordDimensions();
                search.WordsDictionary = dictionary;

                var results = search.Execute();

                foreach (var item in results)
                {
                    PrintResults(item.Value, item.Key);
                }
            }

        }

        private static void PrintResults(IList<string> results, int d)
        {
            if (results.Count == 0)
            {
                Console.WriteLine("Results not founded for words with {0} letters!\n", d);
                return;
            }

            Console.WriteLine("Results for words with {0} letters!\n", d);

            foreach (var word in results)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();
        }
    }
}