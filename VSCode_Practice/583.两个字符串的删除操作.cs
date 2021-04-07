/*
 * @lc app=leetcode.cn id=583 lang=csharp
 *
 * [583] 两个字符串的删除操作
 */

// @lc code=start
using System;

public class Solution583 {
    public void Test()
    {
        var word1 = "a";
        var word2 = "abc";
        var ans = MinDistance(word1,word2);
    }

    public int MinDistance(string word1, string word2) 
    {
        //dp[i][j]=k, 表示word1[0...i-1]和word2[0...j-1]用k次删除可以保证一致
        var dp = new int[word1.Length+1][];
        for (int k = 0; k < dp.Length; k++)
        {
            dp[k] = new int[word2.Length+1];
        }
        dp[0][0] = 0;
        for (int i = 0; i <= word1.Length; i++)
            dp[i][0] = i;
        for (int i = 0; i <= word2.Length; i++)
            dp[0][i] = i;
        //dp[1][1] = word1[0] == word2[0] ? 0 : 2;
        for (int i = 1; i <= word1.Length; i++)
        {
            for (int j = 1; j <= word2.Length; j++)
            {
                //情况一：word1[i-1] == word2[j-1]
                if (word1[i-1] == word2[j-1])
                {
                    dp[i][j] = dp[i-1][j-1];
                    continue;
                }
                //情况二：word1[i-1] != word2[j-1]
                dp[i][j] = Math.Min(dp[i][j-1]+1,  Math.Min(dp[i-1][j]+1, dp[i-1][j-1]+2));
            }
        }
        return dp[word1.Length][word2.Length];
    }

    public int MinDistance2(string word1, string word2) 
    {
        //dp[i][j]=k, 表示word1[0...i-1]和word2[0...j-1]用k次删除可以保证一致
        var dp = new int[word1.Length+1][];
        for (int k = 0; k < dp.Length; k++)
        {
            dp[k] = new int[word2.Length+1];
        }
        dp[0][0] = 0;
        for (int i = 0; i <= word1.Length; i++)
            dp[i][0] = i;
        for (int i = 0; i <= word2.Length; i++)
            dp[0][i] = i;
        //dp[1][1] = word1[0] == word2[0] ? 0 : 2;
        for (int i = 1; i <= word1.Length; i++)
        {
            for (int j = 1; j <= word2.Length; j++)
            {
                //情况一：word1[i-1] == word2[j-1]
                if (word1[i-1] == word2[j-1])
                {
                    dp[i][j] = dp[i-1][j-1];
                    continue;
                }
                //情况二：word1[i-1] != word2[j-1]
                dp[i][j] = Math.Min(dp[i][j-1]+1,  Math.Min(dp[i-1][j]+1, dp[i-1][j-1]+2));
            }
        }
        return dp[word1.Length][word2.Length];
    }
}
// @lc code=end

