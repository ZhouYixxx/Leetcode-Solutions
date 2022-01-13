/*
 * @lc app=leetcode.cn id=90 lang=csharp
 *
 * [90] 子集 II
 */

// @lc code=start
using System.Collections.Generic;
using System;

public class Solution90 {
    public void Test()
    {
        var nums = new int[]{2,1,2};
        var ans = SubsetsWithDup(nums);
    }

    public IList<IList<int>> SubsetsWithDup(int[] nums) 
    {
        Array.Sort(nums);
        var res = new List<IList<int>>();
        BackTrack(0, nums, res, new List<int>());
        return res;
    }

    private void BackTrack(int index, int[] nums, List<IList<int>> res, List<int> path)
    {
        if (index > nums.Length)
        {
            return;
        }
        var dupSet = new HashSet<int>();
        res.Add(new List<int>(path));
        for (int i = index; i < nums.Length; i++)
        {
            if (dupSet.Contains(nums[i]))
            {
                continue;
            }
            dupSet.Add(nums[i]);
            path.Add(nums[i]);
            BackTrack(i+1, nums, res, path);
            path.RemoveAt(path.Count-1);
        }
    }
}
// @lc code=end

