/*
 * @lc app=leetcode.cn id=1473 lang=csharp
 *
 * [1473] 粉刷房子 III
 */

// @lc code=start
using System;

public class Solution1473 {
    public void Test()
    {
        var houses = new int[]{0,2,1,2,0};
        var costs = new int[][]{
            new int[]{1,10},
            new int[]{10,1},
            new int[]{10,1},
            new int[]{1,10},
            new int[]{5,1},
        };
        var m = 5;
        var n = 2;
        var target = 3;
        var ans = MinCost(houses, costs, m, n, target);
    }

    //比较curd的方法
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target) 
    {
        int bigNum = Int32.MaxValue - (int)1E5;
        var dp = new int[m,n+1,target+1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n+1; j++)
            {
                for (int k = 0; k < target+1; k++)
                {
                    //题目中已经明确说明cost[i][j]最大值不超过10000
                    dp[i,j,k] = bigNum;
                }
            }
        }
        //Init
        if (houses[0] != 0)
        {
            dp[0,houses[0],1] = 0;
        }
        else
        {
            for (int j = 1; j <= n; j++)
            {
                dp[0,j,1] = cost[0][j-1];
            }
        }

        for (int i = 1; i < m; i++)
        {
            if (houses[i] != 0)
            {
                for (int j1 = 1; j1 <= n; j1++)
                {
                    for (int k = 1; k <= target; k++)
                    {
                        var j2 = houses[i];
                        if (j1 == j2)
                        {
                            dp[i,j2,k] = Math.Min(dp[i,j2,k], dp[i-1,j1,k]);   
                        }
                        else
                        {
                            dp[i,j2,k] = Math.Min(dp[i,j2,k], dp[i-1,j1,k-1]);  
                        }
                    }
                }
            }

            else
            {
                for (int j1 = 1; j1 <= n; j1++)
                {
                    for (int k = 1; k <= target; k++)
                    {
                        for (int j2 = 1; j2 <= n; j2++)
                        {
                            if (j1 == j2)
                            {
                                dp[i,j1,k] = Math.Min(dp[i,j1,k], dp[i-1,j2,k]+cost[i][j1-1]);
                            }
                            else
                            {
                                dp[i,j1,k] = Math.Min(dp[i,j1,k], dp[i-1,j2,k-1]+cost[i][j1-1]);
                            }   
                        }
                    }
                }
            }
        }

        var ans = bigNum;
        for (int j = 1; j <= n; j++)
        {
            ans = Math.Min(ans,dp[m-1,j,target]);
        }
        if (ans == bigNum)
        {
            ans = -1;
        }
        return ans;
    }

    //比较简明清晰的写法
    public int MinCost1(int[] houses, int[][] cost, int m, int n, int target)
    {
        int INF = int.MaxValue / 2;  // 初始化为 MaxValue / 2的原因是，防止后面整数相加溢出。
        int[][][] dp = new int[m][][];
        for (int i = 0; i < m; ++i)
        {
            dp[i] = new int[n][];
            for (int j = 0; j < n; ++j)
            {
                dp[i][j] = new int[target];
                for (int k = 0; k < target; ++k)
                    dp[i][j][k] = INF;
            }
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (houses[i] > 0 && houses[i] != j + 1) continue; // 直接跳过不可能达成的情况                    
                int newCost = (houses[i] == 0) ? cost[i][j] : 0; // 计算「额外花费」
                for (int k = 0; k < target; k++)
                {
                    for (int p = 0; p < n; p++)
                    {                           
                        int prev = INF; // 计算「初始花费」
                        if (i == 0)
                            prev = (k == 0) ? 0 : INF;// 只有 1 个房子时，只能形成 1 个街区。
                        else
                        {                                
                            if (p == j)//相同颜色不会形成新的街区
                                prev = dp[i - 1][p][k];
                            else if (k > 0)//不同的颜色产生了新的街区
                                prev = dp[i - 1][p][k - 1];
                        }
                        dp[i][j][k] = Math.Min(dp[i][j][k], newCost + prev);
                    }
                }
            }
        }
        int ans = int.MaxValue;
        for (int i = 0; i < n; i++)
            ans = Math.Min(ans, dp[m - 1][i][target - 1]);
        return ans == INF ? -1 : ans;
    }
}
// @lc code=end

