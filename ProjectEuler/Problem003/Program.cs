using System;
using System.Diagnostics;

namespace Problem003
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 003 ============");
            Stopwatch clock = Stopwatch.StartNew();

            #region Brute forcing 1 - super slow
            //const long num = 600851475143;
            //long largestPrimeFactor = 0;
            //for(long i = 2; i < num; i++)
            //{
            //    if (num % i == 0)
            //    {
            //        bool isPrime = true;
            //        for (long j = 2; j < i; i++)
            //        {
            //            if (i % j == 0)
            //            {
            //                isPrime = false;
            //                break;
            //            }
            //        }
            //        if (isPrime)
            //        {
            //            largestPrimeFactor = i;
            //        }
            //    }
            //}
            #endregion

            #region Brute forcing 2 - very slow

            //uint largestPrimeFactor = 0;
            //uint sqrtNum = Convert.ToUInt32(Math.Sqrt(600851475143));
            //for (uint i = sqrtNum; i >= 3; i--)
            //{
            //    if (IsPrime(i) == true && 600851475143 % i == 0)
            //    {
            //        Console.WriteLine(i);
            //        largestPrimeFactor = i;
            //        break;
            //    }

            //}

            #endregion

            #region Brute forcing 3 - faster
            //const long num = 600851475143;
            //long largestPrimeFactor = 0;
            //long[] factors = new long[2];

            //for (long i = 2; i*i < num; i++)
            //{
            //    if (num % i == 0)
            //    {
            //        factors[0] = i;
            //        factors[1] = num / i;
            //        for(int k = 0; k < 2; k++)
            //        {
            //            bool isPrime = true;
            //            for (long j = 2; j*j < factors[k]; j++)
            //            {
            //                if (factors[k] % j == 0)
            //                {
            //                    isPrime = false;
            //                    break;
            //                }
            //            }
            //            if (isPrime&&factors[k]>largestPrimeFactor)
            //            {
            //                largestPrimeFactor = factors[k];
            //            }
            //        }
            //    }
            //}
            #endregion

            #region Alternative Solution - very fast

            const long num = 600851475143;
            long newnum = num;
            long largestPrimeFactor = 0;

            int counter = 2;
            while (counter * counter <= newnum)
            {
                if (newnum % counter == 0)
                {
                    newnum = newnum / counter;
                    largestPrimeFactor = counter;
                }
                else
                {
                    counter++;
                }
            }
            if (newnum > largestPrimeFactor)
            { // the remainder is a prime number
                largestPrimeFactor = newnum;
            }

            #endregion


            clock.Stop();

            Console.WriteLine("The largest prime factor of 600851475143 is: {0}", largestPrimeFactor);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        private static bool IsPrime(uint number)
        {
            if (number == 2)
                return true;

            if (number < 2 || number % 2 == 0)
                return false;

            for (uint i = 3; i < (number >> 1); i += 2)
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
