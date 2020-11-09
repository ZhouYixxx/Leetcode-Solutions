using System.Collections.Generic;
/*
003.无重复字符的最长子串

给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

示例 1:
输入: "abcabcbb"  输出: 3 
解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。

示例 2:
输入: "bbbbb"  输出: 1
解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。

示例 3:
输入: "pwwkew"  输出: 3
解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。

思路：采用滑动窗口法，用字典/HashMap判断窗口中是否存在重复的字符（时间复杂度O(1)）,总体复杂度O(n)
 */
namespace CodePractice.LeetCode.String
{
    public static class No003_longestSubString
    {
        public static int LongestSubString(string s)
        {
            if (s.Length == 0) return 0;
            var dic = new Dictionary<char, int>();
            int max = 0;
            int left = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    if (left < dic[s[i]] + 1)
                    {
                        left = dic[s[i]] + 1;
                    }
                    dic[s[i]] = i;
                }
                else
                {
                    dic.Add(s[i], i);
                }

                if (max < i - left + 1)
                {
                    max = i - left + 1;
                }
            }
            return max;
        }

        /// <summary>
        /// 版本V1
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LongestSubString_V1(string s)
        {
            if (s.Length == 0 || s.Length == 1)
            {
                return s.Length;
            }
            int length = 0;
            //初始化两个指针
            int i = 0;
            int j = 1;
            var dic = new Dictionary<char, int> { { s[0], 0 } };
            //滑动窗口法，时间复杂度O(n)，最差情况下O(2n)
            while (i < s.Length && j < s.Length)
            {
                //慢指针i不动，快指针j增加
                var currentChar = s[j];
                //字典不包含j指针所指字符，j继续增加，i不动
                if (!dic.ContainsKey(currentChar))
                {
                    dic.Add(currentChar, j);
                    j++;
                }
                //字典包含j指针所指字符，i增加，j不动
                else
                {
                    dic.Remove(s[i]);
                    i++;
                }
                //比较当前是否是最长子字符串
                if (length < j - i)
                {
                    length = j - i;
                }
            }
            return length;
        }
    }
}