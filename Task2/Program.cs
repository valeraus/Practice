using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static int[] RemoveDuplicates(int[] sortedArray)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (i == 0 || sortedArray[i] != sortedArray[i - 1])
                {
                    linkedList.AddLast(sortedArray[i]);
                }
            }
            int[] uniqueArray = new int[linkedList.Count];
            int index = 0;
            foreach (int number in linkedList)
            {
                uniqueArray[index++] = number;
            }
            return uniqueArray;
        }

        static int[] RemoveDuplicatesSorted(int[] inputArray)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            foreach (int number in inputArray)
            {
                if (!linkedList.Contains(number))
                {
                    linkedList.AddLast(number);
                }
            }

            int[] uniqueArray2 = new int[linkedList.Count];
            int index = 0;
            foreach (int number in linkedList)
            {
                uniqueArray2[index++] = number;
            }

            Array.Sort(uniqueArray2);
            return uniqueArray2;
        }
        static void Main(string[] args)
        {
            int[] sortedArray = { 1, 2, 3, 4, 4, 56 };
            int[] uniqueArray = RemoveDuplicates(sortedArray);
            Console.WriteLine(string.Join(", ", uniqueArray));

            int[] inputArray = { 4, 1, 3, 4, 4, 56 };
            int[] uniqueArray2 = RemoveDuplicatesSorted(inputArray);
            Console.WriteLine(string.Join(", ", uniqueArray2));

            Console.ReadKey();
        }
    }
}
