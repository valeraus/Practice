using System;

namespace Task2
{
    internal class Program
    {
        static int[] RemoveDuplicates(int[] sortedArray)
        {
            int[] uniqueArray = new int[sortedArray.Length];
            int uniqueIndex = 0;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (i == 0 || sortedArray[i] != sortedArray[i - 1])
                {
                    uniqueArray[uniqueIndex++] = sortedArray[i];
                }
            }
            Array.Resize(ref uniqueArray, uniqueIndex);
            return uniqueArray;
        }
        static void Main(string[] args)
        {
            int[] sortedArray = { 1, 2, 3, 4, 4, 56 };
            int[] uniqueArray = RemoveDuplicates(sortedArray);
            Console.WriteLine(string.Join(", ", uniqueArray));
            Console.ReadLine();
        }
    }
}
