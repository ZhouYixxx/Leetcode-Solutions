/*
 * @lc app=leetcode.cn id=15 lang=csharp
 *
 * [15] 三数之和
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution15 {
    public void Test()
    {
        var nums = new int[]{-1,0,1,2,-1,-4};
        //var nums = new int[]{1,-1,-1,0};
        var ans = ThreeSum(nums);
    }

    public IList<IList<int>> ThreeSum(int[] nums) 
    {
        if (nums.Length < 3)
        {
            return new List<IList<int>>();
        }
        Array.Sort(nums);
        var res = new List<IList<int>>();
        var n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > 0)
            {
                continue;
            }
            //避免出现重复解
            if (i > 0 && nums[i] == nums[i-1])
            {
                continue;
            }
            //固定一个数nums[i]，余下两个数采用双指针
            int l = i+1;
            int r = n-1;
            while (l < r)
            {
                var ans = nums[l]+nums[r]+nums[i];
                if (ans == 0)
                {
                    if (l < r && l > i+1 && nums[l] == nums[l-1])
                    {
                        l++;
                        continue;
                    }
                    if (l < r && r < n-1 && nums[r] == nums[r+1])
                    {
                        r--;
                        continue;
                    }
                    var list = new List<int>(){nums[i], nums[l], nums[r]};
                    res.Add(list);
                    l++;
                    r--;
                }
                if (ans > 0)
                {
                    r--;
                }
                if (ans < 0)
                {
                    l++;
                }
            }
        }
        return res;
    }
}
// @lc code=end

