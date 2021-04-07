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
        var houses = new int[]{1,4,8,10,15};
        int k = 3;
        var ans = MinDistance1(houses, k);
    }

    //抄袭大佬的答案
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

    //自己做的
    public int MinDistance1(int[] houses, int k)
    {
        int n = houses.Length;
        if (k == n)
        {
            return 0;
        }
        Array.Sort(houses);
        var distance = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                for (int x = i, y = j; x < y; x++, y--)
                {
                    distance[i, j] += houses[y] - houses[x];
                }
            }
        }
        var dp = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                //情况一，只有一个邮筒
                if (j == 1)
                {
                    dp[i,j] = distance[0,i];
                    continue;
                }
                //情况二，j = i+1，正好每个房子放一个邮筒
                if (j == i+1)
                {
                    dp[i,j] = 0;
                    continue;
                }
                dp[i, j] = Int32.MaxValue;
            }
        }
        dp[0,0] = 0;
        dp[1,0] = 0;
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j <= i && j <= k; j++)
            {
                for (int p = 0; p < i; p++)
                {
                    //j = 1的情况已经初始化处理
                    if (j == 1 || dp[p,j-1] == Int32.MaxValue)
                    {
                        continue;
                    }
                    dp[i,j] = Math.Min(dp[i,j], dp[p,j-1]+distance[p+1,i]);
                }
            }
        }
        return dp[n-1,k];
    } 
}
// @lc code=end

