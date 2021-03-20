/*
 * @lc app=leetcode.cn id=801 lang=csharp
 *
 * [801] 使序列递增的最小交换次数
 */

// @lc code=start

using System;
public class Solution801 {
    public void Test()
    {
        var A = new int[]{1,3,9,5};
        var B = new int[]{1,2,6,10};
        var ans = MinSwap(A,B);
    }

    public int MinSwap(int[] A, int[] B) 
    {
        var dp = new int[A.Length][];
        //dp[i][0]表示[0，i]区间有序，同时第i个元素不交换
        //dp[i][1]表示[0，i]区间有序，同时第i个元素交换
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[2];
        }
        dp[0][0] = 0;
        dp[0][1] = 1;
        for (int i = 1; i < dp.Length; i++)
        {
            if (A[i] > A[i-1] && B[i] > B[i-1])
            {
                //i和i-1随意交换互不影响
                if (A[i-1] < B[i] && B[i-1] < A[i])
                {
                    dp[i][0] = Math.Min(dp[i-1][0], dp[i-1][1]);
                    dp[i][1] = Math.Min(dp[i-1][0], dp[i-1][1])+1;
                }
                //i和i-1必须同时交换
                else
                {
                    dp[i][0] = dp[i-1][0];
                    dp[i][1] = dp[i-1][1]+1;
                }
            }
            //i和i-1必须只能有一个交换
            else
            {
                dp[i][0] = dp[i-1][1];//第i个位置不交换，则i-1必须交换
                dp[i][1] = dp[i-1][0]+1;//第i个位置交换，则i-1必须不交换
            }
        }
        return Math.Min(dp[dp.Length-1][0], dp[dp.Length-1][1]);
    }
}
// @lc code=end

