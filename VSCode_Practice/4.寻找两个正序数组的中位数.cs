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
        var nums1 = new int[]{1000001};
        var nums2 = new int[]{1000000};
        var ans = FindMedianSortedArrays(nums1, nums2);
    }
    
    /// <summary>
    /// 方法一：求第K小数的方法
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
    {
        var k = (nums1.Length + nums2.Length)/2;//第k小数(索引0是第1个数)
        if (nums1.Length > nums2.Length)
        {
            var temp = nums2;
            nums2 = nums1;
            nums1 = temp;
        }
        //奇数
        if (((nums1.Length + nums2.Length) & 1) == 1)
        {
            var ans = GetKthMinElement(nums1, 0, nums1.Length-1, nums2, 0, nums2.Length-1, k+1);
            return ans;
        }
        //偶数
        var left = GetKthMinElement(nums1, 0, nums1.Length-1, nums2, 0, nums2.Length-1, k);
        var right = GetKthMinElement(nums1, 0, nums1.Length-1, nums2, 0, nums2.Length-1, k+1);
        return (left+right)/2d;
    }

    /// <summary>
    /// 求两个数组第k小的数（k>=1）
    /// </summary>
    public int GetKthMinElement(int[] nums1, int start1, int end1, int[] nums2, int start2, int end2, int k)
    {
        //保证nums1.Length < nums2.Length
        if (start1 >= nums1.Length)
        {
            return nums2[start2+k-1];
        }
        if (start2 >= nums2.Length)
        {
            return nums1[start1+k-1];
        }
        if (k == 1)
        {
            return Math.Min(nums1[start1], nums2[start2]);
        }
        var mid1 = k/2+start1-1;
        var mid2 = k/2+start2-1;
        if (mid1 > nums1.Length-1)
        {
            mid1 = nums1.Length-1;
        }
        if (nums1[mid1] <= nums2[mid2])
        {
            var count = mid1 - start1+1;
            return GetKthMinElement(nums1,mid1+1, end1, nums2, start2, end2, k-count);
        }
        else
        {
            var count = mid2 - start2 +1;
            return GetKthMinElement(nums1,start1,end1, nums2, mid2+1, end2, k-count);
        }
    }

    /// <summary>
    /// 分割线法
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public double FindMedianSortedArrays1(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            var temp = nums2;
            nums2 = nums1;
            nums1 = temp;
        }
        var size_left = (nums1.Length + nums2.Length+1)/2;
        int i = 0,j=0,left = 0, right = nums1.Length-1;
        while (left <= right)
        {
            if (left == right)
            {
                break;
            }
            i = (left + right+1)/2;
            j = size_left-i;
            if (nums1[i-1] > nums2[j])
            {
                right = i-1;
            }
            else
            {
                left = i;
            }
        }
        i = left;
        j = size_left - i;
        var nums1_left = i == 0 ? int.MinValue : nums1[i-1];
        var nums1_right = i >= nums1.Length ? int.MaxValue : nums1[i];
        var nums2_left = j == 0 ? int.MinValue : nums2[j-1];
        var nums2_right = j >= nums2.Length ? int.MaxValue : nums2[j];
        //奇数
        if (((nums1.Length + nums2.Length) & 1) == 1)
        {
            var ans = (double)Math.Max(nums1_left, nums2_left);
            return ans;
        }
        //偶数
        var left_val = Math.Max(nums1_left, nums2_left);
        var right_val = Math.Min(nums1_right, nums2_right);
        return (left_val + right_val)/2d;
    } 
}
// @lc code=end

