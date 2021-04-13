/*
 * @lc app=leetcode.cn id=121 lang=csharp
 *
 * [121] 买卖股票的最佳时机
 */

// @lc code=start
using System;

public class Solution121 {
    public void Test()
    {
        //var prices = new int[]{7,1,5,3,6,4};
        //var prices = new int[]{7,6,5,3,2,1};
        var prices = new int[]{3,4};
        var ans = MaxProfit1(prices);
    }

    //一次遍历
    public int MaxProfit(int[] prices) 
    {
        int minPrice = Int32.MaxValue;
        int maxProfit = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            //假设第i天卖出
            minPrice = Math.Min(minPrice, prices[i]);
            var curProfit = prices[i]-minPrice;
            maxProfit = Math.Max(curProfit,maxProfit);
        }
        return maxProfit;
    }

    //动态规划一：dp[i]=p,表示前i天可以获得的最大利润
    public int MaxProfit1(int[] prices) 
    {
        var n = prices.Length;
        var dp = new int[n];
        var minPrice = prices[0];
        for (int i = 1; i < n; i++)
        {
            minPrice = Math.Min(minPrice, prices[i]);
            dp[i] = Math.Max(prices[i]-minPrice, dp[i-1]);
        }
        return dp[n-1];
    }

    //动态规划二：dp[i,0]=p1,表示第i天持有股票时，手中利润为p1
    //dp[i,1]=p2,表示第i天不持有股票时，手中利润为p2
    public int MaxProfit2(int[] prices) 
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
            dp[i][0] = Math.Max(dp[i-1][0], dp[i-1][1]+prices[i]);
            dp[i][1] = Math.Max(dp[i-1][1], -prices[i]);
        }
        return dp[n-1][0];
    }
}
// @lc code=end

