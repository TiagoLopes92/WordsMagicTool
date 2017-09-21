using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMagicTool
{
    public static class UserInput
    {
        public static string GetLettersToSearch()
        {
            Console.WriteLine("Insert Letters To Search!!!");
            return Console.ReadLine().Trim().ToLower();
        }

        public static IList<int> GetWordDimensions()
        {
            var dimensions = new List<int>();
            var dimension = -1;

            Console.WriteLine("Insert de words dimension. Indicate one dimention and press enter. Use 0 to finalize the insertion");

            while (dimension != 0)
            {
                var input = Console.ReadLine();

                if (int.TryParse(input, out dimension))
                {
                    if (dimensions.Contains(dimension)) continue;

                    dimensions.Add(dimension);
                }
            }

            Console.WriteLine("Dimensions inserted.");

            return dimensions;
        }
    }
}
