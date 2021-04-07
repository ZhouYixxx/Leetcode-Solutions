using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.Greedy
{
    public class MonotoneIncreasingDigits_738 : LeetCodeBase
    {
        public MonotoneIncreasingDigits_738() : base("MonotoneIncreasingDigits_738")
        {
            int N = 1234;
            Console.WriteLine(MonotoneIncreasingDigits1(N));
            Console.ReadKey();
        }

        public int MonotoneIncreasingDigits(int N)
        {
            if (N < 10)
            {
                return N - 1;
            }
            var nums = N.ToString().ToCharArray();
            var index = 0;
            bool found = false;
            for (int i = 1; i < nums.Length && !found; i++)
            {
                if ((nums[i-1]-'0') <= (nums[i]-'0'))
                {
                    index = i;
                    continue;
                }
                //nums[i-1]>nums[i],此时应该让nums[index]--，但同时要查看更前面的字符大小是否会发生变化
                while (index >= 0)
                {
                    nums[index]--;
                    if (index == 0)
                    {
                        found = true;
                        break;
                    }
                    if (nums[index] >= nums[index - 1])
                    {
                        found = true;
                        break;
                    }
                    index--;
                }
            }
            for (int i = index+1; i < nums.Length; i++)
            {
                nums[i] = '9';
            }
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                res = 10 * res + nums[i] - '0';
            }
            return res;
        }

        /// <summary>
        /// 优化方法，从右向左遍历
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int MonotoneIncreasingDigits1(int N)
        {
            if (N < 10)
            {
                return N - 1;
            }
            var nums = N.ToString().ToCharArray();
            var index = nums.Length;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if ((nums[i - 1] - '0') > (nums[i] - '0'))
                {
                    index = i;
                    nums[i - 1]--;
                }
            }
            for (int i = index; i < nums.Length; i++)
            {
                nums[i] = '9';
            }
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                res = 10 * res + nums[i] - '0';
            }
            return res;
        }
    }
}