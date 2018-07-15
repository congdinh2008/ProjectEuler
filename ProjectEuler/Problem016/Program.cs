using System;
using System.Diagnostics;
using System.Numerics;

namespace Problem016
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num = 1;
            BigInteger sum = 0;

            Stopwatch clock = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                num *= 2;
            }

            do
            {
                sum += num % 10;
                num = num / 10;
            } while (num >= 10);

            sum += num;

            clock.Stop();

            Console.WriteLine(sum);
            Console.WriteLine("Solution took {0}ms", clock.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
