/*
 * @lc app=leetcode.cn id=39 lang=csharp
 *
 * [39] 组合总和
 */

// @lc code=start
using System.Collections.Generic;
using System;

public class Solution39 {
    public void Test()
    {
        var nums = new int[]{2,3,5,1};
        var target = 8;
        var ans = CombinationSum(nums,target);
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target) 
    {
        Array.Sort(candidates);
        var res = new List<IList<int>>();
        var path = new List<int>();
        int sum = 0;
        BackTrack(0, candidates, sum, target, res, path);
        return res;
    }

    private void BackTrack(int startIndex, int[] candidates, int sum, int target, List<IList<int>> res, List<int> path)
    {
        if (sum > target)
        {
            return;
        }
        if (sum == target)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = startIndex; i < candidates.Length; i++)
        {
            //剪枝：数组升序排列，sum + candidates[i] > target时，i后面的元素都不可能满足条件
            if (sum + candidates[i] > target)
            {
                return;
            }
            path.Add(candidates[i]);
            sum += candidates[i];
            BackTrack(i,candidates, sum, target, res, path);
            sum -= candidates[i];
            path.RemoveAt(path.Count-1);
        }
    }
    
}
// @lc code=end

