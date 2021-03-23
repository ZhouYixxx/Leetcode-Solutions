/*
 * @lc app=leetcode.cn id=887 lang=csharp
 *
 * [887] 鸡蛋掉落
 */

// @lc code=start
using System;

public class Solution887 {
    public void Test()
    {
        int k = 5;
        int n = 10000;
        var ans = SuperEggDrop2(k,n);
    }

    public int SuperEggDrop(int k, int n) 
    {
        // dp[i][j] i 个鸡蛋扔 j 次能确定的最大区间的层数
        int[,] dp = new int[k + 1, n + 1];

        for (int j = 1; j <= n; j++)
            for (int i = 1; i <= k; i++)
            {
                dp[i, j] = dp[i - 1, j - 1] + dp[i, j - 1] + 1;
                if (dp[i, j] >= n)
                    return j;
            }
        return n;
    }

    public int SuperEggDrop2(int k, int n)
    {
        // dp[i][j] = m,  i个鸡蛋, j层楼，最少需要扔m次
        int[,] dp = new int[k + 1, n + 1];
        //基本情况。
        for (int i = 0; i < k+1; i++)
        {
            for (int j = 0; j < n+1; j++)
            {
                dp[i,j] = Int32.MaxValue;
            }
        }
        //一层楼，n=1
        for (int i = 0; i <= k; i++)
        {
            dp[i,0] = 0;
            dp[i,1] = 1;
        }
        //一个鸡蛋，k=1
        for (int i = 0; i <= n; i++)
        {
            dp[0,i] = 0;
            dp[1,i] = i;
        }
        for (int i = 2; i < k+1; i++)
        {
            for (int h = 2; h < n+1; h++)
            {
                for (int t = 2; t <= h; t++)
                {
                    dp[i,h] = Math.Min(dp[i,h], Math.Max(dp[i-1,t-1], dp[i,h-t])+1);
                }
            }
        }
        return dp[k,n];
    }
}
// @lc code=end

