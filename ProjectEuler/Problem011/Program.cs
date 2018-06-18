using System;
using System.Diagnostics;
using System.IO;

namespace Problem011
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 004 ============");
            Stopwatch clock = Stopwatch.StartNew();
            string fileName = "input.txt";
            const int numbersInProduct = 4;
            decimal product = 0;

            int[,] inputSquare = ReadInput(fileName);
            for (int col = 0; col < inputSquare.GetLength(0); col++)
            {
                for (int row = 0; row < inputSquare.GetLength(1); row++)
                {
                    decimal tempProduct;

                    //Check Vertically
                    if (row < inputSquare.GetLength(0) - numbersInProduct)
                    {
                        tempProduct = inputSquare[col, row];
                        for (int i = 1; i < numbersInProduct; i++)
                        {
                            tempProduct *= inputSquare[col, row + i];
                        }
                        product = Math.Max(product, tempProduct);
                    }

                    // Check Horisontally
                    if (col < inputSquare.GetLength(1) - numbersInProduct)
                    {
                        tempProduct = inputSquare[col, row];
                        for (int i = 1; i < numbersInProduct; i++)
                        {
                            tempProduct *= inputSquare[col + i, row];
                        }
                        product = Math.Max(product, tempProduct);
                    }

                    // Check Diagonally Upwards/Forwards
                    if (col < inputSquare.GetLength(0) - numbersInProduct && (row >= numbersInProduct))
                    {
                        tempProduct = inputSquare[col, row];
                        for (int i = 1; i < numbersInProduct; i++)
                        {
                            tempProduct *= inputSquare[col + i, row - i];
                        }
                        product = Math.Max(product, tempProduct);
                    }

                    // Check Diagonally Downwards/Forwards
                    if (row < inputSquare.GetLength(0) - numbersInProduct && (col < inputSquare.GetLength(1) - numbersInProduct))
                    {
                        tempProduct = inputSquare[col, row];
                        for (int i = 1; i < numbersInProduct; i++)
                        {
                            tempProduct *= inputSquare[col + i, row + i];
                        }
                        product = Math.Max(product, tempProduct);
                    }
                }
            }



            clock.Stop();
            Console.WriteLine("The greatest product of four adjacent numbers is {0}", product);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        private static int[,] ReadInput(string fileName)
        {
            int lines = 0;
            string line;
            string[] linePieces;

            StreamReader streamReader = new StreamReader(fileName);
            while (streamReader.ReadLine() != null)
                lines++;

            int[,] inputSquare = new int[lines, lines];
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                linePieces = line.Split(' ');
                for (int i = 0; i < linePieces.Length; i++)
                {
                    inputSquare[j, i] = int.Parse(linePieces[i]);
                }
                j++;
            }

            streamReader.Close();

            return inputSquare;
        }
    }
}
