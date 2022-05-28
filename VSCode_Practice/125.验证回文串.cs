/*
 * @lc app=leetcode.cn id=125 lang=csharp
 *
 * [125] 验证回文串
 */

// @lc code=start
using System;

public class Solution125 {
    public void Test()
    {
        var s = "0P";
        var ans = IsPalindrome(s);
    }
    public bool IsPalindrome(string s) 
    {
        if (s.Length <= 1)
        {
            return true;
        }
        int l = 0, r = s.Length-1;
        while (l < r)
        {
            var c1 = s[l];
            var c2 = s[r];
            if (!isValid(s[l]))
            {
                l++;
                continue;
            }
            if (!isValid(s[r]))
            {
                r--;
                continue;
            }
            if (s[l] != s[r] && char.ToLower(s[l]) != char.ToLower(s[r]))
            {
                return false;   
            }
            l++;
            r--;
        }
        return true;
    }

    private bool isValid(char c)
    {
        return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
    }
}
// @lc code=end

