using System;
using System.Linq;
using CodePractice.Core;

namespace CodePractice.LeetCode.Bit
{
    public class SortByBits_1356 : LeetCodeBase
    {
        public int[] SortByBits(int[] arr)
        {
            var newArr = arr.OrderBy(t =>
            {
                var count = GetOneCount(t);
                return count;
            }).ThenBy(t => t).ToArray();
            return newArr;
        }

        public int GetOneCount(int number)
        {
            int count = 0;
            while (number > 0)
            {
                //n与n-1取与运算，一次可以去掉一个1
                number = number & (number - 1);
                count++;
            }
            return count;
        }

        public void Test()
        {
            var array = new int[] { 50,50 };
            var newArr = SortByBits(array);
            foreach (var value in newArr)
            {
                Console.Write(value+", ");
            }
            Console.ReadKey();
        }

        public SortByBits_1356() : base("SortByBits_1356")
        {
            Test();
        }
    }
}