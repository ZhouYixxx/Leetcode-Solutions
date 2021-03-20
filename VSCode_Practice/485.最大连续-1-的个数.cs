/*
 * @lc app=leetcode.cn id=485 lang=csharp
 *
 * [485] 最大连续1的个数
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution485 {
    public void Test()
    {
        var nums = new int[]{1,0};
        var list = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                list.Add(i);
            }
        }
        FindMaxConsecutiveOnes(nums);
    }

    public int FindMaxConsecutiveOnes(int[] nums) {
/*         int zeroCount = 0;
        int zeroIndex = -1;
        int lastZeroIndex = -1;
        int max = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == 0) 
            {
                lastZeroIndex = zeroIndex;
                zeroIndex = i;
                if(zeroCount >= 1)
                {
                    zeroCount = 0;
                }
                else{
                    zeroCount++;
                    max = Math.Max(max, i - lastZeroIndex);
                }
            }
            else
            {
                max = Math.Max(max, i - lastZeroIndex);
            }
        }
        return max; */
        var index = -1;
        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                index = i;
            }
            else
            {
                max = Math.Max(max, i-index);
            }
        }
        return max;
        
        /* var left = 0;
        var right = 0;
        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                right++;
            }
            else
            {
                if (right-left > max)
                {
                    max = right - left;
                }
                left = i+1;
                right = i+1;
            }
        }
        if (right-left > max)
        {
            max = right - left;
        }
        return max; */
    }
}
// @lc code=end

