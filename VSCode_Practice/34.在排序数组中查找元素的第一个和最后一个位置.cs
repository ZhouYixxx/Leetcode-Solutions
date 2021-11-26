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
        var nums = new int[]{7,7,7,7,7,7,7,7,7,7,7};
        var target = 7;
        var ans = SearchRange(nums, target);
    }

    public int[] SearchRange(int[] nums, int target) 
    {
        var l = GetLeftBorder1(nums,target);
        var r = GetRightBorder1(nums,target);
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

    public int GetLeftBorder1(int[] nums, int target)
    {
        int l = 0, r = nums.Length-1;
        while (l <= r)
        {
            if (l == r)
            {
                return nums[l] == target ? l : -1;
            }
            var mid = (l+r)/2;
            if (nums[mid] == target && (mid == 0 || nums[mid-1] != target))
            {
                return mid;
            }
            if (nums[mid] >= target)
            {
                r = mid;
            }
            if (nums[mid] < target)
            {
                l = mid+1;
            }
        }
        return -1;
    }

    public int GetRightBorder1(int[] nums, int target)
    {
        int l = 0, r = nums.Length-1;
        while (l <= r)
        {
            if (l == r)
            {
                return nums[l] == target ? l : -1;
            }
            var mid = (l+r)/2;
            if (nums[mid] == target && (mid == nums.Length-1 || nums[mid+1] != target))
            {
                return mid;
            }
            if (nums[mid] > target)
            {
                r = mid;
            }
            if (nums[mid] <= target)
            {
                l = mid+1;
            }
        }
        return -1;
    }
}
// @lc code=end

