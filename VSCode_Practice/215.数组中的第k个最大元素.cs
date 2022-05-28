/*
 * @lc app=leetcode.cn id=215 lang=csharp
 *
 * [215] 数组中的第K个最大元素
 */

// @lc code=start
using System;
public class Solution215 {
    public void Test(){
        var nums = new int[]{213,43,5,6,57,87,9,213,67,65,21,8,8,90};
        var k = 4;
        var ans = FindKthLargest(nums, k);
    }

    public int FindKthLargest(int[] nums, int k) {
        Array.Sort(nums);
        var ans = nums[nums.Length-1];
        int i = 0;
        while (i < k)
        {
            ans = nums[nums.Length-1-i];
            i++;
        }
        return ans;
    }
}
// @lc code=end

