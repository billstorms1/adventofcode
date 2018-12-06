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
            Console.WriteLine("The total is {0}.", result);
            Console.ReadLine();
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
            var file = new StreamReader(@"C:\Users\bstorms\Documents\Visual Studio 2017\Projects\AddEmUp\FrequencyChangeData.txt");
            
            while ((line = file.ReadLine()) != null)
                changes.Add(int.Parse(line));

            file.Close();
            return changes;
        }
    }
}