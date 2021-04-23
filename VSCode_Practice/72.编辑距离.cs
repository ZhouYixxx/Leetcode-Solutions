/*
 * @lc app=leetcode.cn id=72 lang=csharp
 *
 * [72] 编辑距离
 */

// @lc code=start
using System;

public class Solution72 {
    public void Test()
    {
        var word1 = "eat";
        var word2 = "sea";
        var ans = MinDistance(word1, word2);
    }

    public int MinDistance(string word1, string word2) 
    {
        var m = word1.Length;
        var n = word2.Length;
        if ( m == 0 || n == 0)
        {
            return Math.Max(m,n);
        }
        var dp = new int[m+1,n+1];
        for (int i = 0; i <= m; i++)
        {
            dp[i,0] = i;
        }
        for (int j = 0; j <= n; j++)
        {
            dp[0,j] = j;
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                var min = dp[i-1,j-1]+1;
                min = Math.Min(dp[i,j-1]+1, min);
                min = Math.Min(dp[i-1,j]+1, min);
                dp[i,j] = min;
                if (word1[i-1] == word2[j-1])
                {
                    dp[i,j] = Math.Min(dp[i-1,j-1], dp[i,j]);
                }
            }
        }
        return dp[m,n];
    }
}
// @lc code=end

