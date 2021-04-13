/*
 * @lc app=leetcode.cn id=122 lang=csharp
 *
 * [122] 买卖股票的最佳时机 II
 */

// @lc code=start
using System;

public class Solution122 {
    public void Test()
    {
        //var prices = new int[]{7,1,5,3,6,4};
        var prices = new int[]{7,5,4};
        var ans = MaxProfit(prices);
    }

    public int MaxProfit(int[] prices) 
    {
        var n = prices.Length;
        //dp[i,j]=p, j=0表示第i天不持有股票时的当前利润为p，
        //j=1表示第i天持有股票时的当前利润为p
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[2];
        }
        dp[0][0] = 0;
        dp[0][1] = -prices[0];
        int minPrice = prices[0];
        for (int i = 1; i < n; i++)
        {
            minPrice = Math.Min(minPrice, prices[i]);
            dp[i][0] = Math.Max(dp[i-1][0], dp[i-1][1]+prices[i]);
            dp[i][1] = Math.Max(dp[i-1][1], dp[i-1][0]-prices[i]);
        }
        return dp[n-1][0];
    }
}
// @lc code=end

