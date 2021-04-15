/*
 * @lc app=leetcode.cn id=712 lang=csharp
 *
 * [712] 两个字符串的最小ASCII删除和
 */

// @lc code=start
using System;

public class Solution712 {
    public void Test()
    {
        var text1 = "bsbininmb";
        var text2 = "jnmjkbkjkv";
        //var text1 = "sea";
        //var text2 = "f";
        var ans = MinimumDeleteSum(text1,text2);
    }
    public int MinimumDeleteSum(string s1, string s2) 
    {
        var dp = new int[s1.Length+1, s2.Length+1];
        for (int i = 0; i <= s1.Length; i++)
        {
            for (int j = 0; j <= s2.Length; j++)
            {
                dp[i,j] = Int32.MaxValue - 10000000;
            }
        }
        dp[0,0] = 0;
        for (int i = 1; i <= s1.Length; i++)
        {
            dp[i,0] = dp[i-1,0]+s1[i-1];
        }
        for (int i = 1; i <= s2.Length; i++)
        {
            dp[0,i] = dp[0,i-1]+s2[i-1];
        }
        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                if (i == 1 && j == 1)
                {
                    dp[1,1] = s1[0] == s2[0] ? 0 : (int)s1[0]+(int)s2[0];
                    continue;
                }
                if (s1[i-1] == s2[j-1])
                {
                    dp[i,j] = dp[i-1,j-1];
                }
                else
                {
                    dp[i,j] = Math.Min(dp[i-1,j]+(int)s1[i-1], dp[i,j-1]+(int)s2[j-1]);
                }
            }
        }
        return dp[s1.Length,s2.Length];
    }
}
// @lc code=end

