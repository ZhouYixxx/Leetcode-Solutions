/*
 * @lc app=leetcode.cn id=1052 lang=csharp
 *
 * [1052] 爱生气的书店老板
 */

// @lc code=start
using System;

public class Solution1052 {
    public void Test()
    {
        var customers = new int[]{2,6,6,9};
        var grumpy = new int[]{0,0,1,1};
        var ans = MaxSatisfied(customers, grumpy, 1);
    }

    public int MaxSatisfied(int[] customers, int[] grumpy, int X) {
        int max = 0;
        //计算不生气时候固定留下的人数
        for (int i = 0; i < customers.Length; i++)
        {
            if (X >= customers.Length || grumpy[i] == 0)
            {
                max += customers[i];
            }
        }
        if (X >= customers.Length)
        {
            return max;
        }
        //初始化[0,X-1]窗口，计算区间内可挽回顾客数量
        int redeem = 0;
        for (int i = 0; i < X; i++)
        {
            if (grumpy[i] == 1)
            {
                redeem += customers[i];
            }
        }
        //滑动窗口，寻找长度固定为X的区间内，最多能挽回的人数
        int maxRedeem = redeem;
        for (int index = X; index < customers.Length; index++)
        {
            //滑动窗口右边进入一个新元素
            if (grumpy[index] == 1)
            {
                redeem += customers[index];
            }
            //窗口左边舍弃一个旧元素
            if (grumpy[index-X] == 1)
            {
                redeem -= customers[index-X];
            }
            maxRedeem = Math.Max(redeem, maxRedeem); 
        }
        return max+maxRedeem;
    }
}
// @lc code=end

