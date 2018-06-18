using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem007
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 007 ============");
            Stopwatch clock = Stopwatch.StartNew();
            int counter = 1;
            int result = 1;
            while (counter<10001)
            {
                result += 2;
                if (IsPrime2(result))
                {
                    counter++;
                }
            }

            clock.Stop();
            Console.WriteLine("The 10001st prime number is {0}", result);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        private static bool IsPrime(long number)
        {
            if (number == 2)
                return true;
            if (number < 2 || number % 2 == 0)
                return false;
            for (int i = 3; i < (number >> 1); i+=2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        private static bool IsPrime2(int numm)
        {
            if (numm <= 1)
            {
                return false;
            }

            if (numm == 2)
            {
                return true;
            }

            if (numm % 2 == 0)
            {
                return false;
            }

            int counter = 3;

            while ((counter * counter) <= numm)
            {
                if (numm % counter == 0)
                {
                    return false;
                }
                else
                {
                    counter += 2;
                }
            }

            return true;
        }
    }
}
