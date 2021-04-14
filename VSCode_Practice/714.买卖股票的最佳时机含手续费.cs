/*
 * @lc app=leetcode.cn id=714 lang=csharp
 *
 * [714] 买卖股票的最佳时机含手续费
 */

// @lc code=start
using System;

public class Solution714 {
    public void Test()
    {
        //var prices = new int[]{1, 3, 2, 8, 4, 9};
        var prices = new int[]{5,4,3,2,5};
        var fee = 2;
        var ans = MaxProfit1(prices, fee);
    }

    public int MaxProfit(int[] prices, int fee) 
    {
        var n = prices.Length;
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[2];
        }
        dp[0][0] = 0;
        dp[0][1] = -prices[0];
        for (int i = 1; i < n; i++)
        {
            dp[i][0] = Math.Max(dp[i-1][0], dp[i-1][1]+prices[i]-fee);
            dp[i][1] = Math.Max(dp[i-1][1], dp[i-1][0]-prices[i]);
        }
        return Math.Max(dp[n-1][0], dp[n-1][1]);
    }

    public int MaxProfit1(int[] prices, int fee) 
    {
        var n = prices.Length;
        var nonHold = 0;
        var hold = -prices[0];
        for (int i = 1; i < n; i++)
        {
            nonHold = Math.Max(nonHold, hold+prices[i]-fee);
            hold = Math.Max(hold, nonHold-prices[i]);
        }
        return Math.Max(hold,nonHold);
    }
}
// @lc code=end

