using System;
using System.Linq;

namespace CodePractice.LeetCode.Bit
{
    public class SortByBits_1356
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
    }
}