/*
 * @lc app=leetcode.cn id=123 lang=csharp
 *
 * [123] 买卖股票的最佳时机 III
 */

// @lc code=start
using System;

public class Solution123 {
    public void Test()
    {
        //var prices = new int[]{3,3,5,0,0,3,1,4};
        var prices = new int[]{1,3};
        var ans = MaxProfit1(prices);
    }

    public int MaxProfit(int[] prices) 
    {
        var n = prices.Length;
        //dp[i,j,k]=p, j=0表示第i天不持有股票时的当前最大利润为p，
        //j=1表示第i天持有股票时的当前最大利润为p。k为交易次数
        var dp = new int[n][][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[2][];
            for (int j = 0; j < 2; j++)
            {
                dp[i][j] = new int[3];
            }
        }
        int INF = Int32.MinValue + 100000;
        //第一天买入
        dp[0][1][0] = -prices[0];
        //第一天不可能完成一笔交易
        dp[0][0][1] = INF;
        dp[0][0][2] = INF;
        dp[0][1][1] = INF;
        dp[0][1][2] = INF;
        //从第二天开始
        for (int i = 1; i < n; i++)
        {
            dp[i][0][0] = 0;
            dp[i][0][1] = Math.Max(dp[i-1][0][1], dp[i-1][1][0] + prices[i]);//sell1
            dp[i][0][2] = Math.Max(dp[i-1][0][2], dp[i-1][1][1] + prices[i]);//sell2
            dp[i][1][0] = Math.Max(dp[i-1][1][0], dp[i-1][0][0] - prices[i]);//buy1
            dp[i][1][1] = Math.Max(dp[i-1][1][1], dp[i-1][0][1] - prices[i]);//buy2
            dp[i][1][2] = INF;
        }
        var max = 0;
        max = Math.Max(dp[n-1][0][0], max);
        max = Math.Max(dp[n-1][0][1], max);
        max = Math.Max(dp[n-1][0][2], max);
        return max;
    }
    
    //状态压缩
    public int MaxProfit1(int[] prices) 
    {
        var n = prices.Length;
        int INF = Int32.MinValue + 100000;
        var buy1 = -prices[0];
        var sell1 = INF;
        var buy2 = INF;
        var sell2 = INF;

        // var preBuy1 = -prices[0];
        // var preSell1 = INF;
        // var preBuy2 = INF;
        // var preSell2 = INF;
        for (int i = 1; i < n; i++)
        {
            buy1 = Math.Max(buy1, -prices[i]);
            buy2 = Math.Max(buy2, sell1-prices[i]);
            sell1 = Math.Max(sell1, buy1+prices[i]);
            sell2 = Math.Max(sell2, buy2+prices[i]);
            // buy1 = Math.Max(preBuy1, -prices[i]);
            // buy2 = Math.Max(preBuy2, preSell1-prices[i]);
            // sell1 = Math.Max(preSell1, buy1+prices[i]);
            // sell2 = Math.Max(preSell2, buy2+prices[i]);

            // preBuy1 = buy1;
            // preSell1 = sell1;
            // preBuy2 = buy2;
            // preSell2 = sell2;
        }
        return Math.Max(0,Math.Max(sell1,sell2));
    }
}
// @lc code=end

