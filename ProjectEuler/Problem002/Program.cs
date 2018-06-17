using System;
using System.Diagnostics;

namespace Problem002
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 002 ============");
            Stopwatch clock = Stopwatch.StartNew();
            int fib1 = 1;
            int fib2 = 1;
            int fib3 = 0;
            int sum = 0;
            while(fib3<4000000)
            {
                if ((fib3 % 2) == 0)
                    sum += fib3;
                fib3 = fib1 + fib2;
                fib1 = fib2;
                fib2 = fib3;
            }

            clock.Stop();

            Console.WriteLine("Sum of all Fibonacci number below four million = {0}", sum);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }
    }
}
