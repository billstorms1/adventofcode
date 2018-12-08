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
            Console.ReadKey();
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