/*
 * @lc app=leetcode.cn id=32 lang=csharp
 *
 * [32] 最长有效括号
 */

// @lc code=start
using System;

public class Solution32 {
    public void Test()
    {
        var s = "())(())(()()))";
        //var s = "(()())";
        var ans = LongestValidParentheses(s);
    }
    
    public int LongestValidParentheses(string s) 
    {
        if (s.Length < 2)
        {
            return 0;
        }
        var dp = new int[s.Length];
        dp[0] = 0;
        int max = 0;
        int index = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                dp[i] = 0;
                continue;
            }
            if (s[i-1] == '(')
            {
                dp[i] = i == 1 ? 2 : dp[i-2]+2;
            }
            if (s[i-1] == ')')
            {
                var matchIndex = i - dp[i-1] -1;
                if ( matchIndex >= 0 && s[matchIndex] == '(')
                {
                    dp[i] = dp[i-1]+2;
                    if (matchIndex >= 1 && s[matchIndex-1] == ')')
                    {
                        dp[i] += dp[matchIndex-1];   
                    }
                }
            }
            if (max < dp[i])
            {
                max = dp[i];
                index = i - max+1;
            }
        }
        var subStr = s.Substring(index,max);
        return max;
    }
}
// @lc code=end

