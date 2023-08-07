/*
 * @lc app=leetcode.cn id=1763 lang=csharp
 *
 * [1763] 最长的美好子字符串
 */

// @lc code=start
using System.Collections.Generic;
using System;

public class Solution1763 {
    public string LongestNiceSubstring(string s) 
    {
        int n = s.Length;
        String ans = "";
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (j - i + 1 > ans.Length && check(s.Substring(i, j-i+1))) 
                    ans = s.Substring(i, j-i+1);
            }
        }
        return ans;
    }

    private bool check(string s) 
    {
        var set = new HashSet<char>();
        var chars = s.ToCharArray();
        foreach (var c in chars) set.Add(c);
        foreach (var c in chars)
        {
            var a = char.ToLower(c);
            var b = char.ToUpper(c);
            if (!set.Contains(a) || !set.Contains(b))
            {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

