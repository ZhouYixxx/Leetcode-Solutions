/*
 * @lc app=leetcode.cn id=704 lang=csharp
 *
 * [704] 二分查找
 */

// @lc code=start
using System;

public class Solution704 {
    public void Test()
    {
        var nums = new int[]{-1,0,3,5,9,12};
        var target = 10;
        var ans = Search2(nums,target);
    }

    //写法一：注意l,r和mid的取值
    public int Search(int[] nums, int target) 
    {
        var l = 0;
        var r = nums.Length-1;
        var mid = l + (r-l)/2;
        while (l <= r)
        {
            if (l == r)
            {
                return nums[l] == target ? l : -1;
            }
            mid = l + (r-l)/2;
            if (nums[mid] == target)
            {
                return mid;
            }
            if (nums[mid] < target)
            {
                l = mid+1;
            }
            if (nums[mid] > target)
            {
                r = mid;
            }
        }
        return -1;
    }

    //写法二：注意l,r和mid的取值
    public int Search2(int[] nums, int target) 
    {
        var l = 0;
        var r = nums.Length-1;
        var mid = l + (r-l+1)/2;
        while (l <= r)
        {
            if (l == r)
            {
                return nums[l] == target ? l : -1;
            }
            mid = l + (r-l+1)/2;
            if (nums[mid] == target)
            {
                return mid;
            }
            if (nums[mid] < target)
            {
                l = mid;
            }
            if (nums[mid] > target)
            {
                r = mid-1;
            }
        }
        return -1;
    }
}
// @lc code=end

