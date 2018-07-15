using System;
using System.Diagnostics;

namespace Problem014
{
    internal class Program
    {
        private static void Main(string[] args)
        {            
            long sequenceLength = 0;
            long sequence;
            long startNum = 0;

            Stopwatch clock = Stopwatch.StartNew();

            int[] cache = new int[1000001];

            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = -1;
            }
            cache[1] = 1;

            for(int i=2; i <= 1000000;i++)
            {
                int k = 0;
                sequence = i;
                while (sequence != 1&&sequence>=i)
                {
                    k++;
                    if (sequence % 2 == 0)
                    {
                        sequence = sequence / 2;
                    }
                    else
                    {
                        sequence = 3 * sequence + 1;
                    }
                }

                cache[i] = k + cache[sequence];

                if (cache[i] > sequenceLength)
                {
                    sequenceLength = cache[i];
                    startNum = i;
                }
            }

            clock.Stop();
            
            Console.WriteLine("The starting number {0} produces a sequence of {1}",startNum, sequenceLength);
            Console.WriteLine("Solution took {0}ms", clock.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
