using System;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = "The “C# Professional” course includes the topics I discuss in my CLR via C# book and teaches how the CLR works thereby showing you how to develop applications and reusable components for the .NET Framework.";

            var sortedGroups = sentence
            .Split(' ')
            .GroupBy(w => w.Length)
            .OrderBy(g => g.Key);

            foreach (var group in sortedGroups)
            {
                Console.Write($"Words of length: {group.Key}, ");
                var uniqueWords = group.Distinct();
                Console.WriteLine($"Count: {uniqueWords.Count()}");
                Console.WriteLine($"{string.Join("\n", uniqueWords)}");
            }

            Console.ReadLine();
        }
    }
}

