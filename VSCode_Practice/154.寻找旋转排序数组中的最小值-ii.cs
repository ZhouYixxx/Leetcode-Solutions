/*
 * @lc app=leetcode.cn id=154 lang=csharp
 *
 * [154] 寻找旋转排序数组中的最小值 II
 */

// @lc code=start
using System;

public class Solution154 {
    public void Test()
    {
        //var nums = new int[]{2,2,1,2,2,2,2,2,2,2,2};
        //var nums = new int[]{2,2,2,2,2,2,2,2,1,2,2};
        //var nums = new int[]{2,2,3,0,0,1,1,2};
        var nums = new int[]{1,1,1,1,0};
        var ans = FindMin(nums);
    }
    public int FindMin(int[] nums) 
    {
        var l = 0;
        var r = nums.Length-1;
        if (nums[l] < nums[r])
        {
            return nums[l];
        }
        int min = Int32.MaxValue;
        while (l <= r)
        {
            var mid = l+(r-l)/2;
            min = Math.Min(min, nums[mid]);
            if (nums[mid] == nums[l] && nums[mid] == nums[r])
            {
                l++;
                r--;
                continue;
            }
            if (nums[mid] == nums[r])
            {
                if (nums[mid] > nums[l])
                {
                    min = Math.Min(min, nums[l]);
                    l = mid+1;
                    continue;
                }
                else
                {
                    r = mid-1;
                    continue;
                }
            }
            if (nums[mid] > nums[r])
            {
                l = mid+1;
                min = Math.Min(min, nums[r]);
                continue;
            }
            if (nums[mid] < nums[r])
            {
                r = mid;
                continue;
            }
        }
        return min;
    }
}
// @lc code=end

