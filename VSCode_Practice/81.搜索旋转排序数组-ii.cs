/*
 * @lc app=leetcode.cn id=81 lang=csharp
 *
 * [81] 搜索旋转排序数组 II
 */

// @lc code=start
using System;

public class Solution81 {
    public void Test()
    {
        var nums = new int[]{1,1,1,1,1,1,2,1};
        //var nums = new int[]{1,0,1,1,1,1,1};
        //var nums = new int[]{3,2,3,5,5,5};
        var target = 2;
        var ans = Search(nums, target);
    }
    public bool Search(int[] nums, int target) 
    {
        var l = 0;
        var r = nums.Length-1;
        while (l <= r)
        {
            var mid = l+(r-l)/2;
            if (nums[mid] == target)
            {
                return true;
            }
            //无法判断哪个是单调区间
            if (nums[l] == nums[mid] && nums[mid] == nums[r])
            {
                l++;
                r--;
                continue;
            }
            //[l,mid]是单调区间
            if (nums[l] <= nums[mid])
            {
                if (nums[l] == target)
                {
                    return true;
                }
                if (nums[mid] > target && nums[l] < target)
                {
                    r = mid-1;
                }
                else
                {
                    l = mid+1;
                }
            }
            else
            {
                if (nums[r] == target)
                {
                    return true;
                }
                if (nums[mid] < target && nums[r] > target)
                {
                    l = mid+1;
                }
                else
                {
                    r = mid-1;
                }
            }
        }
        return false;
    }
}
// @lc code=end

