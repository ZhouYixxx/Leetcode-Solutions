using System;
using System.Collections.Generic;

public class Solution256
{
    public void Test()
    {
        var costs = new int[][]
        {
            new int[]{17,2,17},
            new int[]{16,16,5},
            new int[]{14,3,19},
        };
        var ans = MinCost(costs);
    }

    public int MinCost(int[][] costs) 
    {
        int n = costs.Length;
        //dp[i,j]=k, 表示第i个房子，粉刷为第j种颜色（j = 0,1,2）的最小花费为k
        var dp = new int[costs.Length][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[3];
        }
        dp[0][0] = costs[0][0];
        dp[0][1] = costs[0][1];
        dp[0][2] = costs[0][2];

        for (int i = 1; i < dp.Length; i++)
        {
            dp[i][0] = Math.Min(dp[i-1][1], dp[i-1][2]) + costs[i][0];
            dp[i][1] = Math.Min(dp[i-1][0], dp[i-1][2]) + costs[i][1];
            dp[i][2] = Math.Min(dp[i-1][0], dp[i-1][1]) + costs[i][2];
        }
        return Math.Min(dp[n-1][0], Math.Min(dp[n-1][1],dp[n-1][2]));
    }

    public int MinCost1(int[][] costs)
    {
        //状态压缩：results存储结果，pre存储上次结果
        int n = costs.Length;
        var results = new int[3];
        var pre = new int[3];

        pre[0] = costs[0][0];
        pre[1] = costs[0][1];
        pre[2] = costs[0][2];

        results[0] = costs[0][0];
        results[1] = costs[0][1];
        results[2] = costs[0][2];

        for (int i = 1; i < n; i++)
        {
            pre[0] = results[0];
            pre[1] = results[1];
            pre[2] = results[2];

            results[0] = Math.Min(pre[1], pre[2]) + costs[i][0];
            results[1] = Math.Min(pre[0], pre[2]) + costs[i][1];
            results[2] = Math.Min(pre[0], pre[1]) + costs[i][2];
        }
        return Math.Min(results[0], Math.Min(results[1], results[2]));
    }
}
