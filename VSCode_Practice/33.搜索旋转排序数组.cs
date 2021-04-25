/*
 * @lc app=leetcode.cn id=33 lang=csharp
 *
 * [33] 搜索旋转排序数组
 */

// @lc code=start
using System;

public class Solution33 {
    public void Test()
    {
        var nums = new int[]{3,1};
        var target = 3;
        var ans = Search(nums, target);
    }

    public int Search(int[] nums, int target) 
    {
        var l = 0;
        var r = nums.Length-1;
        while (l <= r)
        {
            var mid = l+(r-l)/2;
            if (nums[mid] == target)
            {
                return mid;
            }
            //[0,mid]为有序数组
            if (nums[mid] > nums[l])
            {
                //此时可以不包含等于的情况因为nums[mid]已经做了判断
                if (nums[mid] > target && nums[l] <= target)
                {
                    r = mid-1;
                }
                else
                {
                    l = mid+1;
                }
            }
            //[mid+1,r]为有序数组
            else
            {
                if (mid == r)
                {
                    return nums[r] == target ? r : -1;
                }
                //此时必须包含等于的情况因为nums[mid+1]尚未作判断
                if (nums[mid+1] <= target && nums[r] >= target)
                {
                    l = mid+1;
                }
                else
                {
                    r = mid-1;
                }
            }
        }
        return -1;
    }
}
// @lc code=end

