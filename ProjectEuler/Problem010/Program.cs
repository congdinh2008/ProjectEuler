using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem010
{
    class Program
    {
        const int numm = 2000000;

        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 004 ============");
            BruteForce();
            TrialDivision();
            SieveOfEratosthenes();
            SieveOfAtkin();
        }

        #region Brute Force
        private static void BruteForce()
        {
            Stopwatch clock = Stopwatch.StartNew();

            long sum = 0;
            int i = 0;
            while (i < numm)
            {
                if (IsPrime(i))
                    sum += i;
                i++;
            }

            clock.Stop();
            Console.WriteLine("BruteForce: Sum of all primes below two million is {0}", sum);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        #endregion

        #region Trial Division
        private static void TrialDivision()
        {
            Stopwatch clock = Stopwatch.StartNew();

            int[] primes = TrialDivisionPrimes(numm);
            decimal sum = 0;

            for (int i = 0; i < primes.Length; i++)
            {
                sum += primes[i];
            }

            clock.Stop();
            Console.WriteLine("Trial Division: Sum of all primes below two million is {0}", sum);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        private static int[] TrialDivisionPrimes(int upperLimit)
        {

            int counter = 3;
            bool isPrime;
            int j;
            List<int> primes = new List<int>();

            primes.Add(2);

            while (counter <= upperLimit)
            {
                j = 0;
                isPrime = true;
                while (primes[j] * primes[j] <= counter)
                {
                    if (counter % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    j++;
                }
                if (isPrime)
                {
                    primes.Add(counter);
                }
                counter += 2;
            }

            return primes.ToArray();
        }

        #endregion

        #region Sieve of Erastosthenes
        private static void SieveOfEratosthenes()
        {
            Stopwatch clock = Stopwatch.StartNew();

            int[] primes = ESieve(numm);

            decimal sum = 0;

            for (int i = 0; i < primes.Length; i++)
            {
                sum += primes[i];
            }

            clock.Stop();
            Console.WriteLine("Sieve of Eratosthenes: Sum of all primes below two million is {0}", sum);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }


        private static int[] ESieve(int upperLimit)
        {

            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);
            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray();
        }
        #endregion

        #region Sieve of Atkin
        private static void SieveOfAtkin()
        {
            Stopwatch clock = Stopwatch.StartNew();

            int[] primes = ASieve(numm);

            decimal sum = 0;

            for (int i = 0; i < primes.Length; i++)
            {
                sum += primes[i];
            }

            clock.Stop();
            Console.WriteLine("Sieve of Atkin: Sum of all primes below two million is {0}", sum);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }


        private static int[] ASieve(int upperLimit)
        {

            BitArray PrimeBits = new BitArray(upperLimit + 1, false);
            int upperSqrt = (int)Math.Sqrt(upperLimit);

            for (int i = 1; i <= upperSqrt; i++)
            {
                for (int j = 1; j <= upperSqrt; j++)
                {

                    int n = 4 * i * i + j * j;
                    if (n <= upperLimit && (n % 12 == 1 || n % 12 == 5))
                    {
                        PrimeBits.Set(n, !PrimeBits.Get(n));
                    }
                    n = 3 * i * i + j * j;
                    if (n <= upperLimit && (n % 12 == 7))
                    {
                        PrimeBits.Set(n, !PrimeBits.Get(n));
                    }
                    n = 3 * i * i - j * j;
                    if (i > j && n <= upperLimit && (n % 12 == 11))
                    {
                        PrimeBits.Set(n, !PrimeBits.Get(n));
                    }
                }
            }

            for (int i = 5; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * i; j <= upperLimit; j += i * i)
                    {
                        PrimeBits.Set((int)j, false);
                    }
                }
            }

            List<int> numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(3);
            for (int i = 5; i <= upperLimit; i += 2)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(i);
                }
            }

            return numbers.ToArray();
        }

        #endregion

        private static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;

            int counter = 3;

            while ((counter * counter) <= number)
            {
                if (number % counter == 0)
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
