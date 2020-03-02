using System.Collections.Generic;

namespace CodePractice.LeetCode.String
{
    public class No3_longestSubString
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
            //if (s.Length == 0|| s.Length == 1)
            //{
            //    return s.Length;
            //}
            //int length = 0;
            //int i = 0;
            //int j = 1;
            //var dic = new Dictionary<char, int> {{s[0], 0}};
            ////滑动窗口法，时间复杂度O(n)，最差情况下O(2n)
            //while (i < s.Length && j < s.Length)
            //{
            //    //慢指针i不动，快指针j增加
            //    var currentChar = s[j];
            //    //字典不包含j指针所指字符，j继续增加，i不动
            //    if (!dic.ContainsKey(currentChar))
            //    {
            //        dic.Add(currentChar, j);
            //        j++;
            //    }
            //    //字典包含j指针所指字符，i增加，j不动
            //    else
            //    {
            //        dic.Remove(s[i]);
            //        i++;
            //    }
            //    //比较当前是否是最长子字符串
            //    if (length < j -i)
            //    {
            //        length = j - i;
            //    }
            //}
            //return length;
        }
    }
}