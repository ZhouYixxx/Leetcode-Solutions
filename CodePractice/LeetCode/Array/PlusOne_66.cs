/*
66. 加一
给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。
最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。
你可以假设除了整数 0 之外，这个整数不会以零开头。

示例 1:
输入: [1,2,3]
输出: [1,2,4]
解释: 输入数组表示数字 123。
 */
using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.Array
{
    public class PlusOne_66 : LeetCodeBase
    {
        /// <summary>
        /// 方法一：用一个新数组ans保存结果，时间复杂度O(n)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int[] PlusOne(int[] digits)
        {
            //add表示进位，初始值为1表示个位加一
            int add = 1;
            //ans的位数可能比digits多一位
            int[] ans = new int[digits.Length + 1];
            for (int i = ans.Length-1; i >= 1; i--)
            {
                int digit = digits[i - 1];
                digit += add;
                //digit为10，则下一位需要进位，add=1
                if (digit == 10)
                {
                    ans[i] = 0;
                    add = 1;
                    continue;
                }
                //无需进位, add = 0
                ans[i] = digit;
                add = 0;
            }
            //结束后add=1，说明最高位还需要进位
            if (add == 1)
            {
                ans[0] += 1;
            }
            //最高位为0，应该移除以符合书写习惯
            if (ans[0] == 0)
            {
                var newAns = new int[digits.Length];
                for (int i = 1; i < ans.Length; i++)
                {
                    newAns[i-1] = ans[i];
                }
                return newAns;
            }
            return ans;
        }

        /// <summary>
        /// 方法二：方法一的代码简化，时间复杂度O(n)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int[] PlusOne1(int[] digits)
        {
            for (int i = digits.Length -1; i >= 0; i--)
            {
                digits[i]++;
                digits[i] = digits[i] % 10;
                //无需进位，，此时直接返回即可
                if (digits[i] != 0)
                {
                    return digits;
                }
            }
            //此时发现各位都是0，应该是出现了类型9999+1这样的情况，最高位直接设置为1即可
            digits = new int[digits.Length+1];
            digits[0] = 1;
            return digits;
        }

        public static void Test()
        {
            var digits = new int[] { 9,9,8,9 };
            var nums = PlusOne1(digits);
            foreach (var num in nums)
            {
                Console.Write(num + "  ");
            }
            Console.ReadKey();
        }

        public PlusOne_66() : base("PlusOne_66")
        {
            Test();
        }
    }
}