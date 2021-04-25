/*
 * @lc app=leetcode.cn id=34 lang=csharp
 *
 * [34] 在排序数组中查找元素的第一个和最后一个位置
 */

// @lc code=start
using System;

public class Solution34 {
    public void Test()
    {
        var nums = new int[]{};
        var target = 9;
        var ans = SearchRange(nums, target);
    }

    public int[] SearchRange(int[] nums, int target) 
    {
        var l = GetLeftBorder(nums,target);
        var r = GetRightBorder(nums,target);
        return new int[2]{l,r};
    }

    public int GetLeftBorder(int[] nums, int target)
    {
        var l = 0;
        var r = nums.Length-1;
        bool exists = false;
        while (l <= r)
        {
            var mid = l+(r-l)/2;
            if (nums[mid] == target)
            {
                exists = true;
                r = mid-1;
            }
            if (nums[mid] > target)
            {
                r = mid-1;
            }
            if (nums[mid] < target)
            {
                l = mid+1;
            }
        }
        return exists ? l : -1;
    }

    public int GetRightBorder(int[] nums, int target)
    {
        var l = 0;
        var r = nums.Length-1;
        bool exists = false;
        while (l <= r)
        {
            var mid = l+(r-l)/2;
            if (nums[mid] == target)
            {
                exists = true;
                l = mid+1;
            }
            if (nums[mid] > target)
            {
                r = mid-1;
            }
            if (nums[mid] < target)
            {
                l = mid+1;
            }
        }
        return exists ? r : -1;
    }
}
// @lc code=end

