using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problem004
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Problem 004 ============");
            Stopwatch clock = Stopwatch.StartNew();

            #region Check number
            //int number = 906609;
            //char[] arrayNum = number.ToString().ToCharArray();
            //var list1 = new List<char>();
            //var list2 = new List<char>();

            //int counter = number.ToString().Length;
            //for (int i = 0; i < counter; i++)
            //{
            //    if (i <= (counter / 2) - 1)
            //        list1.Add(arrayNum[i]);
            //    else
            //        list2.Add(arrayNum[i]);
            //}

            //Console.WriteLine("List 1:");
            //list1.ForEach(x => Console.WriteLine(x));
            //Console.WriteLine("List 2:");
            //list2.ForEach(x => Console.WriteLine(x));

            //var boolCompareWithoutOrder = list1.CompareWithoutOrder(list2, false);

            //Console.WriteLine("Number {0} is {1}palindromic", number, boolCompareWithoutOrder ? "" : "not ");
            #endregion

            #region wrong

            //var numberPalindromic = new List<int>();
            //int i = 900;
            //int number = 0;
            //while (i < 999)
            //{
            //    for (int k = 999; k > 900; k--)
            //    {
            //        number = i * k;

            //        char[] arrayNum = number.ToString().ToCharArray();
            //        var list1 = new List<char>();
            //        var list2 = new List<char>();

            //        int counter = number.ToString().Length;
            //        for (int l = 0; l < counter; l++)
            //        {
            //            if (l <= (counter / 2) - 1)
            //                list1.Add(arrayNum[l]);
            //            else
            //                list2.Add(arrayNum[l]);
            //        }

            //        var boolCompareWithoutOrder = list1.CompareWithoutOrder(list2, false);

            //        if (boolCompareWithoutOrder == true)
            //        {
            //            numberPalindromic.Add(number);
            //        }
            //    }
            //    i++;
            //}

            //Console.WriteLine("List Palindromic Number: ");
            //numberPalindromic.ForEach(x => Console.WriteLine(x));

            #endregion

            bool found = false;
            int firstHalf = 998, palin = 0;
            int[] factors = new int[2];

            while (!found)
            {
                firstHalf--;
                palin = MakePalindromicNumber(firstHalf);

                for (int i = 999; i >900; i--)
                {
                    if ((palin / i) > 999 || i * i < palin)
                        break;

                    if (palin % i == 0)
                    {
                        found = true;
                        factors[0] = palin / i;
                        factors[1] = i;
                        break;
                    }
                }
            }

            clock.Stop();
            Console.WriteLine("The largest palindromic is {0}, which is made from {1}*{2}", palin, factors[0], factors[1]);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        private static int MakePalindromicNumber(int firstHalf)
        {
            char[] reversed = firstHalf.ToString().Reverse().ToArray();
            return Convert.ToInt32(firstHalf + new string(reversed));
        }

        private static bool IsPalindromicNumber(int number)
        {
            char[] arrayNum = number.ToString().ToCharArray();
            var list1 = new List<char>();
            var list2 = new List<char>();

            int counter = number.ToString().Length;
            for (int i = 0; i < counter; i++)
            {
                if (i < (counter / 2) - 1)
                    list1.Add(arrayNum[i]);
                else
                    list2.Add(arrayNum[i]);
            }

            var boolCompareWithoutOrder = list1.CompareWithoutOrder(list2, false);

            return boolCompareWithoutOrder;
        }

        public static bool CompareWithoutOrder<T>(this IList<T> list1, IList<T> list2, bool isOrdered = true)
        {
            if (list1 == null && list2 == null)
                return true;
            if (list1 == null || list2 == null || list1.Count != list2.Count)
                return false;

            if (isOrdered)
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    var l1 = list1[i];
                    var l2 = list2[i];

                    if (
                        (l1 == null & l2 == null) ||
                        (l1 != null && l2 == null) ||
                        (!l1.Equals(l2))
                        )
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                List<T> list2Copy = new List<T>(list2);
                for (int i = 0; i < list1.Count; i++)
                {
                    if (!list2Copy.Remove(list1[i]))
                        return false;
                }
                return true;
            }
        }
    }
}
