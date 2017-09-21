using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMagicTool
{
    class Search
    {
        public string Letters { get; set; }
        public IList<int> WordDimensions { get; set; }
        /// <summary>
        /// Dictionary with words grouped by word length, to improve the search
        /// </summary>
        public IDictionary<int, IList<string>> WordsDictionary { get; set; }

        public IDictionary<int, IList<string>> Execute()
        {
            var allResults = new Dictionary<int, IList<string>>();

            foreach (var d in WordDimensions)
            {
                if (!WordsDictionary.ContainsKey(d) || d > Letters.Length) continue;
                List<string> results = SearchWords(WordsDictionary[d], Letters);

                allResults.Add(d, results);
            }

            return allResults;
        }

        private List<string> SearchWords(IList<string> list, string letters)
        {
            var results = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                if (PossibleWord(list[i], letters))
                {
                    results.Add(list[i]);
                }
            }
            return results;
        }

        private bool PossibleWord(string word, string letters)
        {
            var maxFail = letters.Length - word.Length;
            var fail = 0;
            var lettersCache = new Dictionary<char, int>();
            for (int i = 0; i < letters.Length; i++)
            {
                var letter = letters[i];
                if (!lettersCache.ContainsKey(letter)) lettersCache.Add(letter, -1);

                var position = word.IndexOf(letter, lettersCache[letter] + 1);
                if (position >= 0)
                {
                    lettersCache[letter] = position;
                    continue;
                }

                fail++;
                if (fail > maxFail) return false;
            }
            return true;
        }
    }
}
