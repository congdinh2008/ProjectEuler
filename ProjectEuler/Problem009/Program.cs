using System;
using System.Diagnostics;

namespace Problem009
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 009 ============");
            Stopwatch clock = Stopwatch.StartNew();

            #region Brute Force

            //int a = 0, b = 0, c = 0;
            //int sum = 1000;
            //bool found = false;
            //for (a = sum/3; a >0; a--)
            //{
            //    for (b = a; b < sum / 2; b++)
            //    {
            //        c = sum - a - b;
            //        if (a * a + b * b == c * c)
            //        {
            //            found = true;
            //            break;
            //        }
            //    }
            //    if (found)
            //        break;
            //}
            //var num = a * b * c;

            #endregion

            #region Coprime

            int a = 0, b = 0, c = 0;
            int sum = 1000;
            int m = 0, k = 0, n = 0, d = 0;
            bool found = false;
            int mlimit = (int)Math.Sqrt(sum / 2);
            for (m = 2; m <= mlimit; m++)
            {
                if ((sum / 2) % m == 0)
                {
                    // m found
                    if (m % 2 == 0)
                        // Ensure that we find an odd number for k.
                        k = m + 1;
                    else
                        k = m + 2;
                    while (k < 2 * m && k <= sum / (2 * m))
                    {
                        if (sum / (2 * m) % k == 0 && GreatestCommonDivisor(k, m) == 1)
                        {
                            d = sum / 2 / (k * m);
                            n = k - m;
                            a = d * (m * m - n * n);
                            b = 2 * d * m * n;
                            c = d * (m * m + n * n);
                            found = true;
                            break;
                        }
                        k += 2;
                    }
                }
                if (found)
                    break;
            }
            var num = a * b * c;

            #endregion

            clock.Stop();
            Console.WriteLine($"a={a}, b={b}, c={c}, abc={num}");
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        private static int GreatestCommonDivisor(int a, int b)
        {
            int x = 0;
            int y = 0;
            if (a > b)
            {
                x = a;
                y = b;
            }
            else
            {
                x = b;
                y = a;
            }

            while (x % y != 0)
            {
                int temp = x;
                x = y;
                y = temp % x;
            }

            return y;
        }
    }
}
