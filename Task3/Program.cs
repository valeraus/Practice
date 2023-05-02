using System;
using System.Diagnostics;

class Program
{
    /*
    The FibonacciIterative method takes an integer n as input and returns the nth Fibonacci number using an iterative approach. 
    The method uses a for loop to generate the sequence up to the nth Fibonacci number. The time complexity of this method is O(n), 
    since it needs to loop n times to generate the nth Fibonacci number. The space complexity of this method is O(1), 
    since it only uses a constant amount of space for storing the previous and current values.

    The FibonacciRecursive method takes an integer n as input and returns the nth Fibonacci number using a recursive approach. 
    The method calls itself recursively with the previous two Fibonacci numbers to generate the nth number. 
    The time complexity of this method is O(2^n), 
    since each call to the method results in two more calls until it reaches the base cases. 
    The space complexity of this method is O(n), since it needs to store n recursive calls on the call stack.
     */
    static int FibonacciIterative(int n)
    {
        if (n == 0)
            return 0;

        if (n == 1)
            return 1;

        int previous = 0;
        int current = 1;
        int result = 0;

        for (int i = 2; i <= n; i++)
        {
            result = previous + current;
            previous = current;
            current = result;
        }
        return result;
    }
    static int FibonacciRecursive(int n)
    {
        if (n == 0)
            return 0;

        if (n == 1)
            return 1;

        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }
    static void Main(string[] args)
    {
        int n = 40;
        // Find the nth Fibonacci number using iterative approach
        Stopwatch sw = Stopwatch.StartNew();
        int fibonacciIterative = FibonacciIterative(n);
        sw.Stop();
        Console.WriteLine($"The {n}th Fibonacci number (iterative) is {fibonacciIterative}");
        Console.WriteLine($"Time taken for iterative approach: {sw.ElapsedMilliseconds} ms");

        // Find the nth Fibonacci number using recursive approach
        sw = Stopwatch.StartNew();
        int fibonacciRecursive = FibonacciRecursive(n);
        sw.Stop();
        Console.WriteLine($"The {n}th Fibonacci number (recursive) is {fibonacciRecursive}");
        Console.WriteLine($"Time taken for recursive approach: {sw.ElapsedMilliseconds} ms");

        Console.ReadLine();
    }
}
