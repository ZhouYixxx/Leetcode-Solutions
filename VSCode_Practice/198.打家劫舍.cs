/*
 * @lc app=leetcode.cn id=198 lang=csharp
 *
 * [198] 打家劫舍
 */

// @lc code=start
using System;

public class Solution198 {
    public void Test()
    {
        var nums = new int[]{2,7,9,3,1};
        var ans = Rob(nums);
    }

    public int Rob(int[] nums) 
    {
        var n = nums.Length;
        var dp = new int[n+1];
        dp[1] = nums[0];
        for (int i = 2; i < n+1; i++)
        {
            dp[i] = Math.Max(dp[i-1], dp[i-2]+nums[i-1]);
        }
        return dp[n];
    }
}
// @lc code=end

