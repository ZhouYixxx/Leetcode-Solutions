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
        var nums = new int[]{4,5,6,7,0,1,2};
        var ans = FindMin(nums);
    }

    //还有问题
    public int FindMin(int[] nums) 
    {
        var l = 0;
        var r = nums.Length-1;
        var min = Int32.MaxValue;
        while (l <=  r)
        {
            var mid = l+(r-l)/2;
            min = Math.Min(nums[mid], min);
            //都是单调区间，无需担心mid+1溢出
            if (nums[l] < nums[mid] && nums[mid+1] < nums[r])
            {
                l = mid+1;
                continue;
            }
            //[l,mid]是单调区间，最小值应该在[mid+1,r]中寻找
            if (nums[l] < nums[mid])
            {
                l = mid+1;
            }
            else
            {
                r = mid-1;
            }
        }
        return min;
    }
}
// @lc code=end

