/*
 * @lc app=leetcode.cn id=152 lang=csharp
 *
 * [152] 乘积最大子数组
 */

// @lc code=start
using System;

public class Solution152 {
    public void Test(){
        var nums = new int[]{-2};
        var ans = MaxProduct(nums);
    }

    public int MaxProduct(int[] nums) {
        var dp_max = new int[nums.Length];
        var dp_min = new int[nums.Length];
        dp_max[0] = nums[0];
        dp_min[0] = nums[0];
        var ans = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            dp_max[i] = Math.Max(nums[i], Math.Max(dp_max[i-1]*nums[i], dp_min[i-1] * nums[i]));
            dp_min[i] = Math.Min(nums[i], Math.Min(dp_max[i-1]*nums[i], dp_min[i-1] * nums[i]));
            if (ans < dp_max[i])
            {
                ans = dp_max[i];
            }
        }
        return ans;
    }
}
// @lc code=end

