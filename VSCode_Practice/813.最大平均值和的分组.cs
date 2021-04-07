/*
 * @lc app=leetcode.cn id=813 lang=csharp
 *
 * [813] 最大平均值和的分组
 */

// @lc code=start
using System;

public class Solution813 {
    public void Test()
    {
        var A = new int[]{9,1,2,3,9,1616,22,88,264};
        int K = 4;
        var ans = LargestSumOfAverages(A,K);
    }

    public double LargestSumOfAverages(int[] A, int K) 
    {
        //dp[i][k] = s, 表示[0...i]区间分割为k个数组，最大的平均数之和为s
        var dp = new double[A.Length][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new double[K+1];
        }
        //初始条件
        dp[0][0] = 0;
        for (int i = 1; i <= K; i++)
        {
            dp[0][i] = (double)A[0]/i;
        }
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i][1] = GetAvg(A,0,i); 
        }
        for (int i = 1; i < dp.Length; i++)
        {
            for (int k = 2; k <= K && k <= i+1; k++)
            {
                for (int j = i-1; j >= k-2; j--)
                {
                    var sum = dp[j][k-1]+GetAvg(A,j+1,i);
                    if (dp[i][k] < sum)
                    {
                        dp[i][k] = sum;
                    }
                }   
            }
        }
        return dp[dp.Length-1][K];
    }

    private double GetAvg(int[] A, int start, int end)
    {
        double sum = 0;
        for (int i = start; i <= end; i++)
        {
            sum += A[i];
        }
        return sum / (end - start + 1);
    }
}
// @lc code=end

