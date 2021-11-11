/*
 * @lc app=leetcode.cn id=167 lang=csharp
 *
 * [167] 两数之和 II - 输入有序数组
 */

// @lc code=start
using System.Collections.Generic;

public class Solution167 {
    public void Test()
    {
        var nums = new int[]{2,3,4};
        var ans = TwoSum(nums,7);
    }

    public int[] TwoSum(int[] numbers, int target) 
    {
        var ans = new int[2];
        for (int i = 0; i < numbers.Length; i++)
        {
            var num = target -  numbers[i];
            var l = 0;
            var r = numbers.Length-1;
            if (num >= numbers[i])
            {
                l = i+1;
            }
            else
            {
                r = i-1;
            }
            while (l <= r)
            {
                var mid = (l+r) / 2;
                if (numbers[mid] == num)
                {
                    if (i > mid)
                    {
                        return new int[]{mid+1,i+1};
                    }
                    return new int[]{i+1,mid+1};
                }
                if(l == r)
                    break;
                if (numbers[mid] > num)
                {
                    r = mid;
                }
                else
                {
                    l = mid+1;
                }
            }
        }
        return ans;
    }
}
// @lc code=end

