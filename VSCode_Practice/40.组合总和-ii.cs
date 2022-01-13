/*
 * @lc app=leetcode.cn id=40 lang=csharp
 *
 * [40] 组合总和 II
 */

// @lc code=start
using System.Collections.Generic;
using System;

public class Solution40 {
    public void Test()
    {
        var ca = new int[]{10,1,2,7,6,1,5};
        var target = 8;
        var ans = CombinationSum2(ca, target);
    }

    public IList<IList<int>> CombinationSum2(int[] candidates, int target) 
    {
        Array.Sort(candidates);
        var res = new List<IList<int>>();
        var path = new List<int>();
        var visied = new bool[candidates.Length];
        BackTrack(0,0, target, visied, candidates, res, path);
        return res;
    }

    private void BackTrack(int index, int sum, int target, bool[] visited, int[] candidates, List<IList<int>> res, List<int> path)
    {
        if (sum == target)
        {
            res.Add(new List<int>(path));
            return;
        }
        if (sum > target)
        {
            return;
        }
        var containSet = new HashSet<int>();
        for (int i = index; i < candidates.Length; i++)
        {
            if (visited[i] == true || containSet.Contains(candidates[i]))
            {
                continue;
            }
            //有序数组中发现sum + candidates[i] > target，后续元素都无需判断，可以剪枝
            if (sum + candidates[i] > target)
            {
                return;
            }
            containSet.Add(candidates[i]);
            visited[i] = true;
            path.Add(candidates[i]);
            BackTrack(i, sum + candidates[i], target, visited, candidates, res, path);
            visited[i] = false;
            path.RemoveAt(path.Count-1);
        }
    }
}
// @lc code=end

