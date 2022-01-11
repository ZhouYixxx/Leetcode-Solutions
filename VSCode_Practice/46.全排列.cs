/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution46 {
    public void Test()
    {
        var nums = new int[]{1,2,3};
        var ans = Permute(nums);
    }

    public IList<IList<int>> Permute(int[] nums) 
    {
        var list = new List<IList<int>>();
        var visited = new bool[nums.Length];
        BackTrack(nums,list,visited, new List<int>());
        return list;
    }

    private void BackTrack(int[] nums, List<IList<int>> res, bool[] visited, List<int> tempRes)
    {
        if (tempRes.Count == nums.Length)
        {
            res.Add(new List<int>(tempRes));
            return;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (visited[i])
                continue;
            visited[i] = true;
            tempRes.Add(nums[i]);
            // var str = "";
            // foreach (var item in tempRes)
            // {
            //     str += $"{item}, ";
            // }
            // Console.WriteLine($"递归前：tempRes={str}");
            BackTrack(nums, res, visited, tempRes);
            // str = "";
            // foreach (var item in tempRes)
            // {
            //     str += $"{item}, ";
            // }
            // Console.WriteLine($"递归后：tempRes={str}");
            visited[i] = false;
            tempRes.RemoveAt(tempRes.Count-1);
        }
    }

    #region 2022.01.06

    public IList<IList<int>> Permute2(int[] nums) 
    {
        var list = new List<IList<int>>();
        var visited = new bool[nums.Length];
        BackTrack2(nums, visited, list, new List<int>());
        return list;
    }

    private void BackTrack2(int[] nums, bool[] visited, IList<IList<int>> res, List<int> path)
    {
        if (path.Count == nums.Length)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (visited[i])
            {
                continue;
            }
            visited[i] = true;
            path.Add(nums[i]);
            BackTrack2(nums, visited, res, path);
            visited[i] = false;
            path.RemoveAt(path.Count -1);
        }
    }
         
    #endregion
}
// @lc code=end

