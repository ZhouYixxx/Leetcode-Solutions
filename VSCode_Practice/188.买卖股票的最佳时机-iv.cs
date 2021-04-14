/*
 * @lc app=leetcode.cn id=188 lang=csharp
 *
 * [188] 买卖股票的最佳时机 IV
 */

// @lc code=start
using System;

public class Solution188 {
    public void Test()
    {
        //var prices = new int[]{3,2,6,5,0,3};
        var prices = new int[]{};
        var k = 3;
        var ans = MaxProfit(k, prices);
    }

    public int MaxProfit(int k, int[] prices) 
    {
        var n = prices.Length;
        if (n <= 1)
        {
            return 0;
        }
        //dp[i,j,k]=p, j=0表示第i天不持有股票时的当前最大利润为p，
        //j=1表示第i天持有股票时的当前最大利润为p。k为交易次数
        var dp = new int[n][][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[2][];
            for (int j = 0; j < 2; j++)
            {
                dp[i][j] = new int[k+1];
            }
        }
        int INF = Int32.MinValue + 100000;
        //初始化
        for (int i = 0; i <= k; i++)
        {
            dp[0][0][k] = 0;
            dp[0][1][k] = k == 0 ? -prices[0] : INF;
        }
        //需要注意dp[i][1][0] != prices[i]
        var minPrice = prices[0];
        for (int i = 0; i < n; i++)
        {
            minPrice = Math.Min(minPrice, prices[i]);
            dp[i][0][0] = 0;
            dp[i][1][0] = -minPrice;
        }
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j <= k; j++)
            {
                //第i天如果未持有股票，那最多能完成(i+1)/2次交易
                if (i < j*2-1)
                {
                    dp[i][0][j] = INF;
                }
                else
                {
                    dp[i][0][j] = Math.Max(dp[i-1][0][j], dp[i-1][1][j-1] + prices[i]);
                }
                //第i天如果持有股票，那最多能完成i/2次交易
                if (i < j*2)
                {
                    dp[i][1][j] = INF;
                }
                else
                {
                    dp[i][1][j] = Math.Max(dp[i-1][1][j], dp[i-1][0][j] - prices[i]);
                }
            }
        }
        var max = 0;
        for (int i = 0; i <= k; i++)
        {
            max = Math.Max(max, dp[n-1][0][i]);
        }
        return max;
    }
}
// @lc code=end

