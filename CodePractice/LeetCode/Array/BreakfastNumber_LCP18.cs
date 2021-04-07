using System;
using System.Globalization;
using CodePractice.Core;

namespace CodePractice.LeetCode.Array
{
    public class BreakfastNumber_LCP18 : LeetCodeBase
    {
        public BreakfastNumber_LCP18() : base("BreakfastNumber_LCP18")
        {
            var staple = new[] { 2,1,1 };
            var drinks = new[] { 8,9,5,1 };

            int x = 15;
            Console.WriteLine(BreakfastNumber(staple, drinks,x));
            Console.ReadKey();
        }

        public int BreakfastNumber(int[] staple, int[] drinks, int x)
        {
            System.Array.Sort(staple);
            System.Array.Sort(drinks);
            int index1 = 0;
            int index2 = drinks.Length - 1;
            int result = 0;
            for (int i = 0; i < staple.Length; i++)
            {
                while (index2 >= 0 && staple[i] + drinks[index2] > x)
                    index2--;
                if (index2 == -1)
                {
                    break;
                }
                result += (index2 + 1);
                result %= (int)(1E9 + 7);
            }
            return result;
        }
    }
}