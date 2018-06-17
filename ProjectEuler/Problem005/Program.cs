using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem005
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 005 ============");
            Stopwatch clock = Stopwatch.StartNew();

            #region Solution 1

            //int i = 1;
            //while (i % 2 != 0 || i % 3 != 0 || i % 4 != 0 || i % 5 != 0
            //    || i % 6 != 0 || i % 7 != 0 || i % 8 != 0 || i % 9 != 0
            //    || i % 10 != 0 || i % 11 != 0 || i % 12 != 0
            //    || i % 13 != 0 || i % 14 != 0 || i % 15 != 0
            //    || i % 16 != 0 || i % 17 != 0 || i % 18 != 0
            //    || i % 19 != 0 || i % 20 != 0)
            //{
            //    i++;
            //}

            #endregion

            #region Solution 2

            //int i = 20;
            //while (i % 2 != 0 || i % 3 != 0 || i % 4 != 0 || i % 5 != 0
            //    || i % 6 != 0 || i % 7 != 0 || i % 8 != 0 || i % 9 != 0
            //    || i % 10 != 0 || i % 11 != 0 || i % 12 != 0
            //    || i % 13 != 0 || i % 14 != 0 || i % 15 != 0
            //    || i % 16 != 0 || i % 17 != 0 || i % 18 != 0
            //    || i % 19 != 0 || i % 20 != 0)
            //{
            //    i += 20;
            //}

            #endregion

            #region Solution 3 - Prime factorisation

            int divisorMax = 20;
            int[] primes = GeneratePrimes(divisorMax);
            int result = 1;

            for (int i = 0; i < primes.Length; i++)
            {
                int a = (int)Math.Floor(Math.Log(divisorMax) / Math.Log(primes[i]));
                result = result * ((int)Math.Pow(primes[i], a));
            }
            
            #endregion

            clock.Stop();

            Console.WriteLine("The smallest number dividable with all number 1-20 is {0}", result);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        private static int[] GeneratePrimes(int divisorMax)
        {
            List<int> primes = new List<int>();
            bool isPrime;
            int j;
            primes.Add(2);

            for (int i = 3; i <= divisorMax; i+=2)
            {
                j = 0;
                isPrime = true;
                while (primes[j] * primes[j] <= i)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    j++;
                }
                if (isPrime)
                    primes.Add(i);
            }

            return primes.ToArray();
        }
    }
}
