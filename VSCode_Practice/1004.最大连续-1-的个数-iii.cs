/*
 * @lc app=leetcode.cn id=1004 lang=csharp
 *
 * [1004] 最大连续1的个数 III
 */

// @lc code=start

using System;
public class Solution1004 {

    public void Test()
    {
        var nums = new int[]{1,1,1,0,0,0,1,1,1,1,0};
        LongestOnes(nums,2);
    }

    public int LongestOnes(int[] A, int K) {
        int l = 0;
        int max = 0;
        for (int r = 0; r < A.Length; r++)
        {
            if (A[r] == 0)
            {
                K--;
            }
            while (K < 0)
            {
                if (A[l++] == 0)
                {
                    K++;
                }
            }
            max = Math.Max(max, r-l+1);
        }
        return max;

/*         int l = 0, r = 0;
        while (r < A.Length) {
            if (A[r] == 0)
            {
                K--;
            }
            if (K < 0)
            {
                if (A[l] == 0)
                {
                    K++;
                }
                l++;
            }
            r++;
        }
        return r - l; */
    }
}
// @lc code=end

