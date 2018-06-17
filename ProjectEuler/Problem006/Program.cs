using System;
using System.Diagnostics;

namespace Problem006
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 004 ============");
            Stopwatch clock = Stopwatch.StartNew();

            long sumOfSquares = 0;
            long squareOfSum = 0;
            
            for (int i = 1; i <= 100; i++)
            {
                sumOfSquares += i * i;
                squareOfSum += i;
            }
            squareOfSum = squareOfSum * squareOfSum;
            long result = squareOfSum-sumOfSquares;

            clock.Stop();
            Console.WriteLine("Hence the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum is {0} - {1} = {2}", squareOfSum, sumOfSquares, result);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }
    }
}
