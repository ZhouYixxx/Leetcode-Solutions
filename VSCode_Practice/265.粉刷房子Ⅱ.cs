using System;
using System.Collections.Generic;

public class Solution265
{
    public void Test()
    {
        var costs = new int[][]
        {
            //new int[]{17,9,6,2,6,18,8,12,3,5,9,11,20,8,13,16},
            new int[]{1,5,3},
            new int[]{2,9,4},
        };
        var ans = MinCostII(costs);
    }

    public int MinCostII(int[][] costs) 
    {
        int n = costs.Length;
        if (n == 0)
            return 0;
        int minCost = Int32.MaxValue;
        int k = costs[0].Length;
        //dp[i,j] = m, 表示第i个房子，粉刷为第j种颜色（j = 0,1,2...k）的最小花费为m
        var dp = new int[n][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[k];
        }
        //基本情况
        for (int j = 0; j < k; j++)
        {
            dp[0][j] = costs[0][j]; 
        }

        var nums = new int[k];
        for (int i = 1; i < n; i++)
        {
            for (int m = 0; m < k; m++)
            {
                nums[m] = dp[i-1][m];
            }
            for (int j = 0; j < k; j++)
            {
                var min = GetMin(nums, j);
                dp[i][j] = min + costs[i][j];
            }
        }
        for (int i = 0; i < k; i++)
        {
            minCost = Math.Min(dp[n-1][i], minCost);   
        }
        return minCost;
    }

    private int GetMin(int[] nums, int expectIndex)
    {
        int min = Int32.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == expectIndex)
                continue;
            min = Math.Min(nums[i], min);
        }
        return min;
    }
}