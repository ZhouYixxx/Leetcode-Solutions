/*
 * @lc app=leetcode.cn id=3 lang=csharp
 *
 * [3] 无重复字符的最长子串
 */

// @lc code=start
using System.Collections.Generic;

public class Solution003 {
    public void Test()
    {
        var s = "abcabcbb";
        var ans = LengthOfLongestSubstring1(s);
    }
    
    public int LengthOfLongestSubstring(string s) 
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }
        int l = 0, r = 1;
        var length = 1;
        var maxLen = 1;
        var memoSet = new HashSet<char>(){s[l]};
        while (r < s.Length)
        {
            if (memoSet.Add(s[r]))
            {
                length++;
                if(maxLen < length)
                {
                    maxLen = length;
                }
                r++;
            }
            else
            {
                while (l < r && s[l] != s[r])
                {
                    memoSet.Remove(s[l]);
                    l++;
                    length--;
                }
                l++;
                r++;
            }
        }
        return maxLen;
    }

    /// <summary>
    /// 2023-03-30
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int LengthOfLongestSubstring1(string s)
    {
        int l = 0, r = 1, maxLen = 1;
        if (s.Length == 0)
        {
            return 0;
        }
        var memo = new HashSet<char>() { s[l]};
        while (r < s.Length)
        {
            if (!memo.Contains(s[r]))
            {
                memo.Add(s[r]);
                maxLen = Math.Max(maxLen, r - l + 1);
                r++;
            }
            else
            {
                while (l < r && s[l] != s[r] && r < s.Length)
                {
                    memo.Remove(s[l++]);
                }
                //l++;
                r++;
            }
        }
        return maxLen;
    } 
}
// @lc code=end

