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
        var s = "";
        var ans = LengthOfLongestSubstring(s);
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
}
// @lc code=end

