/*
 * @lc app=leetcode.cn id=1143 lang=csharp
 *
 * [1143] 最长公共子序列
 */

// @lc code=start
using System;

public class Solution1143 {
    public void Test()
    {
        var text1 = "bsbininmb";
        var text2 = "jnmjkbkjkv";
        var ans = LongestCommonSubsequence(text1,text2);
    }

    public int LongestCommonSubsequence(string text1, string text2) 
    {
        var dp = new int[text1.Length+1, text2.Length+1];
        //dp[1,1] = text1[0] == text2[0] ? 1 : 0;
        for (int i = 1; i <= text1.Length; i++)
        {
            for (int j = 1; j <= text2.Length; j++)
            {
                if (text1[i-1] == text2[j-1])
                {
                    dp[i,j] = dp[i-1,j-1]+1;
                }
                else
                {
                    dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
                }
            }
        }
        return dp[text1.Length, text2.Length];

    }
}
// @lc code=end

