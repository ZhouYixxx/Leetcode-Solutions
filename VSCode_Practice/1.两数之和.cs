/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */


// @lc code=start
using System;
using System.Collections.Generic;

public class Solution001 {
    public void Test()
    {
        var nums = new int[]{1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1};
        var target = 2;
        var ans = TwoSum(nums,target);
    }

    public int[] TwoSum(int[] nums, int target) 
    {
        var dic = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var val = target - nums[i];
            if (dic.ContainsKey(val))
            {
                return new int[]{i,dic[val]};
            }
            dic[nums[i]] = i;
        }
        return new int[]{-1,-1};
    }
}
// @lc code=end

