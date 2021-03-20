/*
 * @lc app=leetcode.cn id=5 lang=csharp
 *
 * [5] 最长回文子串
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution005 {
    public void Test()
    {
        var s = "dbccbd";
        var ss = LongestPalindrome(s);
    }

    public string LongestPalindrome(string s) {
        if (s.Length == 1)
        {
            return s;
        }
        if (s.Length == 2)
        {
            return s[0] == s[1] ? s : s.Substring(0,1);
        }
        //BF方法
/*         int begin = 0;
        int maxLen = 1;
        for (int i = 0; i < s.Length-1; i++)
        {
            for (int j = i+1; j < s.Length; j++)
            {
                if (maxLen > (j-i+1))
                {
                    continue;
                }
                var isValid = IsValidPalindromic(s,i,j);
                if (isValid)
                {
                    maxLen = j-i+1;
                    begin = i;
                }
            }
        }
        return s.Substring(begin, maxLen); */


        //动态规划
        //dp[i][j]=1，表示s[i...j]为回文子串
/*         int[][] dp = new int[s.Length][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[s.Length];
            dp[i][i] = 1;
        }
        dp[0][1] = s[0] == s[1] ? 1 : 0;
        int begin = 0;
        int maxLen = 1;
        for (int j = 1; j < s.Length; j++)
        {
            for (int i = 0; i < j; i++)
            {
                if (s[i] == s[j])
                {
                    dp[i][j] = (j-i < 3) ? 1 : dp[i+1][j-1];
                }
                else
                {
                    dp[i][j] = 0;
                }
                if (dp[i][j] == 1 && maxLen < j-i+1)
                {
                    begin = i;
                    maxLen = j-i+1;
                }
            }
        }
        return s.Substring(begin, maxLen); */

        //中心扩散法
        //一个长度为n的字符串，有2n-1个中心（n个字符和n-1个间隔）
        int begin = 0;
        var ans = string.Empty;
        while (begin >= 0 && begin < s.Length -1)
        {
            var str1 = ExtendCenter(s, begin, begin);
            var str2 = ExtendCenter(s, begin, begin+1);
            var tempMax = Math.Max(str1.Length, str2.Length);
            if (ans.Length < tempMax)
            {
                ans = str1.Length > str2.Length ? str1 : str2;
            }
            begin++;
        }
        return ans;
    }

    private string ExtendCenter(string s,int start, int end)
    {
        int l = start;
        int r = end;
        while (l >= 0 && r < s.Length)
        {
            if (s[l] == s[r])
            {
                l--;
                r++;
            }
            else
                break;
        }
        return s.Substring(l+1, r-l-1);
    }

    private bool IsValidPalindromic(string s,int begin, int end)
    {
        if(end - begin < 2)
            return s[begin] == s[end];
        while (begin < end)
        {
            if (s[begin] != s[end])
            {
                return false;
            }
            begin++;
            end--;
        }
        return true;
    }
}
// @lc code=end

