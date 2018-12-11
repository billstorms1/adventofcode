using System;
using System.Collections.Generic;
using System.IO;

namespace NoMatterHowYouSliceIt
{
    class Program
    {
        static void Main(string[] args)
        {

            var values = GetValues();


            var overlappingSquares = GetCoordinants(values);

        }

        private static int GetCoordinants(string[] values)
        {
            var fabric = new Dictionary<int, Dictionary<int, int>>();

            foreach (var value in values)
             {
                var split = value.Split('@', ':', ',', 'x');
                var left = Int32.Parse(split[1]);
                var top = Int32.Parse(split[2]);
                var width = Int32.Parse(split[3]);
                var height = Int32.Parse(split[4]);
                
                for (var w = left; w < left + width; ++w)
                 {
                     for (var l = top; l < top + height; ++l)
                     {
                         if (!fabric.TryGetValue(w, out var locDictionary))
                         {
                             locDictionary = new Dictionary<int, int>();
                             fabric[w] = locDictionary;
                         }
                         
                         if (!locDictionary.TryGetValue(l, out var fabricLoc))
                         {
                             fabricLoc = 0;
                         }

                         ++fabricLoc;
                         locDictionary[l] = fabricLoc;
                    }
                 }
             }

            int overlappingSquares = 0;
            for (int x = 0; x < 1000; ++x)
            {
                for (int y = 0; y < 1000; ++y)
                {
                    if (fabric.TryGetValue(x, out var gridDictY))
                    {
                        if (gridDictY.TryGetValue(y, out var fabricLoc))
                        {
                            if (fabricLoc > 1)
                            {
                                overlappingSquares++;
                            }
                        }
                    }
                }
            }

            return overlappingSquares;

        }

        public static string[] GetValues()
        {
            var changes = File.ReadAllLines(@"C:\git\adventofcode\NoMatterHowYouSliceIt\NoMatterHowYouSliceIt\TestData.txt");
            return changes;
        }
    }
}
