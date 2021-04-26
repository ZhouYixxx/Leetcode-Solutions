/*
 * @lc app=leetcode.cn id=162 lang=csharp
 *
 * [162] 寻找峰值
 */

// @lc code=start
public class Solution162 {
    public void Test()
    {
        var nums = new int[]{4,3};
        var ans = FindPeakElement(nums);
    }
    public int FindPeakElement(int[] nums) 
    {
        var l = 0;
        var r = nums.Length-1;
        while (l < r)
        {
            var mid = l+(r-l)/2;
            if (nums[mid] > nums[mid+1])
            {
                r = mid;
            }
            else
            {
                l = mid+1;
            }
        }
        return l;
    }
}
// @lc code=end

