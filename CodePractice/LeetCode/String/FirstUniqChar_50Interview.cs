/*
面试题50. 第一个只出现一次的字符
给定一个字符串 S，返回 “反转后的” 字符串，其中不是字母的字符都保留在原地，而所有字母的位置发生反转。

示例 2：
输入："a-bC-dEf-ghIj"
输出："j-Ih-gfE-dCba"

 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using CodePractice.Core;

namespace CodePractice.LeetCode.String
{
    public class FirstUniqChar_50Interview : LeetCodeBase
    {
        /// <summary>
        /// 暴力法，依次检查每个字符，使用双循环，时间复杂度O(n²)，空间复杂度O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static char FirstUniqChar_Brute(string s)
        {
            if (s.Length == 1)
            {
                return s[0];
            }
            bool isFirstChar = false;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (j == i)
                    {
                        if (j == s.Length - 1)
                            isFirstChar = true;
                        continue;
                    }
                    //发现重复字符，直接跳出该层循环
                    if (s[i] == s[j])
                        break;
                    //一直到最后都没有发现重复字符，isFirstChar设置为true
                    if (j == s.Length - 1)
                        isFirstChar = true;
                }
                if (isFirstChar)
                    return s[i];
            }
            return ' ';
        }

        /// <summary>
        /// 字典辅助，存储每个字符是否重复，时间复杂度O(n)，空间复杂度O(n)
        /// </summary>
        private static char FirstUniqChar(string s)
        {
            var dic = new Dictionary<char, bool>();
            for (int i = 0; i < s.Length; i++)
            {
                dic[s[i]] = !dic.ContainsKey(s[i]);
                //if (!dic.ContainsKey(s[i]))
                //{
                //    dic.Add(s[i], true);
                //    continue;
                //}
                //dic[s[i]] = false;
            }
            foreach (var item in dic)
            {
                if (item.Value)
                {
                    return item.Key;
                }
            }
            return ' ';
        }

        /// <summary>
        /// 数组辅助，存储每个字符是否重复，数组比字典查询操作应该更快，时间复杂度O(n)，空间复杂度O(n)
        /// </summary>
        private static char FirstUniqChar_array(string s)
        {
            int[] array = new int[128];
            for (int i = 0; i < s.Length; i++)
            {
                array[s[i]] += 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (array[s[i]] == 1)
                {
                    return s[i];
                }
            }
            return ' ';
        }


        public static void Test()
        {
            Console.WriteLine(FirstUniqChar_array("leetcode"));
            Console.ReadKey();
        }

        public FirstUniqChar_50Interview() : base("FirstUniqChar_50Interview")
        {
            Test();
        }
    }
}