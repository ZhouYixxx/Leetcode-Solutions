/*
 * @lc app=leetcode.cn id=1478 lang=csharp
 *
 * [1478] 安排邮筒
 */

// @lc code=start
using System;

public class Solution1478 {
    public void Test()
    {
        var houses = new int[]{1,4,8,10,20};
        int k = 2;
        var ans = MinDistance(houses, k);
    }

    public int MinDistance(int[] houses, int k) 
    {
        int n = houses.Length;
        Array.Sort(houses);
        var dp = new int[n + 1, n + 1];
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                dp[i, j] = -1;
            }
        }
        var distance = new int[n + 1, n + 1];
        for (int i = 1; i <= n; i++)
        {
            for (int j = i; j <= n; j++)
            {
                for (int x = i, y = j; x < y; x++, y--)
                {
                    distance[i, j] += houses[y - 1] - houses[x - 1];
                }
            }
        }
        dp[0, 0] = 0;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i && j <= k; j++)
            {
                for (int p = i; p >= 1; p--)
                {
                    if (dp[p - 1, j - 1] != -1 && (dp[i, j] == -1 || dp[i, j] > dp[p - 1, j - 1] + distance[p, i]))
                    {
                        dp[i, j] = dp[p - 1, j - 1] + distance[p, i];
                    }
                }
            }
        }
        return dp[n, k];
    }
}
// @lc code=end

