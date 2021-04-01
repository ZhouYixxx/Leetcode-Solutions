/*
 * @lc app=leetcode.cn id=410 lang=csharp
 *
 * [410] 分割数组的最大值
 */

// @lc code=start
using System;

public class Solution410 {
    public void Test()
    {
        var nums = new int[]{7,2,5,10,8};
        var m = 2;
        var ans = SplitArray(nums, m);
    }

    public int SplitArray(int[] nums, int m) 
    {
        var n = nums.Length;
        //dp[i,j]=p,表示[0，i]位置的子串被分割为j个子数组，最小的最大值为p
        var dp = new int[n,m+1];
        var preSum = 0;
        for (int i = 0; i < n; i++)
        {
            preSum += nums[i];
            dp[i,1] = preSum;
        }
        preSum = 0;
        for (int i = 1; i < n; i++)
        {
            for (int j = 2; j <= m; j++)
            {
                for (int k = i; k  >= 0; k--)
                {
                    preSum += nums[k];
                    if (dp[k,j-1] > preSum)
                    {
                        dp[i,j] = Math.Min(dp[k,j-1], preSum);
                        //break;
                    }
                }
            }
        }
        return dp[n-1,m];
    }
}
// @lc code=end

