/*
 * @lc app=leetcode.cn id=153 lang=csharp
 *
 * [153] 寻找旋转排序数组中的最小值
 */

// @lc code=start
using System;

public class Solution153 {
    public void Test()
    {
        var nums = new int[]{3,4,5,1,2};
        var ans = FindMin2(nums);
    }

    
    public int FindMin1(int[] nums) 
    {
        var l = 0;
        var r = nums.Length-1;
        var min = Int32.MaxValue;
        while (l <=  r)
        {
            var mid = l+(r-l)/2;
            min = Math.Min(nums[mid], min);
            //左右都是单调区间，无需担心mid+1溢出
            if (nums[l] < nums[mid] && nums[mid+1] < nums[r])
            {
                min = Math.Min(min, Math.Min(nums[l], nums[r]));
                l = mid+1;
                continue;
            }
            //[l,mid]是单调区间，最小值应该在[mid+1,r]中寻找
            if (nums[l] < nums[mid])
            {
                min = Math.Min(min, nums[l]);
                l = mid+1;
            }
            else
            {
                if (mid != r)
                {
                    min = Math.Min(min, nums[mid+1]);
                }
                r = mid-1;
            }
        }
        return min;
    }

    //简洁写法
    public int FindMin(int[] nums)
    {
        var l = 0;
        var r = nums.Length-1;
        if (nums[l] < nums[r])
        {
            return nums[l];
        }
        while (l <= r)
        {
            if (l == r)
            {
                return nums[l];
            }
            var mid = l+(r-l)/2;
            if (nums[mid] > nums[r])
            {
                l = mid+1;
                continue;
            }
            if (nums[mid] < nums[r])
            {
                r = mid;
                continue;
            }
        }
        return nums[l];
    }

    /// <summary>
    /// 2021.11.26
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindMin2(int[] nums)
    {
        int l = 0, r = nums.Length-1;
        if (nums[l] < nums[r])
        {
            return nums[l];
        }
        while (l <= r)
        {
            if (l == r)
            {
                return nums[l];
            }
            var mid = (l + r) / 2;
            if (nums[mid] > nums[r])
            {
                l = mid+1;
                continue;
            }
            if (nums[mid] < nums[r])
            {
                r = mid;
                continue;
            }
        }
        return nums[l];
    }
}
// @lc code=end

