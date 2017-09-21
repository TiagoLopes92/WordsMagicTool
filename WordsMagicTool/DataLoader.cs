using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordsMagicTool
{
    class DataLoader
    {
        public static IDictionary<int, IList<string>> Load(string path)
        {
            var words = new Dictionary<int, IList<string>>();
            var wordsCounter = 0;
            var fileStream = new FileStream("wordlist.txt", FileMode.Open);
            string line = null;
            using (var steamReader = new StreamReader(fileStream))
            {
                while ((line = steamReader.ReadLine()) != null)
                {
                    var key = line.Length;
                    var value = line.ToLower().Trim();
                    if (words.ContainsKey(key))
                    {
                        words[key].Add(value);
                    }
                    else
                    {
                        words.Add(key, new List<string> { value });
                    }
                    wordsCounter++;
                }
            }

            Console.WriteLine("Loaded {0} word(s)", wordsCounter);

            return words;
        }
    }
}
