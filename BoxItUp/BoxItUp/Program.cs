using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoxItUp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var codes = GetCodes();
            var checkSum = GetCheckSum(codes);
            Console.WriteLine(@"The checksum is {0}", checkSum);
            var commonLetter = GetCommonCharacters(codes);
            Console.WriteLine(@"The shared letters are of the correct box pair are {0}", commonLetter);
            Console.ReadKey();
        }

        public static string GetCommonCharacters(List<string> codes)
        {
            foreach (var code in codes)
            {
                foreach (var innerCode in codes)
                {
                    var difChars = 0;
                    var theIndex = 0;

                    for (var l = 0; l < code.Length; l++)
                    {
                        if (code[l] == innerCode[l]) continue;
                        difChars += 1;
                        theIndex = l;
                    }

                    if (difChars == 1)
                    return code.Remove(theIndex, 1);
                }
            }
            return "Unable to find correct boxes.";
        }

        public static List<string> GetCodes()
        {
            string line;
            var codes = new List<string>();
            var file = new StreamReader(@"C:\git\adventofcode\BoxItUp\BoxItUp\BoxIds.txt");

            while ((line = file.ReadLine()) != null)
            {
                codes.Add(line);
            }

            return codes;
        }

        public static int GetCheckSum(List<string> codes)
        {
            int dubz = 0;
            int tripz = 0;

            foreach (var code in codes)
            {
               var doubleChars = code.GroupBy(x => x)
                    .Where(group => @group.Count() == 2)
                    .Select(group => @group.Key);

                var tripleChars = code.GroupBy(x => x)
                    .Where(group => @group.Count() == 3)
                    .Select(group => @group.Key);

                if (doubleChars.Any())
                    dubz += 1;
                if (tripleChars.Any())
                    tripz += 1;
            }

            var checkSum = dubz * tripz;
            return checkSum;
        }
    }
}