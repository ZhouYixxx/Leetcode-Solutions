/*
 * @lc app=leetcode.cn id=413 lang=csharp
 *
 * [413] 等差数列划分
 */

// @lc code=start
using System;

public class Solution413 {
    public void Test()
    {
        var nums = new int[]{1,2,3,4,9,10,11,13,15,17};
        var ans = NumberOfArithmeticSlices(nums);
    }

    public int NumberOfArithmeticSlices(int[] nums) {
        if (nums.Length < 3)
        {
            return 0;
        }
        var dp = new int[nums.Length];
/*         //dp[i]=k, 表示[0,i]的子区间内，包含的等差数列数量k
        dp[0] = dp[1] = 0;
        dp[2] = nums[1]*2 == (nums[0]+nums[2]) ? 1 : 0;
        for (int i = 3; i < nums.Length; i++)
        {
            dp[i] = dp[i-1];
            var diff = nums[i] - nums[i-1];
            int k = i-1;
            while (k > 0)
            {
                if (nums[k] - nums[k-1] != diff)
                {
                    break;
                }
                dp[i]++;
                k--;
            }
        }
        return dp[dp.Length-1]; */
        
        //优化思路：dp[i]=k, 表示[0,i]的子区间内，以num[i]结尾的等差数列数量k
        dp[0] = dp[1] = 0;
        dp[2] = nums[1]*2 == (nums[0]+nums[2]) ? 1 : 0;
        
        int sum = dp[2];
        for (int i = 3; i < dp.Length; i++)
        {
            if (nums[i] - nums[i-1] == nums[i-1] - nums[i-2])
            {
                dp[i] = dp[i-1]+1;
            }
            sum += dp[i];
        }
        return sum;
    }
}
// @lc code=end

