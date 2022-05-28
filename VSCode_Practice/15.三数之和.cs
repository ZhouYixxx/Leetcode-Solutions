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
        var nums = new int[]{-2,0,0,2,2};
        //var nums = new int[]{1,-1,-1,0};
        var ans = ThreeSum1(nums);
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

    /// <summary>
    /// 20220222
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<IList<int>> ThreeSum1(int[] nums) {
        var ans = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length-2; i++)
        {
            var a = nums[i];
            //由于已经排序，a>0则后面所有数均大于零，不会存在和为0的组合，直接终止循环
            if (a > 0)
            {
                break;
            }
            var l = i+1;
            var r = nums.Length-1;
            //避免重复
            if (i > 0 && nums[i] ==nums[i-1])
            {
                continue;
            }
            while (l < r)
            {
                var sum = nums[i] + nums[l] + nums[r];
                if (sum == 0)
                {
                    if (l-1 != i && nums[l] == nums[l-1])
                    {
                        l++;
                        continue;
                    }
                    if (r+1 < nums.Length && nums[r] == nums[r+1])
                    {
                        r--;
                        continue;
                    }
                    ans.Add(new List<int>(){a,nums[l++],nums[r--]});
                    continue;
                }
                //和太大，r向左移动
                if (sum > 0)
                {
                    r--;
                }
                //和太小，l向右移动
                else
                {
                    l++;
                }
            }
        }
        return ans;
    }

}
// @lc code=end

