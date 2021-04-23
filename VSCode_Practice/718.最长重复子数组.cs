/*
 * @lc app=leetcode.cn id=718 lang=csharp
 *
 * [718] 最长重复子数组
 */

// @lc code=start

using System;

public class Solution718 {
    public void Test()
    {
        var nums1 = new int[]{1,3,2,1};
        var nums2 = new int[]{3,2,1,4,7};
        var ans = FindLength(nums1, nums2);
    }

    public int FindLength(int[] nums1, int[] nums2) 
    {
        if (nums1.Length == 0 || nums2.Length == 0)
        {
            return 0;
        }
        var dp = new int[nums1.Length+1,nums2.Length+1];
        // dp[0,0] = nums1[0] == nums2[0] ? 1 : 0;
        int max = 0;
        for (int i = 1; i <= nums1.Length; i++)
        {
            for (int j = 1; j <= nums2.Length; j++)
            {
                if (nums1[i-1] == nums2[j-1])
                {
                    dp[i,j] = dp[i-1,j-1]+1;
                }
                else
                {
                    dp[i,j] = 0;
                }
                max = Math.Max(dp[i,j], max);
            }
        }
        return max;
    }

    public int FindLength1(int[] nums1, int[] nums2) 
    {
        if (nums1.Length == 0 || nums2.Length == 0)
        {
            return 0;
        }
        var dp = new int[nums1.Length,nums2.Length];
        // dp[0,0] = nums1[0] == nums2[0] ? 1 : 0;
        int max = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            dp[i,0] = nums1[i] == nums2[0] ? 1 : 0;
            if (dp[i,0] == 1)
            {
                max = 1;
            }
        }
        for (int i = 0; i < nums2.Length; i++)
        {
            dp[0,i] = nums1[0] == nums2[i] ? 1 : 0;
            if (dp[0,i] == 1)
            {
                max = 1;
            }
        }
        for (int i = 1; i < nums1.Length; i++)
        {
            for (int j = 1; j < nums2.Length; j++)
            {
                if (nums1[i] == nums2[j])
                {
                    dp[i,j] = dp[i-1,j-1]+1;
                }
                else
                {
                    dp[i,j] = 0;
                }
                max = Math.Max(dp[i,j], max);
            }
        }
        return max;
    }
}
// @lc code=end

