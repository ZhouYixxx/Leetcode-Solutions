/*
 * @lc app=leetcode.cn id=88 lang=csharp
 *
 * [88] 合并两个有序数组
 */

// @lc code=start
using System.Collections.Generic;
using System;

public class Solution88 {
    public void Test()
    {
        var nums1 = new int[]{2,14,0,0,0,0};
        var nums2 = new int[]{7,8,9,15};
        int m = 2, n =4;
        Merge(nums1,m,nums2,n);
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var i = m -1;
        var j = n -1;
        var cur = m+n-1;
        while (i >= 0 && j >= 0)
        {
            if (nums1[i] >= nums2[j])
            {
                nums1[cur--] = nums1[i--];
            }
            else
            {
                nums1[cur--] = nums2[j--];
            }
        }
        while (i >= 0)
        {
            nums1[cur--] = nums1[i--];
        }
        while (j >= 0)
        {
            nums1[cur--] = nums2[j--];
        }
    }
}
// @lc code=end

