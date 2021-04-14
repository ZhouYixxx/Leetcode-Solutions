/*
 * @lc app=leetcode.cn id=309 lang=csharp
 *
 * [309] 最佳买卖股票时机含冷冻期
 */

// @lc code=start
using System;

public class Solution309 {
    public void Test()
    {
        //var prices = new int[]{3,2,6,5,0,3};
        var prices = new int[]{1,2,3,4};
        var ans = MaxProfit1(prices);
    }
    public int MaxProfit(int[] prices) 
    {
        var n = prices.Length;
        if (n <= 1)
        {
            return 0;
        }
        //dp[i,j]=p, j=0表示第i天不持有股票时且不处于冷冻期的当前最大利润为p，
        //j=1表示第i天持有股票时的当前最大利润为p,j=2表示不持有股票且第i天为冷冻期
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[3];
        }
        int INF = Int32.MinValue + 10000;
        dp[0][0] = 0;
        dp[0][1] = -prices[0];
        dp[0][2] = INF;
        for (int i = 1; i < n; i++)
        {
            //当前不持股且不处于冷冻期。前一天可能是冷冻期可能是非冷冻期
            dp[i][0] = Math.Max(dp[i-1][0], dp[i-1][2]);
            //当前持股，前一天不可能为冷冻期
            dp[i][1] = Math.Max(dp[i-1][0] - prices[i], dp[i-1][1]);
            //当前不持股且处于冷冻期，则前一天必然持股，今天必然卖出
            dp[i][2] = dp[i-1][1]+prices[i];
        }
        int max = 0;
        max = Math.Max(max, dp[n-1][0]);
        max = Math.Max(max, dp[n-1][1]);
        max = Math.Max(max, dp[n-1][2]);
        return max;
    }

    //压缩状态的DP
    public int MaxProfit1(int[] prices) 
    {
        var n = prices.Length;
        if (n <= 1)
        {
            return 0;
        }
        int INF = Int32.MinValue + 10000;
        var nonHolding = 0;
        var holding = -prices[0];
        var frozen = INF;
        for (int i = 1; i < n; i++)
        {
            var tempNonhold = nonHolding;
            var tempHold = holding;
            var tempFrozen = frozen;
            //当前不持股且不处于冷冻期。前一天可能是冷冻期可能是非冷冻期
            nonHolding = Math.Max(nonHolding, tempFrozen);
            //当前持股，前一天不可能为冷冻期
            holding = Math.Max(tempNonhold - prices[i], holding);
            //当前不持股且处于冷冻期，则前一天必然持股，今天必然卖出
            frozen = tempHold+prices[i];
        }
        return Math.Max(nonHolding, frozen);
    }
}
// @lc code=end

