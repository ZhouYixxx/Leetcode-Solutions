using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.Core;

namespace CodePractice.LeetCode.Math
{
    /// <summary>
    /// 移除k个数字，保证剩下的数字最小，注意不改变数字之间的相对顺序
    /// </summary>
    public class RemoveKDigits_402 : LeetCodeBase
    {
        public RemoveKDigits_402() : base("RemoveKDigits_402")
        {
            var num = "10";
            var k = 2;
            Console.WriteLine(RemoveKdigits2(num,k));
            Console.ReadKey();
        }

        /// <summary>
        /// 不使用栈
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RemoveKdigits2(string num, int k)
        {
            var nums = num.ToCharArray();
            if (nums.Length == 0)
            {
                return "0";
            }
            var s = new StringBuilder(num);
            //每次都找到要移除的数字,将其删除，循环k次
            for (int i = 0; i < k; i++)
            {
                int index = 0;
                for (int j = 1; j < s.Length; j++)
                {
                    //s[j] < s[j-1]说明应该移除j处的字符
                    if (s[j] < s[j-1])
                        break;
                    index = j;
                }
                s.Remove(index, 1);
            }
            //处理多余的0
            while (s.Length > 1 && s[0] == '0')
            {
                s.Remove(0, 1);
            }
            return string.IsNullOrEmpty(s.ToString()) ? "0" : s.ToString();
        }

        /// <summary>
        /// 最多循环n+k次，时间复杂度O(N)
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RemoveKdigits(string num, int k)
        {
            var nums = num.ToCharArray();
            if (nums.Length == 0)
            {
                return num;
            }
            var stack = new Stack<char>();
            stack.Push(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                //栈顶元素大于nums[i]，应该将栈顶元素出栈，但是注意，不要急于将nums[i]入栈！因为此时新的栈顶有可能仍然大于nums[i]
                while (k > 0 && stack.Count > 0 && stack.Peek() > nums[i])
                {
                    stack.Pop();
                    //stack.Push(nums[i]);
                    k--;
                }

                stack.Push(nums[i]);
            }
            //极端情况：假设num升序排列，那么k不变，stack存储了所有的数
            while (k > 0)
            {
                stack.Pop();
                k--;
            }

            if (stack.Count == 0)
            {
                return "0";
            }
            var result = new char[stack.Count];
            for (int i = result.Length-1; i >= 0; i--)
            {
                result[i] = stack.Pop();
            }
            var str = new StringBuilder();
            
            //翻转
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i]);
            }

            if (str.Length > 1)
            {
                int index = 0;
                while (index < str.Length && str[index] =='0')
                {
                    index++;
                }
                str.Remove(0, index);
            }
            return str.Length == 0 ? "0" : str.ToString();
        }
    }
}