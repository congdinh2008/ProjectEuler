using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace Problem013
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 013 ============");
            Stopwatch clock = Stopwatch.StartNew();

            string fileName = "input.txt";
            string line;
            BigInteger result = new BigInteger();

            StreamReader streamReader = new StreamReader(fileName);
            while ((line = streamReader.ReadLine())!= null)
                result += BigInteger.Parse(line);

            streamReader.Close();

            clock.Stop();
            Console.WriteLine($"The first ten digits are: {result.ToString().Substring(0,10)}");
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }
    }
}
