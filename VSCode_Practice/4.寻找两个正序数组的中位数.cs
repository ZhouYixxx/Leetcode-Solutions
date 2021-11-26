/*
 * @lc app=leetcode.cn id=4 lang=csharp
 *
 * [4] 寻找两个正序数组的中位数
 */

// @lc code=start
using System;

public class Solution004 {
    public void Test()
    {
        var nums1 = new int[]{1,3};
        var nums2 = new int[]{1,2,3,4,5,6,7,8,9,10};
        var ans = FindMedianSortedArrays(nums1, nums2);
    }
    
    /// <summary>
    /// 求第K小数
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
    {
        var k = (nums1.Length + nums2.Length)/2;//第k个数(索引0是第1个数)
        int start1 = 0, start2 = 0;
        while (k > 1)
        {
            var count = 0;
            var i = start1 + k/2-1;
            var j = start2 + k/2-1;
            if (i >= nums1.Length)
            {
                i = nums1.Length-1;
            }
            if (j >= nums2.Length)
            {
                j = nums2.Length-1;
            }
            if (nums1[i] > nums2[j])
            {
                count =  j+1 - start2;
                start2 = j+1;
            }
            else
            {
                count =  i+1 - start1;
                start1 = i+1;
            }
            k -= count; 
        }
        var min = Math.Min(nums1[start1], nums2[start2]);
        if (((nums1.Length + nums2.Length)&1) == 1)
        {
            return min;
        }
        else
        {
            double min2 = 0;
            if (nums1[start1] == min)
            {
                min2 = start1 < nums1.Length-1 ? Math.Min(nums1[start1+1], nums2[start2]) : nums2[start2];
            }
            else
            {
                min2 = start2 < nums2.Length-1 ? Math.Min(nums1[start1], nums2[start2+1]) : nums1[start1];
            }
            return (min+ min2)/2;
        }
    }
}
// @lc code=end

