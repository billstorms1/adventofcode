using System;
using System.Collections.Generic;
using System.IO;

namespace AddEmUp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var changes = GetValues();
            var result = Calculate(changes);
            Console.WriteLine("The final frequency value (sum of changes) is {0}.", result);
            var firstDupe = FindFirstDuplicateFrequency(changes);
            Console.WriteLine();
            Console.WriteLine("The first frequency to be duplicated is {0}", firstDupe);
            Console.ReadLine();
        }

        public static int FindFirstDuplicateFrequency(List<int> changes)
        {
            var done = false;
            var firstDupe = 0;
            var currentFreq = 0;
            var freqs = new List<int>();

            while (!done)
                foreach (var change in changes)
                {
                    currentFreq += change;
                    if (freqs.Contains(currentFreq))
                    {
                        firstDupe = currentFreq;
                        done = true;
                        break;
                    }

                    freqs.Add(currentFreq);
                }

            return firstDupe;
        }

        public static int Calculate(List<int> changes)
        {
            var total = 0;

            foreach (var change in changes) total += change;
            return total;
        }

        public static List<int> GetValues()
        {
            string line;
            var changes = new List<int>();
            var file = new StreamReader(@"C:\git\adventofcode\AddEmUp\FrequencyChangeData.txt");

            while ((line = file.ReadLine()) != null)
                changes.Add(int.Parse(line));

            file.Close();
            return changes;
        }
    }
}