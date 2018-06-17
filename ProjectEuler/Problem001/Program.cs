using System;
using System.Diagnostics;

namespace Problem001
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 001 ============");
            Stopwatch clock = Stopwatch.StartNew();
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
            clock.Stop();
            Console.WriteLine("Sum of all multiples of 3 or 5 below 1000 = {0}", sum);
            Console.WriteLine("Solution took {0}ms", clock.ElapsedMilliseconds);
        }
    }
}
