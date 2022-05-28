/*
 * @lc app=leetcode.cn id=1984 lang=csharp
 *
 * [1984] 学生分数的最小差值
 */

// @lc code=start
using System;

public class Solution1984 {
    public void Test()
    {
        var nums = new int[]{9};
        var k = 1;
        var ans = MinimumDifference(nums, k);
    }
    
    public int MinimumDifference(int[] nums, int k) 
    {
        Array.Sort(nums);
        int min = nums[k-1] - nums[0];
        for (int i = k; i < nums.Length; i++)
        {
            var start = i - k + 1;
            min = Math.Min(nums[i] - nums[start], min);
            if (min == 0)
            {
                return min;
            }
        }
        return min;
    }
}
// @lc code=end

